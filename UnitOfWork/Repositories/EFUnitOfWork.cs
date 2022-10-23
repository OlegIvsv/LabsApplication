using LabsApplication.UnitOfWork.EF;
using LabsApplication.UnitOfWork.EF.Models;
using LabsApplication.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AppDbContext dbContext;

        public EFUnitOfWork(string connectionString)
        {
            DbContextOptionsBuilder builder = new();
            builder.UseSqlServer(connectionString);
            var options = builder.Options;

            this.dbContext = new AppDbContext(options);
            this.ProductRepository = new ProductRepository(dbContext);
            this.CustomerRepository = new CustomerRepository(dbContext);
        }


        public IRepository<Product> ProductRepository { get; set; }

        public IRepository<Customer> CustomerRepository { get; set; }


        public void Complete()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
