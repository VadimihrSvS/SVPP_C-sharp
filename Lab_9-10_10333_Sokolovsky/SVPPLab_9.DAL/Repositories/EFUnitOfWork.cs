using Microsoft.EntityFrameworkCore;
using SVPP_Lab9.Domain.Entities;
using SVPP_Lab9.Domain.Interfaces;
using SVPPLab_9.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPPLab_9.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly WholeContext context;
        private IRepository<PC> pcRepository;
        private IRepository<Store> storeRepository;

        public EFUnitOfWork(string connectionString)
        {
            var options = new DbContextOptionsBuilder<WholeContext>()
                .UseSqlServer(connectionString)
                .Options;
            context = new WholeContext(options);
            context.Database.EnsureCreated();
                
        }

        public IRepository<Store> StoreRepository => storeRepository ?? new EfStoresRepository(context);

        public IRepository<PC> PCRepository => pcRepository ?? new EfPCRepository(context);

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
