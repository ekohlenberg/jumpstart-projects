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


                    category.parent_id = BaseTest.getLastId("Category");
                    
                    category.name = Convert.ToString(BaseTest.getTestData(category, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Category API insert: " + category.ToString());
                var createdCategory = await PostAsyncReturn("Category", category);
                BaseTest.addLastId("category", createdCategory.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var category = new Category();


                        category.parent_id = BaseTest.getLastId("Category");
                        
                        category.name = Convert.ToString(BaseTest.getTestData(category, "VARCHAR", TestDataType.random));
                        
                Console.WriteLine("Testing Category API insert (RWK only): " + category.ToString());
                var createdCategory = await PostAsyncReturn("Category", category);
                BaseTest.addLastId("category", createdCategory.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("category");
            var categoryView = await GetByIdAsync<CategoryView>("Category", lastId);
            var category = new Category(categoryView);


                            category.parent_id = BaseTest.getLastId("Category");
                        
                        category.name = (string) BaseTest.getTestData(category, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Category API update: " + category.ToString());
                await PutAsync("Category", lastId, category);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("category");
            var categoryView = await GetByIdAsync<CategoryView>("Category", lastId);
            var category = new Category(categoryView);


                            category.parent_id = BaseTest.getLastId("Category");
                        
                        category.name = (string) BaseTest.getTestData(category, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Category API update: " + category.ToString());
                await PutAsync("Category", lastId, category);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing Category API select (list):");
            
            try
            {
                var categoryList = await BaseTest.GetListAsync<Category>("Category");
                
                Console.WriteLine($"Retrieved {categoryList.Count} Category records");
                
                if (categoryList.Count > 0)
                {
                    Console.WriteLine("First record: " + categoryList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed Category records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < categoryList.Count; i++)
                    {
                        var category = categoryList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {category.id}");

                        Console.WriteLine($"  parent_id: {category.parent_id}");
                                
                        Console.WriteLine($"  name: {category.name}");
                                
                        Console.WriteLine($"  is_active: {category.is_active}");
                                
                        Console.WriteLine($"  created_by: {category.created_by}");
                                
                        Console.WriteLine($"  last_updated: {category.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {category.last_updated_by}");
                                
                        Console.WriteLine($"  version: {category.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", categoryList[0].id);
                }
                else
                {
                    Console.WriteLine("No Category records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing Category select: {ex.Message}");
                throw;
            }
        }
    }
}
