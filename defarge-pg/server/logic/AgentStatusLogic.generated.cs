
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class AgentStatusLogic : IAgentStatusLogic
    {


        public static IAgentStatusLogic Create()
        {
            var agentstatus = new AgentStatusLogic();

            var proxy = DispatchProxy.Create<IAgentStatusLogic, Proxy<IAgentStatusLogic>>();
            ((Proxy<IAgentStatusLogic>)proxy).Initialize();
            ((Proxy<IAgentStatusLogic>)proxy).Target = agentstatus;
            ((Proxy<IAgentStatusLogic>)proxy).DomainObj = "AgentStatus";

            return proxy;
        }

        public  List<AgentStatus> select()
        {
            return select<AgentStatus>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing AgentStatusLogic select<TBaseObject> List");

            List<TBaseObject> agentstatuss = select<TBaseObject>("core.agent_status-select");

            
            return agentstatuss;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing AgentStatusLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> agentstatuss = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return agentstatuss;
        }

         public  List<AgentStatusHistory> history(long id)
        {
            List<AgentStatusHistory> agentstatusHistory = DBPersist.ExecuteQueryByName<AgentStatusHistory>("core.agent_status-get-history", new BaseObject() { { "id", id } });

            return agentstatusHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing AgentStatusLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.agent_status-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  AgentStatus get(long id)
        {
            Console.WriteLine($"Processing AgentStatusLogic get ID={id}");

            AgentStatus agentstatus = DBPersist.select<AgentStatus>($"SELECT * FROM core.agent_status WHERE id = {id}").FirstOrDefault();
            

            return agentstatus;
        }

        public  void insert(AgentStatus agentstatus)
        {
            Console.WriteLine($"Processing AgentStatusLogic insert: {agentstatus}");

            agentstatus.is_active = 1;

            DBPersist.insert(agentstatus);
        }

        public  void put(AgentStatus agentstatus)
        {
            Console.WriteLine($"Processing AgentStatusLogic put: {agentstatus}");

            agentstatus.is_active = 1;

            DBPersist.put(agentstatus);
        }

        public  void update(long id, AgentStatus agentstatus)
        {
            Console.WriteLine($"Processing AgentStatusLogic update: ID = {id}\n{agentstatus}");

            agentstatus.id = id;
            DBPersist.update(agentstatus);
        }

        public  void delete(long id)
        {
            AgentStatus agentstatus = get(id);
            agentstatus.is_active = 0;
            DBPersist.update(agentstatus);
        }
    }
}
