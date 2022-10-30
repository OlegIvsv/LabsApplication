using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.DTOModels
{
    public class ProductToCustomerData
    {
        public int CustomerId { get; set; }
        
        public int ProductId { get; set; }

        public int Amount { get; set; }
    }
}
