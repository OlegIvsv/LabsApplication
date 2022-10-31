using LabsApplication.UnitOfWork.EF.Models;
using LabsApplication.UnitOfWork.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LabsApplication.UnitOfWork.Interfaces;
using LabsApplication.DTOModels;

namespace LabsApplication.UnitOfWork.Repositories
{
    public class ProducerRepository : BaseRepository<Producer>, IRepository<ProducerData>
    {
        private Mapper mapper;

        public ProducerRepository(AppDbContext dbContext) : base(dbContext)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProducerData, Producer>();
                cfg.CreateMap<Producer, ProducerData>();
            });
            mapper = new Mapper(config);
        }



        public void Delete(ProducerData entity)
        {
            base.Delete(mapper.Map<Producer>(entity));
        }

        public ProducerData Get(int id)
        {
            return mapper.Map<ProducerData>(base.Get(id));
        }

        public void Insert(ProducerData entity)
        {
            base.Insert(mapper.Map<ProducerData, Producer>(entity));
        }

        public IList<ProducerData> List()
        {
            return base.List()
                .Select(c => mapper.Map<ProducerData>(c))
                .ToList();
        }

        public IList<ProducerData> List(Func<ProducerData, bool> expression)
        {
            return base.List()
                .Select(c => mapper.Map<Producer, ProducerData>(c))
                .Where(expression)
                .ToList();
        }

        public void Update(ProducerData entity)
        {
            var entityToUpdate = dbContext.Producers.Find(entity.Id);
            mapper.Map(entity, entityToUpdate);
            base.Update(entityToUpdate);
        }
    }
}
