using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.EF.Models
{
    public class ProductDTO
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

        public static ProductDTO FromDataRecord(IDataRecord row)
        {
            return new ProductDTO
            {
                Id = (int)row["Id"],
                Name = (string)row["Name"],
                Description = (string)row["Description"],
                ProductType = (string)row["ProductType"],
                Price = (decimal)row["Price"],
                ProductionDate = (DateTime)row["ProductionDate"],
                ExpirationDate = (DateTime)row["ExpirationDate"],
                Amount = (int)row["Amount"],
                ProducerId = (int)row["ProducerId"]
            };
        }
    }
}
