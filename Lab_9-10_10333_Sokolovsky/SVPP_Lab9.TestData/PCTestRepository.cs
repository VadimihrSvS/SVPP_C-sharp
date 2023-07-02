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
    public class PCTestRepository : IRepository<PC>
    {

        private readonly List<PC> PCs;

        public PCTestRepository(List<PC> pCs)
        {
            PCs = pCs;
        }

        public void Create(PC entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PC> Find(Expression<Func<PC, bool>> predicate)
        {
            Func<PC, bool> filter = predicate.Compile();
            return PCs.Where(filter).AsQueryable(); 
        }

        public Task<IEnumerable<PC>> FindAsync(Expression<Func<PC, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public PC Get(int id, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PC> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(PC entity)
        {
            throw new NotImplementedException();
        }
    }
}
