
using System;


namespace defarge
{
    public interface IServerNodeLogic
    {  
        // Generated methods
        List<ServerNode> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<ServerNodeHistory> history(long id);
        ServerNode get(long id);
        void insert(ServerNode servernode);
        void update(long id, ServerNode servernode);
        void put(ServerNode servernode);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ServerNodeLogic
    {
        protected ServerNodeLogic()
        {
           
        }
        
    }
}

