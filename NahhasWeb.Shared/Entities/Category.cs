using NahhasWeb.Shared.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NahhasWeb.Shared.Entities
{
    public class Category : EntityBase
    {
        [Required(ErrorMessage = "Please Enter Category Name!")]
        public string Name { get; set; }

        public string CoverPath { get; set; }

        [Column(TypeName = "decimal(38, 0)")]
        public decimal StatusCount { get; set; }

        public virtual ICollection<Status> Statuses { get; set; }
    }
}