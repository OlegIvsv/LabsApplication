using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.EF.Models
{
    public class ProductToOrder
    {
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int Amount { get; set; }
    }
}
