
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class PrincipalLogic : IPrincipalLogic
    {


        public static IPrincipalLogic Create()
        {
            var principal = new PrincipalLogic();

            var proxy = DispatchProxy.Create<IPrincipalLogic, Proxy<IPrincipalLogic>>();
            ((Proxy<IPrincipalLogic>)proxy).Initialize();
            ((Proxy<IPrincipalLogic>)proxy).Target = principal;
            ((Proxy<IPrincipalLogic>)proxy).DomainObj = "Principal";

            return proxy;
        }

        public  List<Principal> select()
        {
            return select<Principal>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing PrincipalLogic select<TBaseObject> List");

            List<TBaseObject> principals = select<TBaseObject>("app.principal-select");

            
            return principals;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing PrincipalLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> principals = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return principals;
        }

         public  List<PrincipalHistory> history(long id)
        {
            List<PrincipalHistory> principalHistory = DBPersist.ExecuteQueryByName<PrincipalHistory>("app.principal-get-history", new BaseObject() { { "id", id } });

            return principalHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing PrincipalLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "app.principal-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Principal get(long id)
        {
            Console.WriteLine($"Processing PrincipalLogic get ID={id}");

            Principal principal = DBPersist.select<Principal>($"SELECT * FROM app.principal WHERE id = {id}").FirstOrDefault();
            

            return principal;
        }

        public  void insert(Principal principal)
        {
            Console.WriteLine($"Processing PrincipalLogic insert: {principal}");

            principal.is_active = 1;

            DBPersist.insert(principal);
        }

        public  void put(Principal principal)
        {
            Console.WriteLine($"Processing PrincipalLogic put: {principal}");

            principal.is_active = 1;

            DBPersist.put(principal);
        }

        public  void update(long id, Principal principal)
        {
            Console.WriteLine($"Processing PrincipalLogic update: ID = {id}\n{principal}");

            principal.id = id;
            DBPersist.update(principal);
        }

        public  void delete(long id)
        {
            Principal principal = get(id);
            principal.is_active = 0;
            DBPersist.update(principal);
        }
    }
}
