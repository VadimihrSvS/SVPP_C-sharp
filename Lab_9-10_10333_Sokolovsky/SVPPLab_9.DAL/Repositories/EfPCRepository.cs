using Microsoft.EntityFrameworkCore;
using SVPP_Lab9.Domain.Entities;
using SVPP_Lab9.Domain.Interfaces;
using SVPPLab_9.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVPPLab_9.DAL.Repositories
{
    public class EfPCRepository : IRepository<PC>
    {
        private readonly WholeContext context;
        private readonly DbSet<PC> pcs;

        public EfPCRepository(WholeContext context)
        {
            this.context = context;
            pcs = context.PCs;
        }

        public void Create(PC entity)
        {
            pcs.AddAsync(entity);
        }

        public bool Delete(int id)
        {
            var pc = pcs.Find(id);
            if (pc == null) return false;
            if(pc.StoreId > 0)
            {
                context.Stores
                    .Find(pc.StoreId)
                    .PCs
                    .Remove(pc);
            }
            pcs.Remove(pc);
            return true;
        }

        public IQueryable<PC> Find(Expression<Func<PC, bool>> predicate)
        {
            return pcs.Where(predicate);
        }

        public async Task<IEnumerable<PC>> FindAsync(Expression<Func<PC, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5000);
                return pcs.Where(predicate);
            });
        }

        public PC Get(int id, params string[] includes)
        {
            IQueryable<PC> query = pcs;
            foreach (var include in includes) query = query.Include(include);
            return query.First(s => s.PCId == id);
        }

        public IQueryable<PC> GetAll()
        {
            return pcs.AsQueryable();
        }

        public void Update(PC entity)
        {
            pcs.Update(entity);
        }
    }
}
