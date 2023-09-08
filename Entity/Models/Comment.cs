using System;
using System.Collections.Generic;

namespace Entity.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int? ReviewId { get; set; }
        public int? UserId { get; set; }
        public string? Body { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsActive { get; set; }

        public virtual Review? Review { get; set; }
        public virtual Account? User { get; set; }
    }
}
