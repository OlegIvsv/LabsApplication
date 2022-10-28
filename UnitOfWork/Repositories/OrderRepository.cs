using AutoMapper;
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
    public class OrderRepository : BaseRepository<Order>, IRepository<OrderDTO>
    {
        private Mapper mapper;

        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<Order, OrderDTO>();
            });
            mapper = new Mapper(config);
        }

        public void Delete(OrderDTO entity)
        {
            base.BaseDelete(mapper.Map<OrderDTO, Order>(entity));
        }

        public OrderDTO Get(int id)
        {
            return mapper.Map<Order, OrderDTO>(base.BaseGet(id));
        }

        public void Insert(OrderDTO entity)
        {
            base.BaseInsert(mapper.Map<OrderDTO, Order>(entity));
        }

        public IList<OrderDTO> List()
        {
            return base.BaseList()
                .Select(c => mapper.Map<Order, OrderDTO>(c))
                .ToList();
        }

        public IList<OrderDTO> List(Func<OrderDTO, bool> expression)
        {
            return base.BaseList()
                .Select(c => mapper.Map<Order, OrderDTO>(c))
                .Where(expression)
                .ToList();
        }

        public void Update(OrderDTO entity)
        {
            base.Update(mapper.Map<OrderDTO, Order>(entity));
        }
    }
}
