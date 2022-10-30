﻿using LabsApplication.DTOModels;
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

        public IRepository<ProductData> Products { get; }

        public IRepository<CustomerData> Customers{ get; }

        public IRepository<ProducerData> Producers { get; }

        public IRepository<OrderData> Orders { get; }


        public EFUnitOfWork(string connectionString)
        {
            DbContextOptionsBuilder builder = new();
            builder.UseSqlServer(connectionString);
            var options = builder.Options;

            this.dbContext = new AppDbContext(options);
            this.Products = new ProductRepository(dbContext);
            this.Customers = new CustomerRepository(dbContext);
            this.Producers = new ProducerRepository(dbContext);
            this.Customers = new CustomerRepository(dbContext);
        }


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
