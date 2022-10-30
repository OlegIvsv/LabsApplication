using System;
using System.Collections.Generic;

namespace LabsApplicationAPI.DbFirstModels
{
    public partial class Producer
    {
        public Producer()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Country { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
