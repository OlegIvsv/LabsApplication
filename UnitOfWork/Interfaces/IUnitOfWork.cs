using LabsApplication.UnitOfWork.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products{ get; }

        IRepository<Customer> Customers { get; }

        void Complete();
    }
}
