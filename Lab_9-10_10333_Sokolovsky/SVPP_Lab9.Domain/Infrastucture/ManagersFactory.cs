using Microsoft.Extensions.Configuration;
using SVPP_Lab9.Business.Managers;
using SVPP_Lab9.Domain.Interfaces;
using SVPP_Lab9.TestData;
using SVPPLab_9.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPP_Lab9.Business.Infrastucture
{
    public class ManagersFactory
    { 
        private readonly IUnitOfWork unitOfWork;
        private readonly PCManager pcManager;
        private readonly StoreManager storeManager;

        public ManagersFactory()
        {
            unitOfWork = new TestUnitOfWork();
        }

        public ManagersFactory(string connStringName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connString = configuration
                .GetConnectionString(connStringName);
            unitOfWork = new EFUnitOfWork(connString);
        }

        public PCManager GetPcManager()
        {
            return pcManager ?? new PCManager(unitOfWork);
        }
        public StoreManager GetStoreManager()
        {
            return storeManager ?? new StoreManager(unitOfWork);
        }
    }
}
