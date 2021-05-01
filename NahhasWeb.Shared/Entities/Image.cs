using NahhasWeb.Shared.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NahhasWeb.Shared.Entities
{
    public class Image : Status
    {
        [Required(ErrorMessage = "Please add image path.")]
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }
}