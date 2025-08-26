using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class EventServiceTest : BaseTest
    {
        public static async Task testInsert()
        {
            var eventservice = new EventService();


                    eventservice.event_type = Convert.ToString(BaseTest.getTestData(eventservice, "VARCHAR", TestDataType.random));
                    
                    eventservice.objectname_filter = Convert.ToString(BaseTest.getTestData(eventservice, "VARCHAR", TestDataType.random));
                    
                    eventservice.methodname_filter = Convert.ToString(BaseTest.getTestData(eventservice, "VARCHAR", TestDataType.random));
                    
                    eventservice.script_id = BaseTest.getLastId("script");
                    
                Console.WriteLine("Testing EventService API insert: " + eventservice.ToString());
                await PostAsync("EventService", eventservice);
                BaseTest.addLastId("event_service", eventservice.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("EventService");
            var eventservice = await GetByIdAsync<EventService>("EventService", lastId);


                        eventservice.event_type = (string) BaseTest.getTestData(eventservice, "VARCHAR", TestDataType.random);
                    
                        eventservice.objectname_filter = (string) BaseTest.getTestData(eventservice, "VARCHAR", TestDataType.random);
                    
                        eventservice.methodname_filter = (string) BaseTest.getTestData(eventservice, "VARCHAR", TestDataType.random);
                    
                            eventservice.script_id = BaseTest.getLastId("script");
                        
                Console.WriteLine("Testing EventService API update: " + eventservice.ToString());
                await PutAsync("EventService", lastId, eventservice);
                    }
    }
}
