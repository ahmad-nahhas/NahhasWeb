using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NahhasWeb.Shared.Entities.Base
{
    public abstract class Status : EntityBase
    {
        [Column(TypeName = "decimal(38, 0)")]
        public decimal ViewsCount { get; set; }

        [Column(TypeName = "decimal(38, 0)")]
        public decimal LikesCount { get; set; }

        [Column(TypeName = "decimal(38, 0)")]
        public decimal SharesCount { get; set; }

        [Column(TypeName = "decimal(38, 0)")]
        public decimal DownloadsCount { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}