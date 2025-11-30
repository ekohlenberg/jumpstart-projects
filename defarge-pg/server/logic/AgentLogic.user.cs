
using System;


namespace defarge
{
    public interface IAgentLogic
    {  
        // Generated methods
        List<Agent> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<AgentHistory> history(long id);
        Agent get(long id);
        void insert(Agent agent);
        void update(long id, Agent agent);
        void put(Agent agent);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class AgentLogic
    {
        protected AgentLogic()
        {
           
        }
        
    }
}

