using System;
using System.Collections.Generic;

namespace LabsApplicationAPI.DbFirstModels
{
    public partial class Product
    {
        public Product()
        {
            ProductToCustomerRelations = new HashSet<ProductToCustomerRelation>();
            ProductToOrderRelations = new HashSet<ProductToOrderRelation>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ProductType { get; set; }
        public decimal Price { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Amount { get; set; }
        public int ProducerId { get; set; }

        public virtual Producer Producer { get; set; } = null!;
        public virtual ICollection<ProductToCustomerRelation> ProductToCustomerRelations { get; set; }
        public virtual ICollection<ProductToOrderRelation> ProductToOrderRelations { get; set; }
    }
}
