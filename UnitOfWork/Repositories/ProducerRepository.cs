using LabsApplication.UnitOfWork.EF.Models;
using LabsApplication.UnitOfWork.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LabsApplication.UnitOfWork.Interfaces;

namespace LabsApplication.UnitOfWork.Repositories
{
    public class ProducerRepository : BaseRepository<Producer>, IRepository<ProducerDTO>
    {
        private Mapper mapper;

        public ProducerRepository(AppDbContext dbContext) : base(dbContext)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProducerDTO, Producer>();
                cfg.CreateMap<Producer, ProducerDTO>();
            });
            mapper = new Mapper(config);
        }



        public void Delete(ProducerDTO entity)
        {
            base.BaseDelete(mapper.Map<Producer>(entity));
        }

        public ProducerDTO Get(int id)
        {
            return mapper.Map<ProducerDTO>(base.BaseGet(id));
        }

        public void Insert(ProducerDTO entity)
        {
            base.BaseInsert(mapper.Map<ProducerDTO, Producer>(entity));
        }

        public IList<ProducerDTO> List()
        {
            return base.BaseList()
                .Select(c => mapper.Map<ProducerDTO>(c))
                .ToList();
        }

        public IList<ProducerDTO> List(Func<ProducerDTO, bool> expression)
        {
            return base.BaseList()
                .Select(c => mapper.Map<Producer, ProducerDTO>(c))
                .Where(expression)
                .ToList();
        }

        public void Update(ProducerDTO entity)
        {
            base.Update(mapper.Map<ProducerDTO, Producer>(entity));
        }
    }
}
