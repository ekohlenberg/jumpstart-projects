
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class AgentLogic : IAgentLogic
    {


        public static IAgentLogic Create()
        {
            var agent = new AgentLogic();

            var proxy = DispatchProxy.Create<IAgentLogic, Proxy<IAgentLogic>>();
            ((Proxy<IAgentLogic>)proxy).Initialize();
            ((Proxy<IAgentLogic>)proxy).Target = agent;
            ((Proxy<IAgentLogic>)proxy).DomainObj = "Agent";

            return proxy;
        }

        public  List<Agent> select()
        {
            return select<Agent>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing AgentLogic select<TBaseObject> List");

            List<TBaseObject> agents = select<TBaseObject>("core.agent-select");

            
            return agents;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing AgentLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> agents = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return agents;
        }

         public  List<AgentHistory> history(long id)
        {
            List<AgentHistory> agentHistory = DBPersist.ExecuteQueryByName<AgentHistory>("core.agent-get-history", new BaseObject() { { "id", id } });

            return agentHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing AgentLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.agent-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Agent get(long id)
        {
            Console.WriteLine($"Processing AgentLogic get ID={id}");

            Agent agent = DBPersist.select<Agent>($"SELECT * FROM core.agent WHERE id = {id}").FirstOrDefault();
            

            return agent;
        }

        public  void insert(Agent agent)
        {
            Console.WriteLine($"Processing AgentLogic insert: {agent}");

            agent.is_active = 1;

            DBPersist.insert(agent);
        }

        public  void put(Agent agent)
        {
            Console.WriteLine($"Processing AgentLogic put: {agent}");

            agent.is_active = 1;

            DBPersist.put(agent);
        }

        public  void update(long id, Agent agent)
        {
            Console.WriteLine($"Processing AgentLogic update: ID = {id}\n{agent}");

            agent.id = id;
            DBPersist.update(agent);
        }

        public  void delete(long id)
        {
            Agent agent = get(id);
            agent.is_active = 0;
            DBPersist.update(agent);
        }
    }
}
