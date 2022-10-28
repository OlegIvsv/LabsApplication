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
using LabsApplication.DTOModels;

namespace LabsApplication.AdoNet
{
    public class AdoUnitOfWork : IUnitOfWork
    {
        private string connectionString;

        public IRepository<ProductDTO> Products { get; }

        public IRepository<CustomerDTO> Customers { get; }

        public IRepository<ProducerDTO> Producers { get; }

        public IRepository<OrderDTO> Orders { get; }


        public AdoUnitOfWork(string connectionString)
        {
            this.connectionString = connectionString;
            this.Products = new ProductRepositoryAdo(connectionString);
            this.Customers = new CustomerRepositoryAdo(connectionString);
            this.Orders = new OrderRepositoryAdo(connectionString);
            this.Producers = new ProducerRepositoryAdo(connectionString);
        }


        public IRepository<Product> ProductRepository { get; set; }

        public IRepository<Customer> CustomerRepository { get; set; }


        public void Complete()
        {
            // TODO: commit transaction
        }

        public void Dispose()
        {
            // TODO: dispose for trunsaction and connection
        }
    }
}
