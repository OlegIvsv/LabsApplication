using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.EF.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.AdoNet
{
    internal class ProductRepositoryAdo : BaseRepositoryAdo<ProductData>
    {
        public ProductRepositoryAdo(string connectionString) : base(connectionString)
        {
        }


        public override void Delete(ProductData entity)
        {
            this.Delete(entity.Id);
        }

        public override void Delete(int id)
        {
            string text = "delete Products where Id = @id";
            var parameters = new SqlParameter[] { new SqlParameter("@id", id) };
            Execute(text, parameters);
        }

        public override ProductData? Get(int id)
        {
            string text = "select * from Products where Id = @id";
            var parameters = new SqlParameter[] { new("@id", id) };

            return ExecuteRead(text, ProductData.FromDataRecord, parameters)
                .FirstOrDefault();
        }

        public override void Insert(ProductData entity)
        {
            string text = "insert into Products (Name, Description, ProductType, Price, ProductionDate, " +
                "ExpirationDate, Amount, ProducerId) " +
                "values (@name, @description, @productType, @price, @productionDate, " +
                "@expirationDate, @amount, @producerId)";
            var parameters = new SqlParameter[]
            {
                new ("@id", entity.Id),
                new ("@name", entity.Name),
                new ("@description", entity.Description),
                new ("@productType", entity.ProductType),
                new ("@price", entity.Price), 
                new ("@productionDate", entity.ProductionDate), 
                new ("@expirationDate", entity.ExpirationDate), 
                new ("@amount", entity.Amount), 
                new ("@producerId", entity.ProducerId)
            };

            Execute(text, parameters);
        }

        public override IList<ProductData> List()
        {
            string text = "select * from Products;";
            return ExecuteRead(text, ProductData.FromDataRecord)
             .ToList();
        }

        public override IList<ProductData> List(Func<ProductData, bool> expression)
        {
            string text = "select * from Products;";
            return ExecuteRead(text, ProductData.FromDataRecord, expression)
             .ToList();
        }

        public override void Update(ProductData entity)
        {
            string text = "update Products " +
                "set Name = @name, Description = @description, ProductType = @productType, Price = @price, " +
                "ProductionDate = @productionDate, ExpirationDate = @expirationDate, Amount = @amount, ProducerId = @producerId " +
                "where Id = @id";
            var parameters = new SqlParameter[]
            {
                new ("@id", entity.Id),
                new ("@name", entity.Name),
                new ("@description", entity.Description),
                new ("@productType", entity.ProductType),
                new ("@price", entity.Price),
                new ("@productionDate", entity.ProductionDate),
                new ("@expirationDate", entity.ExpirationDate),
                new ("@amount", entity.Amount),
                new ("@producerId", entity.ProducerId)
            };

            Execute(text, parameters);
        }
    }
}
