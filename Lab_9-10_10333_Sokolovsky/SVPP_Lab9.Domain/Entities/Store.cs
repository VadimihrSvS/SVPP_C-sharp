using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPP_Lab9.Domain.Entities
{
    public class Store
    {
        public int StoreId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime OpenedIn { get; set; }

        public string Phone { get; set; }
        public int PostalCode { get; set; }
        public ICollection<PC> PCs { get; set; }
    }
}
