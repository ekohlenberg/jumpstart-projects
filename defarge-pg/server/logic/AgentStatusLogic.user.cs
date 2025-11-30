
using System;


namespace defarge
{
    public interface IAgentStatusLogic
    {  
        // Generated methods
        List<AgentStatus> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<AgentStatusHistory> history(long id);
        AgentStatus get(long id);
        void insert(AgentStatus agentstatus);
        void update(long id, AgentStatus agentstatus);
        void put(AgentStatus agentstatus);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class AgentStatusLogic
    {
        protected AgentStatusLogic()
        {
           
        }
        
    }
}

