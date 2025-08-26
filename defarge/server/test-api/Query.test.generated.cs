using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class QueryTest : BaseTest
    {
        public static async Task testInsert()
        {
            var query = new Query();


                    query.name = Convert.ToString(BaseTest.getTestData(query, "VARCHAR", TestDataType.random));
                    
                    query.sql_text = Convert.ToString(BaseTest.getTestData(query, "VARCHAR", TestDataType.random));
                    
                    query.description = Convert.ToString(BaseTest.getTestData(query, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Query API insert: " + query.ToString());
                await PostAsync("Query", query);
                BaseTest.addLastId("query", query.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("Query");
            var query = await GetByIdAsync<Query>("Query", lastId);


                        query.name = (string) BaseTest.getTestData(query, "VARCHAR", TestDataType.random);
                    
                        query.sql_text = (string) BaseTest.getTestData(query, "VARCHAR", TestDataType.random);
                    
                        query.description = (string) BaseTest.getTestData(query, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Query API update: " + query.ToString());
                await PutAsync("Query", lastId, query);
                    }
    }
}
