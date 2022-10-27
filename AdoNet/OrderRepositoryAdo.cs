using LabsApplication.UnitOfWork.EF.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.AdoNet
{
    internal class OrderRepositoryAdo : BaseRepositoryAdo<OrderDTO>
    {
        public OrderRepositoryAdo(string connectionString) : base(connectionString)
        {
        }


        public override void Delete(OrderDTO entity)
        {
            string text = "delete Customer where Id = @id";
            var parameters = new SqlParameter[] { new SqlParameter("@id", entity.Id) };
            Execute(text, parameters);
        }

        public override OrderDTO? Get(int id)
        {
            string text = "select * from Orders where Id = @id";
            var parameters = new SqlParameter[] { new("@id", id) };

            return ExecuteRead(text, OrderDTO.FromDataRecord, parameters)
                .FirstOrDefault();
        }

        public override void Insert(OrderDTO entity)
        {
            string text = "insert into Orders(Id, CreationTime, CustomerId, PaymentMethodId) " +
                "values(@id, @creationTime, @customerId, @paymentMethodId)";
            var parameters = new SqlParameter[]
            {
                new ("@id", entity.Id),
                new ("@creationTime", entity.CreationTime),
                new ("@customerId", entity.CustomerId),
                new ("@paymentMethodId", entity.PaymentMethodId)
            };

            Execute(text, parameters);
        }

        public override IList<OrderDTO> List()
        {
            string text = "select * from Orders;";
            return ExecuteRead(text, OrderDTO.FromDataRecord)
             .ToList();
        }

        public override IList<OrderDTO> List(Func<OrderDTO, bool> expression)
        {
            string text = "select * from Customers;";
            return ExecuteRead(text, OrderDTO.FromDataRecord, expression)
             .ToList();
        }

        public override void Update(OrderDTO entity)
        {
            string text = "update into Customer " +
                "set Id = @id, CreationTime = @creationTime, CustomerId = @customerId, PaymentMethodId = @paymentMethodId)";
            var parameters = new SqlParameter[]
            {
                new ("@id", entity.Id),
                new ("@creationTime", entity.CreationTime),
                new ("@customerId", entity.CustomerId),
                new ("@paymentMethodId", entity.PaymentMethodId)
            };

            Execute(text, parameters);
        }
    }
}
