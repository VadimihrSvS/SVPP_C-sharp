using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPP_Lab9.Domain.Entities
{
    public class PC
    {
        public int PCId { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public DateTime BuildDate { get; set; }
        public string ImageFileName { get; set; }
        public int StoreId { get; set; }
    }
}
