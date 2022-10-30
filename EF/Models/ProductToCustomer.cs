using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.EF.Models
{
    public class ProductToCustomer
    {
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int Amount { get; set; }
    }
}
