using LabsApplication.UnitOfWork.EF;
using LabsApplication.UnitOfWork.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
