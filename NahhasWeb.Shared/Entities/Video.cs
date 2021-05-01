using NahhasWeb.Shared.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NahhasWeb.Shared.Entities
{
    public class Video : Status
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Video is required.")]
        public string VideoPath { get; set; }

        public string CoverPath { get; set; }
    }
}