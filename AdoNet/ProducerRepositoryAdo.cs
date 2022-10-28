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
    internal class ProducerRepositoryAdo : BaseRepositoryAdo<ProducerDTO>
    {
        public ProducerRepositoryAdo(string connectionString) : base(connectionString)
        {
        }


        public override void Delete(ProducerDTO entity)
        {
            this.Delete(entity.Id);
        }

        public override void Delete(int id)
        {
            string text = "delete Producers where Id = @id";
            var parameters = new SqlParameter[] { new SqlParameter("@id", id) };
            Execute(text, parameters);
        }

        public override ProducerDTO? Get(int id)
        {
            string text = "select * from Producers where Id = @id";
            var parameters = new SqlParameter[] { new("@id", id) };

            return ExecuteRead(text, ProducerDTO.FromDataRecord, parameters)
                .FirstOrDefault();
        }

        public override void Insert(ProducerDTO entity)
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

        public override IList<ProducerDTO> List()
        {
            string text = "select * from Producers;";
            return ExecuteRead(text, ProducerDTO.FromDataRecord)
             .ToList();
        }

        public override IList<ProducerDTO> List(Func<ProducerDTO, bool> expression)
        {
            string text = "select * from Producers;";
            return ExecuteRead(text, ProducerDTO.FromDataRecord, expression)
             .ToList();
        }

        public override void Update(ProducerDTO entity)
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
