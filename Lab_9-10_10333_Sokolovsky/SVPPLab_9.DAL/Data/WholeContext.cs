using Microsoft.EntityFrameworkCore;
using SVPP_Lab9.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPPLab_9.DAL.Data
{
    public class WholeContext: DbContext
    {
        public WholeContext(DbContextOptions<WholeContext> options)
            :base(options)
        {
        }

        public DbSet<PC> PCs { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
