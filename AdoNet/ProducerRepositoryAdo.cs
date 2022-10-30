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
    internal class ProducerRepositoryAdo : BaseRepositoryAdo<ProducerData>
    {
        public ProducerRepositoryAdo(string connectionString) : base(connectionString)
        {
        }


        public override void Delete(ProducerData entity)
        {
            this.Delete(entity.Id);
        }

        public override void Delete(int id)
        {
            string text = "delete Producers where Id = @id";
            var parameters = new SqlParameter[] { new SqlParameter("@id", id) };
            Execute(text, parameters);
        }

        public override ProducerData? Get(int id)
        {
            string text = "select * from Producers where Id = @id";
            var parameters = new SqlParameter[] { new("@id", id) };

            return ExecuteRead(text, ProducerData.FromDataRecord, parameters)
                .FirstOrDefault();
        }

        public override void Insert(ProducerData entity)
        {
            string text = "insert into Producers( Id, Name, Country Description) " +
                "values(@id, @name,@country, @description)";
            var parameters = new SqlParameter[]
            {
                new ("@id", entity.Id),
                new ("@name", entity.Name),
                new ("@country", entity.Country),
                new ("@description", entity.Description),
            };

            Execute(text, parameters);
        }

        public override IList<ProducerData> List()
        {
            string text = "select * from Producers;";
            return ExecuteRead(text, ProducerData.FromDataRecord)
             .ToList();
        }

        public override IList<ProducerData> List(Func<ProducerData, bool> expression)
        {
            string text = "select * from Producers;";
            return ExecuteRead(text, ProducerData.FromDataRecord, expression)
             .ToList();
        }

        public override void Update(ProducerData entity)
        {
            string text = "update into Products " +
                "set Id = @id, Name = @name,Country = @country, Description = @description)";
            var parameters = new SqlParameter[]
            {
                new ("@id", entity.Id),
                new ("@name", entity.Name),
                new ("@country", entity.Country),
                new ("@description", entity.Description),
            };

            Execute(text, parameters);
        }
    }
}
