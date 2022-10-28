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
    public class ProductRepository : BaseRepository<Product>, IRepository<ProductDTO>
    {
        private Mapper mapper;

        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<Product, ProductDTO>();
            });
            mapper = new Mapper(config);
        }


        public void Delete(ProductDTO entity)
        {
            base.Delete(mapper.Map<Product>(entity));
        }

        public void Delete(int id)
        {
            base.Delete(id);
        }

        public ProductDTO Get(int id)
        {
            return mapper.Map<ProductDTO>(base.Get(id));
        }

        public void Insert(ProductDTO entity)
        {
            base.Insert(mapper.Map<ProductDTO, Product>(entity));
        }

        public IList<ProductDTO> List()
        {
            return base.List()
                .Select(c => mapper.Map<ProductDTO>(c))
                .ToList();
        }

        public IList<ProductDTO> List(Func<ProductDTO, bool> expression)
        {
            return base.List()
                .Select(c => mapper.Map<Product, ProductDTO>(c))
                .Where(expression)
                .ToList();
        }

        public void Update(ProductDTO entity)
        {
            base.Update(mapper.Map<ProductDTO, Product>(entity));
        }
    }
}
