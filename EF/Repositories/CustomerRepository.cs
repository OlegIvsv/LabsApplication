using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.EF;
using LabsApplication.UnitOfWork.EF.Models;
using LabsApplication.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, IRepository<CustomerData>
    {
        private Mapper mapper;

        public CustomerRepository(AppDbContext dbContext) : base(dbContext)
        {
            var config = new MapperConfiguration( cfg => 
                {
                    cfg.CreateMap<CustomerData, Customer>();
                    cfg.CreateMap<Customer, CustomerData>(); 
                });
            mapper = new Mapper(config);
        }

        public void Delete(CustomerData entity)
        {
            base.Delete(mapper.Map<Customer>(entity));
        }

        public CustomerData Get(int id)
        {
            return mapper.Map<CustomerData>(base.Get(id));
        }

        public void Insert(CustomerData entity)
        {
            base.Insert(mapper.Map<CustomerData, Customer>(entity));
        }

        public IList<CustomerData> List()
        {
            return base.List()
                .Select(c => mapper.Map<CustomerData>(c))
                .ToList();
        }

        public IList<CustomerData> List(Func<CustomerData, bool> expression)
        {
            return base.List()
                .Select(c => mapper.Map<CustomerData>(c))
                .Where(expression)
                .ToList();
        }

        public void Update(CustomerData entity)
        {
            base.Update(mapper.Map<Customer>(entity));
        }
    }
}
