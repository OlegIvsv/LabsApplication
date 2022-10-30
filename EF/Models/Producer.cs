using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.EF.Models
{
    public class Producer
    {
        public int Id { get; protected set; }

        public string Name { get; set; } = null!;

        public string? Country { get; set; }

        public string? Description { get; set; }


        public List<Product> Products { get; set; } = new();
    }
}
