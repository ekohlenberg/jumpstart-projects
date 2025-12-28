
using System;


namespace defarge
{
    public interface IServerNodeTypeLogic
    {  
        // Generated methods
        List<ServerNodeType> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<ServerNodeTypeHistory> history(long id);
        ServerNodeType get(long id);
        void insert(ServerNodeType servernodetype);
        void update(long id, ServerNodeType servernodetype);
        void put(ServerNodeType servernodetype);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ServerNodeTypeLogic
    {
        protected ServerNodeTypeLogic()
        {
           
        }
        
    }
}

