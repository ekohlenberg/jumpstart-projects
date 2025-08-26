using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class UomTest : BaseTest
    {
        public static async Task testInsert()
        {
            var uom = new Uom();


                    uom.Name = Convert.ToString(BaseTest.getTestData(uom, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Uom API insert: " + uom.ToString());
                await PostAsync("Uom", uom);
                BaseTest.addLastId("uom", uom.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("Uom");
            var uom = await GetByIdAsync<Uom>("Uom", lastId);


                        uom.Name = (string) BaseTest.getTestData(uom, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Uom API update: " + uom.ToString());
                await PutAsync("Uom", lastId, uom);
                    }
    }
}
