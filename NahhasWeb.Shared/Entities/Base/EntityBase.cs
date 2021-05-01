using System;

namespace NahhasWeb.Shared.Entities.Base
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Visible { get; set; } = true;

        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}