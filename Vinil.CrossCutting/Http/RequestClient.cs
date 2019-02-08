using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Vinil.CrossCutting.Http.Models;

namespace Vinil.CrossCutting.Http
{
    public static class RequestClient
    {
        private static readonly string[] _albumGenres = new string[] { "pop", "mpb", "classic", "rock" };
        private const string ClientId = "";
        private const string ClientSecret = "";
        private const string TokenEndPoint = "https://accounts.spotify.com/api/token";
        private const string DataEndPoint = "https://api.spotify.com/v1/";
        public static async Task<Dictionary<string, IEnumerable<string>>> FetchData()
        {
            string accessToken = await GetToken();

            return await GetData(accessToken);
        }

        private static async Task<string> GetToken()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Basic",
                            Convert.ToBase64String(Encoding.UTF8.GetBytes($"{ClientId}:{ClientSecret}")));

                var content = new FormUrlEncodedContent(new Dictionary<string, string>() { { "grant_type", "client_credentials" } });

                var response = await httpClient.PostAsync(TokenEndPoint, content);

                var responseContent = await response.Content.ReadAsAsync<dynamic>();

                return responseContent.access_token;
            }
        }

        private static async Task<Dictionary<string, IEnumerable<string>>> GetData(string accessToken)
        {
            var data = new Dictionary<string, IEnumerable<string>>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(DataEndPoint);
                httpClient.DefaultRequestHeaders.Authorization
                             = new AuthenticationHeaderValue("Bearer", accessToken);

                foreach (var genre in _albumGenres)
                {
                    var requestArtists = await Search<RequestModel<ArtistModel>>($"search?q=genre:{genre}&type=artist&limit=50", httpClient);

                    var albums = new List<string>();

                    foreach (var artist in requestArtists.Searchs.Items)
                    {
                        var searchAlbums = await Search<SearchModel<AlbumModel>>($"artists/{artist.Id}/albums?include_group=album&limit={50 - albums.Count}", httpClient);

                        albums.AddRange(searchAlbums.Items.Select(s => s.Name).Distinct());

                        if (albums.Count >= 50)
                        {
                            break;
                        }
                    }

                    data.Add(genre, albums);
                }

                return data;
            }
        }

        private static async Task<T> Search<T>(string uri, HttpClient httpClient)
        {
            var response = await httpClient.GetAsync(uri);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync(), new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
        }
    }
}
