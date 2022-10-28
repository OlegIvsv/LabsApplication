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
        IRepository<ProductDTO> Products{ get; }

        IRepository<CustomerDTO> Customers { get; }

        IRepository<OrderDTO> Orders { get; }
        
        IRepository<ProducerDTO> Producers { get; }

        void Complete();
    }
}
