using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.Interfaces
{
    public interface IAppDatabase : IDisposable
    {
        IRepository<ProductData> Products{ get; }

        IRepository<CustomerData> Customers { get; }

        IRepository<OrderData> Orders { get; }
        
        IRepository<ProducerData> Producers { get; }

        void Complete();
    }
}
