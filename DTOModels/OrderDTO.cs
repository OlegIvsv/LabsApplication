using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.EF.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }

        public int CustomerId { get; set; }

        public int PaymentMethodId { get; set; }

        public static OrderDTO FromDataRecord(IDataRecord row)
        {
            return new OrderDTO
            {
                Id = (int)row["Id"],
                CreationTime = (DateTime)row["CreationTime"],
                CustomerId = (int)row["CustomerId"],
                PaymentMethodId = (int)row["PaymentMethodId"],
            };
        }
    }
}
