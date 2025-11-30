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


                    uom.name = Convert.ToString(BaseTest.getTestData(uom, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Uom API insert: " + uom.ToString());
                var createdUom = await PostAsyncReturn("Uom", uom);
                BaseTest.addLastId("uom", createdUom.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var uom = new Uom();


                        uom.name = Convert.ToString(BaseTest.getTestData(uom, "VARCHAR", TestDataType.random));
                        
                Console.WriteLine("Testing Uom API insert (RWK only): " + uom.ToString());
                var createdUom = await PostAsyncReturn("Uom", uom);
                BaseTest.addLastId("uom", createdUom.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("uom");
            var uomView = await GetByIdAsync<UomView>("Uom", lastId);
            var uom = new Uom(uomView);


                        uom.name = (string) BaseTest.getTestData(uom, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Uom API update: " + uom.ToString());
                await PutAsync("Uom", lastId, uom);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("uom");
            var uomView = await GetByIdAsync<UomView>("Uom", lastId);
            var uom = new Uom(uomView);


                        uom.name = (string) BaseTest.getTestData(uom, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Uom API update: " + uom.ToString());
                await PutAsync("Uom", lastId, uom);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing Uom API select (list):");
            
            try
            {
                var uomList = await BaseTest.GetListAsync<Uom>("Uom");
                
                Console.WriteLine($"Retrieved {uomList.Count} Uom records");
                
                if (uomList.Count > 0)
                {
                    Console.WriteLine("First record: " + uomList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed Uom records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < uomList.Count; i++)
                    {
                        var uom = uomList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {uom.id}");

                        Console.WriteLine($"  name: {uom.name}");
                                
                        Console.WriteLine($"  is_active: {uom.is_active}");
                                
                        Console.WriteLine($"  created_by: {uom.created_by}");
                                
                        Console.WriteLine($"  last_updated: {uom.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {uom.last_updated_by}");
                                
                        Console.WriteLine($"  version: {uom.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", uomList[0].id);
                }
                else
                {
                    Console.WriteLine("No Uom records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing Uom select: {ex.Message}");
                throw;
            }
        }
    }
}
