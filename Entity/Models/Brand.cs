﻿using System;
using System.Collections.Generic;

namespace Entity.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Avatar { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
