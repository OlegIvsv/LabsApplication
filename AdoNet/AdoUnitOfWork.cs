using LabsApplication.UnitOfWork.EF.Models;
using LabsApplication.UnitOfWork.EF;
using LabsApplication.UnitOfWork.Interfaces;
using LabsApplication.UnitOfWork.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.AdoNet
{
    public class AdoUnitOfWork : IUnitOfWork
    {
        private string connectionString;

        public IRepository<Product> Products { get; }

        public IRepository<Customer> Customers { get; }

        public AdoUnitOfWork(string connectionString)
        {
            this.connectionString = connectionString;
            this.Products = new ProductRepositoryAdo(connectionString);
            this.Customers = new CustomerRepositoryAdo(connectionString);
        }


        public IRepository<Product> ProductRepository { get; set; }

        public IRepository<Customer> CustomerRepository { get; set; }


        public void Complete()
        {
        }

        public void Dispose()
        {
        }
    }
}
