using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.EF.Models;
using LabsApplication.UnitOfWork.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LabsApplication.AdoNet
{
    public class CustomerRepositoryAdo : BaseRepositoryAdo<CustomerData>
    {
        public CustomerRepositoryAdo(string connectionString) : base(connectionString)
        {
        }


        public override void Delete(CustomerData entity)
        {
            Delete(entity.Id);
        }

        public override void Delete(int id)
        {
            string text = "delete Customer where Id = @id";
            var parameters = new SqlParameter[] { new SqlParameter("@id", id) };
            Execute(text, parameters);
        }

        public override CustomerData? Get(int id)
        {
            string text = "select * from Customers where Id = @id";
            var parameters = new SqlParameter[] { new("@id", id) };

            return ExecuteRead(text, CustomerData.FromDataRecord, parameters)
                .FirstOrDefault();
        }

        public override void Insert(CustomerData entity)
        {
            string text = "insert into Customer" +
                "(Id, Firstname, Lastname, Age, Country, Gender, EmailAddress, Password, ProfilePicture) " +
                "values(@id, @firstname, @lastname, @age, @country, @gender, @emailAddress, @password, @profilePicture)";
            var parameters = new SqlParameter[]
            {
                new ("@id", entity.Id),
                new ("@firstname", entity.Firstname),
                new ("@lastname", entity.Lastname),
                new ("@age", entity.Age),
                new ("@country", entity.Country),
                new ("@gender", entity.Gender),
                new ("@emailAddress", entity.EmailAddress),
                new ("@password", entity.Password),
                new ("@profilePicture", entity.ProfilePicture)
            };

            Execute(text, parameters);
        }

        public override IList<CustomerData> List()
        {
            string text = "select * from Customers;";
            return ExecuteRead(text, CustomerData.FromDataRecord)
             .ToList();
        }

        public override IList<CustomerData> List(Func<CustomerData, bool> expression)
        {
            string text = "select * from Customers;";
            return ExecuteRead(text, CustomerData.FromDataRecord, expression)
             .ToList();
        }

        public override void Update(CustomerData entity)
        {
            string text = "update into Customer " +
                "set Id = @id, Firstname = @firstname, Lastname = @lastname, Age = @age, Country = @country, " +
                "Gender = @gender, EmailAddress = @emailAddress, Password = @password, ProfilePicture = @profilePicture)";
            var parameters = new SqlParameter[]
            {
                new ("@id", entity.Id),
                new ("@firstname", entity.Firstname),
                new ("@lastname", entity.Lastname),
                new ("@age", entity.Age),
                new ("@country", entity.Country),
                new ("@gender", entity.Gender),
                new ("@emailAddress", entity.EmailAddress),
                new ("@password", entity.Password),
                new ("@profilePicture", entity.ProfilePicture)
            };

            Execute(text, parameters);
        }
    }
}
