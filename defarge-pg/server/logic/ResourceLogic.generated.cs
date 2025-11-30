
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ResourceLogic : IResourceLogic
    {


        public static IResourceLogic Create()
        {
            var resource = new ResourceLogic();

            var proxy = DispatchProxy.Create<IResourceLogic, Proxy<IResourceLogic>>();
            ((Proxy<IResourceLogic>)proxy).Initialize();
            ((Proxy<IResourceLogic>)proxy).Target = resource;
            ((Proxy<IResourceLogic>)proxy).DomainObj = "Resource";

            return proxy;
        }

        public  List<Resource> select()
        {
            return select<Resource>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing ResourceLogic select<TBaseObject> List");

            List<TBaseObject> resources = select<TBaseObject>("app.resource-select");

            
            return resources;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing ResourceLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> resources = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return resources;
        }

         public  List<ResourceHistory> history(long id)
        {
            List<ResourceHistory> resourceHistory = DBPersist.ExecuteQueryByName<ResourceHistory>("app.resource-get-history", new BaseObject() { { "id", id } });

            return resourceHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing ResourceLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "app.resource-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Resource get(long id)
        {
            Console.WriteLine($"Processing ResourceLogic get ID={id}");

            Resource resource = DBPersist.select<Resource>($"SELECT * FROM app.resource WHERE id = {id}").FirstOrDefault();
            

            return resource;
        }

        public  void insert(Resource resource)
        {
            Console.WriteLine($"Processing ResourceLogic insert: {resource}");

            resource.is_active = 1;

            DBPersist.insert(resource);
        }

        public  void put(Resource resource)
        {
            Console.WriteLine($"Processing ResourceLogic put: {resource}");

            resource.is_active = 1;

            DBPersist.put(resource);
        }

        public  void update(long id, Resource resource)
        {
            Console.WriteLine($"Processing ResourceLogic update: ID = {id}\n{resource}");

            resource.id = id;
            DBPersist.update(resource);
        }

        public  void delete(long id)
        {
            Resource resource = get(id);
            resource.is_active = 0;
            DBPersist.update(resource);
        }
    }
}
