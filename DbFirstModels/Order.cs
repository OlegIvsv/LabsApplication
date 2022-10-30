using System;
using System.Collections.Generic;

namespace LabsApplicationAPI.DbFirstModels
{
    public partial class Order
    {
        public Order()
        {
            ProductToOrderRelations = new HashSet<ProductToOrderRelation>();
        }

        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public int CustomerId { get; set; }
        public int PaymentMethodId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual PaymentMethod PaymentMethod { get; set; } = null!;
        public virtual ICollection<ProductToOrderRelation> ProductToOrderRelations { get; set; }
    }
}
