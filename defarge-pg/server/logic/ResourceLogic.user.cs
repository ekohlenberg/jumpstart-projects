
using System;


namespace defarge
{
    public interface IResourceLogic
    {  
        // Generated methods
        List<Resource> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<ResourceHistory> history(long id);
        Resource get(long id);
        void insert(Resource resource);
        void update(long id, Resource resource);
        void put(Resource resource);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ResourceLogic
    {
        protected ResourceLogic()
        {
           
        }
        
    }
}

