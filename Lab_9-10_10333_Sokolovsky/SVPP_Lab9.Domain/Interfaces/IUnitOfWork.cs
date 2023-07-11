using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVPP_Lab9.Domain.Entities;

namespace SVPP_Lab9.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<PC> PCRepository { get; }
        IRepository<Store> StoreRepository { get; }
        void SaveChanges();
    }
}
