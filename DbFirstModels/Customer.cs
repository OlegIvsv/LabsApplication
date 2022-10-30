using System;
using System.Collections.Generic;

namespace LabsApplicationAPI.DbFirstModels
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            ProductToCustomerRelations = new HashSet<ProductToCustomerRelation>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public int Age { get; set; }
        public string Country { get; set; } = null!;
        public bool? Gender { get; set; }
        public string EmailAddress { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? ProfilePicture { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductToCustomerRelation> ProductToCustomerRelations { get; set; }
    }
}
