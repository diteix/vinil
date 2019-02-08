using System.ComponentModel.DataAnnotations;
using Vinil.Contracts.Common.Filters;

namespace Vinil.Models
{
    public abstract class BaseFilter : IBaseFilter
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Page { get; set; }

        [Required]
        [Range(2, 50)]
        public int PageSize { get; set; }
    }
}