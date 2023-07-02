using SVPP_Lab9.Domain.Entities;
using SVPP_Lab9.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SVPP_Lab9.Business.Managers
{
    public class StoreManager : BaseManager
    {
        public StoreManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        /// <summary>
        /// Общий список магазинов
        /// </summary>
        public IEnumerable<Store> Stores
        {
            get => storeRepository.GetAll();
        }
        public Store GetById(int id) => storeRepository.Get(id);
        // Создание группы
        public Store CreateGroup(Store store)
        {
            storeRepository.Create(store);
            unitOfWork.SaveChanges();
            return store;
        }
        /// <summary>
        /// Добавление магазинов из списка
        /// </summary>
        /// <param name="stores"></param>
        public void AddRange(List<Store> stores)
        {
            stores.ForEach(g => storeRepository.Create(g));
            unitOfWork.SaveChanges();
        }
        /// <summary>
        /// Удаление магазина
        /// </summary>
        /// <param name="id">Id удаляемого магазина</param>/// <returns></returns>
        public bool DeleteStore(int id)
        {
            var result =storeRepository.Delete(id);
            if (!result) return false;
            unitOfWork.SaveChanges();
            return true;
        }
        /// <summary>
        /// Редактирование магазина
        /// </summary>
        /// <param name="store">Обновленный объект магазина</param>
        public void UpdateStore(Store store)
        {
            storeRepository.Update(store);
            unitOfWork.SaveChanges();
        }
        /// <summary>
        /// Добавление компьютера в магазин
        /// </summary>
        /// <param name="PC">Добавляемый объект</param>
        /// <param name="storeId">Id маназина</param>
        /// <returns></returns>
public void AddPCToStore(PC pc, int storeId)
        {
            var store = storeRepository.Get(storeId);
            pc.StoreId = storeId;
            if (pc.PCId <= 0)
                pcRepository.Create(pc);
            else pcRepository.Update(pc);
            unitOfWork.SaveChanges();
        }
        /// <summary>
        /// Удаление компьютера из магазина
        /// </summary>
        /// <param name="pc">Удаляемый объект</param>
        /// <param name="storeId">Id магазина</param>
        public void RemovePCFromStore(PC pc, int
        storeId)
        {
            var store = storeRepository.Get(storeId, "Students");
            store.PCs.Remove(pc); 
            storeRepository.Update(store);
            pcRepository.Update(pc);
            unitOfWork.SaveChanges();
        }
        /// <summary>
        /// Получение списка компьютеров в магазине
        /// </summary>
        /// <param name="storeId">Id магазина</param>
        /// <returns></returns>
        public ICollection<PC> GetPCsOfStore(int storeId) =>
        pcRepository
        .Find(s => s.StoreId == storeId)
        .ToList();

        public async Task<IEnumerable<PC>> GetPCOfStoreAsync(int storeId) =>
            await pcRepository.FindAsync(s => s.StoreId == storeId);
    }
}
        
 
