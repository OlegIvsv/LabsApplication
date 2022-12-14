using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.EF.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.AdoNet
{
    internal class OrderRepositoryAdo : BaseRepositoryAdo<OrderData>
    {
        public OrderRepositoryAdo(string connectionString) : base(connectionString)
        {
        }


        public override void Delete(OrderData entity)
        {
            Delete(entity.Id);
        }

        public override void Delete(int id)
        {
            string text = "DeleteOrder";
            var parameters = new SqlParameter[] { new SqlParameter("@id", id) };
            Execute(text, parameters);
        }

        public override OrderData? Get(int id)
        {
            string text = "select * from Orders where Id = @id";
            var parameters = new SqlParameter[] { new("@id", id) };

            return ExecuteRead(text, OrderData.FromDataRecord, parameters)
                .FirstOrDefault();
        }

        public override void Insert(OrderData entity)
        {
            string text = "AddOrder";
            var parameters = new SqlParameter[]
            {
                new ("@creationTime", entity.CreationTime) {SqlDbType = SqlDbType.DateTime2},
                new ("@customerId", entity.CustomerId),
                new ("@paymentMethodId", entity.PaymentMethodId)
            };
            HandleNulls(parameters);

            Execute(text, parameters);
        }

        public override IList<OrderData> List()
        {
            string text = "select * from Orders;";
            return ExecuteRead(text, OrderData.FromDataRecord)
             .ToList();
        }

        public override IList<OrderData> List(Func<OrderData, bool> expression)
        {
            string text = "select * from Customers;";
            return ExecuteRead(text, OrderData.FromDataRecord, expression)
             .ToList();
        }

        public override void Update(OrderData entity)
        {
            string text = "UpdateOrder";
            var parameters = new SqlParameter[]
            {
                new ("@id", entity.Id),
                new ("@creationTime", entity.CreationTime.ToString()) { SqlDbType = SqlDbType.DateTime2 },
                new ("@customerId", entity.CustomerId),
                new ("@paymentMethodId", entity.PaymentMethodId)
            };
            HandleNulls(parameters);

            Execute(text, parameters);
        }
    }
}
