using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.EF.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public string? ProductType { get; set; }

        public decimal Price { get; set; }

        public DateTime ProductionDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int Amount { get; set; }


        public int ProducerId { get; set; }

        public Producer? Producer { get; set; }

        public List<Order> Orders { get; set; } = new();

        public List<Customer> Customers { get; set; } = new();

        public List<ProductToCustomer> ProductToCustomers { get; set; } = new();

        public List<ProductToOrder> ProductToOrders { get; set; } = new();
    }
}
