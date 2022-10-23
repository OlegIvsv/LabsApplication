using LabsApplication.UnitOfWork.EF.Models;
using LabsApplication.UnitOfWork.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.Repositories
{
    public class ProducerRepository : BaseRepository<Producer>
    {
        public ProducerRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
