using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.DTOModels
{
    public class ProductToOrderDTO
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Amount { get; set; }
    }
}
