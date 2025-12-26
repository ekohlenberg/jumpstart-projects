using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class UomTest : BaseTest
    {
        public static void testInsert()
        {
            var uom = new Uom();


                    uom.name = Convert.ToString(BaseTest.getTestData(uom, "VARCHAR", TestDataType.random));
                    
                Logger.Info("Testing UomLogic insert: " + uom.ToString());
                UomLogic.Create().insert(uom);
                BaseTest.addLastId("uom", uom.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("uom");
            var uomView  = UomLogic.Create().get(lastId);

            Uom uom = new Uom(uomView);

                        uom.name = (string) BaseTest.getTestData(uom, "VARCHAR", TestDataType.random);
                    
                Logger.Info("Testing UomLogic update: " + uom.ToString());
                UomLogic.Create().update(lastId, uom);
                    }
    }
}
