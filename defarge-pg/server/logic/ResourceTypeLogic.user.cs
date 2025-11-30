
using System;


namespace defarge
{
    public interface IResourceTypeLogic
    {  
        // Generated methods
        List<ResourceType> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<ResourceTypeHistory> history(long id);
        ResourceType get(long id);
        void insert(ResourceType resourcetype);
        void update(long id, ResourceType resourcetype);
        void put(ResourceType resourcetype);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ResourceTypeLogic
    {
        protected ResourceTypeLogic()
        {
           
        }
        
    }
}

