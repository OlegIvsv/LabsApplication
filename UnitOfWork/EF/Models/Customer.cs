using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.EF.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Firstname { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public int Age { get; set; }

        public string Country { get; set; } = null!;

        public bool? Gender { get; set; }

        public string EmailAddress { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? ProfilePicture { get; set; }


        public List<Product> Products { get; set; } = new();

        public List<Order> Orders { get; set; } = new();

        public List<ProductToCustomer> ProductToCustomers { get; set; } = new();
    }
}
