using Microsoft.EntityFrameworkCore;
using SVPP_Lab9.Domain.Entities;
using SVPP_Lab9.Domain.Interfaces;
using SVPPLab_9.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SVPPLab_9.DAL.Repositories
{
    public class EfStoresRepository : IRepository<Store>
    {
        private readonly DbSet<Store> stores;

        public EfStoresRepository(WholeContext wholeContext)
        {
            this.stores = wholeContext.Stores;
        }

        public void Create(Store entity)
        {
            stores.Add(entity); 
        }

        public bool Delete(int id)
        {
            var store = stores.Find(id);
            if (store == null) return false;
            stores.Remove(store);
            return true;
        }

        public IQueryable<Store> Find(Expression<Func<Store, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Store>> FindAsync(Expression<Func<Store, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Store Get(int id, params string[] includes)
        {
            IQueryable<Store> query = stores;
            foreach(var include in includes) query = query.Include(include);
            return query.First(g => g.StoreId == id);
        }

        public IQueryable<Store> GetAll()
        {
            return stores.AsQueryable();
        }

        public void Update(Store entity)
        {
            stores.Update(entity);
        }
    }
}
