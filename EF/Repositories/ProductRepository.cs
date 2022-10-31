using AutoMapper;
using LabsApplication.DTOModels;
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
    public class ProductRepository : BaseRepository<Product>, IRepository<ProductData>
    {
        private Mapper mapper;

        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductData, Product>();
                cfg.CreateMap<Product, ProductData>();
            });
            mapper = new Mapper(config);
        }


        public void Delete(ProductData entity)
        {
            base.Delete(mapper.Map<Product>(entity));
        }

        public void Delete(int id)
        {
            base.Delete(id);
        }

        public ProductData Get(int id)
        {
            return mapper.Map<ProductData>(base.Get(id));
        }

        public void Insert(ProductData entity)
        {
            base.Insert(mapper.Map<ProductData, Product>(entity));
        }

        public IList<ProductData> List()
        {
            return base.List()
                .Select(c => mapper.Map<ProductData>(c))
                .ToList();
        }

        public IList<ProductData> List(Func<ProductData, bool> expression)
        {
            return base.List()
                .Select(c => mapper.Map<Product, ProductData>(c))
                .Where(expression)
                .ToList();
        }

        public void Update(ProductData entity)
        {
            var entityToUpdate = dbContext.Products.Find(entity.Id);
            mapper.Map(entity, entityToUpdate);
            base.Update(entityToUpdate);
        }
    }
}
