using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPP_Lab_8.Models
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            context.PCs.AddRange(new PC[] {
                new PC{ Id = 0, Brand = "Dell", Model = "Inspiron", Price = 233, Processor = "Snapdragon 660"} ,
                new PC{ Id = 1, Brand = "Dell", Model = "Inspiron", Price = 233, Processor = "Snapdragon 660"}
            });
        }
    }
}
