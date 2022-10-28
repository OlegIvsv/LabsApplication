using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entity);

        void Delete(int id);

        TEntity Get(int id);

        void Insert(TEntity entity);

        IList<TEntity> List();

        IList<TEntity> List(Func<TEntity, bool> expression);

        void Update(TEntity entity);
    }
}
