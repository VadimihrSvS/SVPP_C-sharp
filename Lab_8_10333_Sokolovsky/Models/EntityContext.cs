using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPP_Lab_8.Models
{
    public class EntityContext : DbContext
    {
        public EntityContext(): base("DefaultConnection")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
        public DbSet<PC> PCs { get; set; }
    }
}
