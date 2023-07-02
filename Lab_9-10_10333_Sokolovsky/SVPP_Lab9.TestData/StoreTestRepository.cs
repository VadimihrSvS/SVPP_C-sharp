using SVPP_Lab9.Domain.Entities;
using SVPP_Lab9.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SVPP_Lab9.TestData
{
    public class StoreTestRepository : IRepository<Store>
    {
        private readonly List<Store> stores;

        public StoreTestRepository(List<Store> stores)
        {
            this.stores = stores;
            SetupData();
        }
        private void SetupData()
        {
            var s = 1;
            Random rnd = new Random();
            string[] cities = {"Минск", "Гродно", "Брест", "Могилёв"};
            string[] addresses = { "Гагарина", "Первомайская", "Красноармейская", "Плеханова" };
            for(var i = 1; i <= 5; i++)
            {
                var store = new Store
                {
                    StoreId = i,
                    City = cities[rnd.Next(cities.Length - 1)],
                    Address = $"ул. {addresses[rnd.Next(addresses.Length - 1)]} д. {rnd.Next(100)} ",
                    OpenedIn = new DateTime(2010 + rnd.Next(10), rnd.Next(11) + 1, rnd.Next(28) + 1),
                    PostalCode = rnd.Next(100000, 224410),
                    Phone = $"+375 29 7{rnd.Next(100000, 999999)}"
                };
                var pcs = new List<PC>();
                string[] brands = {"Dell", "IBM", "Intel", "Siemens", "Avalon", "Hitachi", "Macintosh"};
                for (var j = 0; j < 10; j++)
                {
                    pcs.Add(new PC
                    {
                        PCId = j,
                        Brand = $"{brands[rnd.Next(brands.Length - 1)]}",
                        BuildDate = DateTime.Now - TimeSpan.FromDays(rnd.Next(600)),
                        Price = 3000 + rnd.Next(5000),

                    });
                    s++;
                }
                store.PCs = pcs;
                stores.Add(store);
            }
        }

        public void Create(Store entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Store> Find(Expression<Func<Store, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Store Get(int id, params string[] includes)
        {
            return stores.FirstOrDefault(g => g.StoreId == id);
        }

        public IQueryable<Store> GetAll()
        {
            return stores.AsQueryable();
        }

        public void Update(Store entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Store>> FindAsync(Expression<Func<Store, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
