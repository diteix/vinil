# vinil
Concept WEB API solution consuming Spotify API.
This solution use dependency injection, inversion of control and asynchronous methods.

To use this solution, go to project "Vinil.CrossCutting", open the folder "Http" and open class file "RequestClient.cs". In line 16, set your Spotify API client_id and in line 17, set your client_secret. Always use the option to rebuild all solution after any change to the code. Because of inversion of control, the Vinil.IoC.dll is not referenced in any project, therefore being loaded dynamically.

Conceito de solução WEB API consumindo a API do Spotify.
Essa solução usa a injeção de dependencia, inversão de controle e métodos assíncronos.

Para usar essa solução, vá ao projeto "Vinil.CrossCutting", abra a pasta "Http" e abra o arquivo de classe "RequestClient.cs". Na linha 16, coloque seu client_id da API do Spotify e na linha 17, coloque seu client_secret. Sempre use a opção de compilar toda a soluçãoapós qualquer mudança no código. Por causa da inversão de controle, a Vinil.IoC.dll não é referenciada em nenhum projeto, portanto sendo carregada dinâmicamente.
