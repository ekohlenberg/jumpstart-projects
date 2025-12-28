
using System;


namespace defarge
{
    public interface IServerNodeStatusLogic
    {  
        // Generated methods
        List<ServerNodeStatus> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<ServerNodeStatusHistory> history(long id);
        ServerNodeStatus get(long id);
        void insert(ServerNodeStatus servernodestatus);
        void update(long id, ServerNodeStatus servernodestatus);
        void put(ServerNodeStatus servernodestatus);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ServerNodeStatusLogic
    {
        protected ServerNodeStatusLogic()
        {
           
        }
        
    }
}

