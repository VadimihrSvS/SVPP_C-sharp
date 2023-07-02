using SVPP_Lab9.Business.Managers;
using SVPP_Lab9.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPP_Lab9.Business.Infrastucture
{
    public static class DbTestData
    {
        public static void SetupData(StoreManager storeManager)
        {
            storeManager.AddRange(new List<Store>
            {
                new Store
                {
                    Address = "ул. Есенина",
                    City = "Москва",
                    OpenedIn = new DateTime(2020, 1, 2),
                    PostalCode = 222424,
                    Phone = "+88007753535"
                },
                new Store
                {
                    Address = "ул. Кижеватова",
                    City = "Минск",
                    OpenedIn = new DateTime(2019, 11, 20),
                    PostalCode = 222524,
                    Phone = "+375175535353"
                }
            });
            var stores = storeManager.Stores.ToArray();
            storeManager.AddPCToStore(
                new PC
                {
                    Brand = "IBM",
                    BuildDate = new DateTime(2019, 11, 11),
                    Price = 3000,
                    ImageFileName = "1.png"
                }, stores[0].StoreId);
            storeManager.AddPCToStore(
                new PC
                {
                    Brand = "Dell",
                    BuildDate = new DateTime(2019, 11, 11),
                    Price = 4000,
                    ImageFileName = "2.jpg"

                }, stores[0].StoreId);
            storeManager.AddPCToStore(
                new PC
                {
                    Brand = "Macintosh",
                    BuildDate = new DateTime(2019, 11, 11),
                    Price = 5000,
                    ImageFileName = "3.png"

                }, stores[1].StoreId);
            storeManager.AddPCToStore(
                new PC
                {
                    Brand = "Siemens",
                    BuildDate = new DateTime(2019, 11, 11),
                    Price = 6000,
                    ImageFileName = "4.jpg"
                }, stores[1].StoreId);
        }
    }
}
