
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ResourceTypeLogic : IResourceTypeLogic
    {


        public static IResourceTypeLogic Create()
        {
            var resourcetype = new ResourceTypeLogic();

            var proxy = DispatchProxy.Create<IResourceTypeLogic, Proxy<IResourceTypeLogic>>();
            ((Proxy<IResourceTypeLogic>)proxy).Initialize();
            ((Proxy<IResourceTypeLogic>)proxy).Target = resourcetype;
            ((Proxy<IResourceTypeLogic>)proxy).DomainObj = "ResourceType";

            return proxy;
        }

        public  List<ResourceType> select()
        {
            return select<ResourceType>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing ResourceTypeLogic select<TBaseObject> List");

            List<TBaseObject> resourcetypes = select<TBaseObject>("app.resource_type-select");

            
            return resourcetypes;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ResourceTypeLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> resourcetypes = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return resourcetypes;
        }

         public  List<ResourceTypeHistory> history(long id)
        {
            List<ResourceTypeHistory> resourcetypeHistory = DBPersist.ExecuteQueryByName<ResourceTypeHistory>("app.resource_type-get-history", new BaseObject() { { "id", id } });

            return resourcetypeHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ResourceTypeLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "app.resource_type-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  ResourceType get(long id)
        {
            Logger.Debug($"Processing ResourceTypeLogic get ID={id}");

            ResourceType resourcetype = DBPersist.select<ResourceType>($"SELECT * FROM app.resource_type WHERE id = {id}").FirstOrDefault();
            

            return resourcetype;
        }

        public  void insert(ResourceType resourcetype)
        {
            Logger.Debug($"Processing ResourceTypeLogic insert: {resourcetype}");

            resourcetype.is_active = 1;

            DBPersist.insert(resourcetype);
        }

        public  void put(ResourceType resourcetype)
        {
            Logger.Debug($"Processing ResourceTypeLogic put: {resourcetype}");

            resourcetype.is_active = 1;

            DBPersist.put(resourcetype);
        }

        public  void update(long id, ResourceType resourcetype)
        {
            Logger.Debug($"Processing ResourceTypeLogic update: ID = {id}\n{resourcetype}");

            resourcetype.id = id;
            DBPersist.update(resourcetype);
        }

        public  void delete(long id)
        {
            ResourceType resourcetype = get(id);
            resourcetype.is_active = 0;
            DBPersist.update(resourcetype);
        }
    }
}
