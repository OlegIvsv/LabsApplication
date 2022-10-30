using System;
using System.Collections.Generic;

namespace LabsApplicationAPI.DbFirstModels
{
    public partial class ProductToCustomerRelation
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
