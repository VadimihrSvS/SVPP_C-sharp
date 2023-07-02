using SVPP_Lab9.Domain.Entities;
using SVPP_Lab9.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPP_Lab9.TestData
{
    
    public class TestUnitOfWork : IUnitOfWork
    {
        private IRepository<Store> storesRepository;
        private IRepository<PC> pcRepository;
        private List<Store> storesList;
        private List<PC> pcList;

        public TestUnitOfWork()
        {
            storesList = new List<Store>();
            pcList = new List<PC>();
            storesRepository = new StoreTestRepository(storesList);
            foreach (var store in storesList) {
                pcList.AddRange(store.PCs);
            }
            pcRepository = new PCTestRepository(pcList);

        }

        public IRepository<Store> StoreRepository => storesRepository;

        public IRepository<PC> PCRepository => pcRepository;

        public void SaveChanges()
        {

        }
    }
}
