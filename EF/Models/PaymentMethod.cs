using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.EF.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double Commission { get; set; }

        public List<Order> Orders { get; set; } = new();
    }
}
