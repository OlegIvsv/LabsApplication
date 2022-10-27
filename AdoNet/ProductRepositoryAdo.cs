﻿using LabsApplication.UnitOfWork.EF.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.AdoNet
{
    internal class ProductRepositoryAdo : BaseRepositoryAdo<ProductDTO>
    {
        public ProductRepositoryAdo(string connectionString) : base(connectionString)
        {
        }


        public override void Delete(ProductDTO entity)
        {
            string text = "delete Products where Id = @id";
            var parameters = new SqlParameter[] { new SqlParameter("@id", entity.Id) };
            Execute(text, parameters);
        }

        public override ProductDTO? Get(int id)
        {
            string text = "select * from Orders where Id = @id";
            var parameters = new SqlParameter[] { new("@id", id) };

            return ExecuteRead(text, ProductDTO.FromDataRecord, parameters)
                .FirstOrDefault();
        }

        public override void Insert(ProductDTO entity)
        {
            string text = "insert into Products( Id, Name, Description, ProductType, Price, ProductionDate, " +
                "ExpirationDate, Amount, ProducerId)" +
                "values(@id, @name, @description, @productType, @price, @productionDate, " +
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

        public override IList<ProductDTO> List()
        {
            string text = "select * from Products;";
            return ExecuteRead(text, ProductDTO.FromDataRecord)
             .ToList();
        }

        public override IList<ProductDTO> List(Func<ProductDTO, bool> expression)
        {
            string text = "select * from Products;";
            return ExecuteRead(text, ProductDTO.FromDataRecord, expression)
             .ToList();
        }

        public override void Update(ProductDTO entity)
        {
            string text = "update into Products " +
                "set Id = @id, Name = @name, Description = @description, ProductType = @productType, Price = @price, " +
                "ProductionDate = @productionDate, ExpirationDate = @expirationDate, Amount = @amount, ProducerId = @producerId)";
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
