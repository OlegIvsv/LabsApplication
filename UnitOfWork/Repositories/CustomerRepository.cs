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
    public class CustomerRepository : BaseRepository<Customer>, IRepository<CustomerDTO>
    {
        private Mapper mapper;

        public CustomerRepository(AppDbContext dbContext) : base(dbContext)
        {
            var config = new MapperConfiguration( cfg => 
                {
                    cfg.CreateMap<CustomerDTO, Customer>();
                    cfg.CreateMap<Customer, CustomerDTO>(); 
                });
            mapper = new Mapper(config);
        }

        public void Delete(CustomerDTO entity)
        {
            base.Delete(mapper.Map<Customer>(entity));
        }

        public CustomerDTO Get(int id)
        {
            return mapper.Map<CustomerDTO>(base.Get(id));
        }

        public void Insert(CustomerDTO entity)
        {
            base.Insert(mapper.Map<CustomerDTO, Customer>(entity));
        }

        public IList<CustomerDTO> List()
        {
            return base.List()
                .Select(c => mapper.Map<CustomerDTO>(c))
                .ToList();
        }

        public IList<CustomerDTO> List(Func<CustomerDTO, bool> expression)
        {
            return base.List()
                .Select(c => mapper.Map<CustomerDTO>(c))
                .Where(expression)
                .ToList();
        }

        public void Update(CustomerDTO entity)
        {
            base.Update(mapper.Map<Customer>(entity));
        }
    }
}
