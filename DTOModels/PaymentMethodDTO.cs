using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.DTOModels
{
    public class PaymentMethodData
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double Commission { get; set; }
    }
}
