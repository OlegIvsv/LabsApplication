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
    public class OrderRepository : BaseRepository<Order>, IRepository<OrderData>
    {
        private Mapper mapper;

        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderData, Order>();
                cfg.CreateMap<Order, OrderData>();
            });
            mapper = new Mapper(config);
        }

        public void Delete(OrderData entity)
        {
            base.Delete(mapper.Map<OrderData, Order>(entity));
        }

        public OrderData Get(int id)
        {
            return mapper.Map<Order, OrderData>(base.Get(id));
        }

        public void Insert(OrderData entity)
        {
            base.Insert(mapper.Map<OrderData, Order>(entity));
        }

        public IList<OrderData> List()
        {
            return base.List()
                .Select(c => mapper.Map<Order, OrderData>(c))
                .ToList();
        }

        public IList<OrderData> List(Func<OrderData, bool> expression)
        {
            return base.List()
                .Select(c => mapper.Map<Order, OrderData>(c))
                .Where(expression)
                .ToList();
        }

        public void Update(OrderData entity)
        {
            base.Update(mapper.Map<OrderData, Order>(entity));
        }
    }
}
