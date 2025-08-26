using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class CategoryTest : BaseTest
    {
        public static async Task testInsert()
        {
            var category = new Category();


                    category.parent_id = BaseTest.getLastId("category");
                    
                    category.name = Convert.ToString(BaseTest.getTestData(category, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Category API insert: " + category.ToString());
                await PostAsync("Category", category);
                BaseTest.addLastId("category", category.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("Category");
            var category = await GetByIdAsync<Category>("Category", lastId);


                            category.parent_id = BaseTest.getLastId("category");
                        
                        category.name = (string) BaseTest.getTestData(category, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Category API update: " + category.ToString());
                await PutAsync("Category", lastId, category);
                    }
    }
}
