using SVPP_Lab9.Domain.Entities;
using SVPP_Lab9.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SVPP_Lab9.Business.Managers
{
    public class PCManager : BaseManager
    {
        public PCManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region basic CRUD operations
        public bool DeletePC(int id)
        {
            var result = pcRepository.Delete(id);
            if (!result) return false;
            unitOfWork.SaveChanges();
            return true;
        }

        public IEnumerable<PC> FindPC(Expression<Func<PC, bool>> predicate) => 
            pcRepository.Find(predicate);

        public PC GetPCById(int id) => pcRepository.Get(id);
        public IEnumerable<PC> GetAllPCs() => pcRepository.GetAll();
        public void UpdatePC(PC pc)
        {
            pcRepository.Update(pc);
            unitOfWork.SaveChanges();
        }
        #endregion
    }
}
