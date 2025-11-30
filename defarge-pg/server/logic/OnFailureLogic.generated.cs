
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class OnFailureLogic : IOnFailureLogic
    {


        public static IOnFailureLogic Create()
        {
            var onfailure = new OnFailureLogic();

            var proxy = DispatchProxy.Create<IOnFailureLogic, Proxy<IOnFailureLogic>>();
            ((Proxy<IOnFailureLogic>)proxy).Initialize();
            ((Proxy<IOnFailureLogic>)proxy).Target = onfailure;
            ((Proxy<IOnFailureLogic>)proxy).DomainObj = "OnFailure";

            return proxy;
        }

        public  List<OnFailure> select()
        {
            return select<OnFailure>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing OnFailureLogic select<TBaseObject> List");

            List<TBaseObject> onfailures = select<TBaseObject>("core.on_failure-select");

            
            return onfailures;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing OnFailureLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> onfailures = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return onfailures;
        }

         public  List<OnFailureHistory> history(long id)
        {
            List<OnFailureHistory> onfailureHistory = DBPersist.ExecuteQueryByName<OnFailureHistory>("core.on_failure-get-history", new BaseObject() { { "id", id } });

            return onfailureHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing OnFailureLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.on_failure-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  OnFailure get(long id)
        {
            Console.WriteLine($"Processing OnFailureLogic get ID={id}");

            OnFailure onfailure = DBPersist.select<OnFailure>($"SELECT * FROM core.on_failure WHERE id = {id}").FirstOrDefault();
            

            return onfailure;
        }

        public  void insert(OnFailure onfailure)
        {
            Console.WriteLine($"Processing OnFailureLogic insert: {onfailure}");

            onfailure.is_active = 1;

            DBPersist.insert(onfailure);
        }

        public  void put(OnFailure onfailure)
        {
            Console.WriteLine($"Processing OnFailureLogic put: {onfailure}");

            onfailure.is_active = 1;

            DBPersist.put(onfailure);
        }

        public  void update(long id, OnFailure onfailure)
        {
            Console.WriteLine($"Processing OnFailureLogic update: ID = {id}\n{onfailure}");

            onfailure.id = id;
            DBPersist.update(onfailure);
        }

        public  void delete(long id)
        {
            OnFailure onfailure = get(id);
            onfailure.is_active = 0;
            DBPersist.update(onfailure);
        }
    }
}
