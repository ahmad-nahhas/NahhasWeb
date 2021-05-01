using NahhasWeb.Shared.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NahhasWeb.Shared.Entities
{
    public class Quote : Status
    {
        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }
    }
}