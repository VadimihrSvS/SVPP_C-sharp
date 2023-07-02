using SVPP_Lab9.Domain.Entities;
using SVPP_Lab9.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPP_Lab9.Business.Managers
{
    public class BaseManager
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IRepository<PC> pcRepository;
        protected readonly IRepository<Store> storeRepository;

        public BaseManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            pcRepository = unitOfWork.PCRepository;
            storeRepository = unitOfWork.StoreRepository;
        }
    }
}
