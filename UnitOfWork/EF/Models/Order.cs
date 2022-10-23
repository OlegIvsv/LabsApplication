using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.EF.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }


        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }


        public int PaymentMethodId { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }


        public List<Product> Products { get; set; } = new();


        public List<ProductToOrder> ProductToOrders { get; set; } = new();
    }
}
