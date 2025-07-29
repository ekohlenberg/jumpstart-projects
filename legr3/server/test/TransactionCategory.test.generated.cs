using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class TransactionCategoryTest : BaseTest
    {
        public static void testInsert()
        {
            var transactioncategory = new TransactionCategory();


                    transactioncategory.transaction_id = BaseTest.getLastId("transaction");
                    
                    transactioncategory.category_id = BaseTest.getLastId("category");
                    
                Console.WriteLine("Testing TransactionCategoryLogic insert: " + transactioncategory.ToString());
                TransactionCategoryLogic.Create().insert(transactioncategory);
                BaseTest.addLastId("transaction_category", transactioncategory.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("TransactionCategory");
            var transactioncategory = TransactionCategoryLogic.Create().get(lastId);


                            transactioncategory.transaction_id = BaseTest.getLastId("transaction");
                        
                            transactioncategory.category_id = BaseTest.getLastId("category");
                        
                Console.WriteLine("Testing TransactionCategoryLogic update: " + transactioncategory.ToString());
                TransactionCategoryLogic.Create().update(lastId, transactioncategory);
                    }
    }
}
