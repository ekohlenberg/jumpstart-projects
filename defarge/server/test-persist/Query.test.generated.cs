using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class QueryTest : BaseTest
    {
        public static void testInsert()
        {
            var query = new Query();


                    query.name = Convert.ToString(BaseTest.getTestData(query, "VARCHAR", TestDataType.random));
                    
                    query.sql_text = Convert.ToString(BaseTest.getTestData(query, "VARCHAR", TestDataType.random));
                    
                    query.description = Convert.ToString(BaseTest.getTestData(query, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing QueryLogic insert: " + query.ToString());
                QueryLogic.Create().insert(query);
                BaseTest.addLastId("query", query.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Query");
            var query = QueryLogic.Create().get(lastId);


                        query.name = (string) BaseTest.getTestData(query, "VARCHAR", TestDataType.random);
                    
                        query.sql_text = (string) BaseTest.getTestData(query, "VARCHAR", TestDataType.random);
                    
                        query.description = (string) BaseTest.getTestData(query, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing QueryLogic update: " + query.ToString());
                QueryLogic.Create().update(lastId, query);
                    }
    }
}
