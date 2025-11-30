
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class PrincipalPasswordLogic : IPrincipalPasswordLogic
    {


        public static IPrincipalPasswordLogic Create()
        {
            var principalpassword = new PrincipalPasswordLogic();

            var proxy = DispatchProxy.Create<IPrincipalPasswordLogic, Proxy<IPrincipalPasswordLogic>>();
            ((Proxy<IPrincipalPasswordLogic>)proxy).Initialize();
            ((Proxy<IPrincipalPasswordLogic>)proxy).Target = principalpassword;
            ((Proxy<IPrincipalPasswordLogic>)proxy).DomainObj = "PrincipalPassword";

            return proxy;
        }

        public  List<PrincipalPassword> select()
        {
            return select<PrincipalPassword>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing PrincipalPasswordLogic select<TBaseObject> List");

            List<TBaseObject> principalpasswords = select<TBaseObject>("sec.principal_password-select");

            
            return principalpasswords;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing PrincipalPasswordLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> principalpasswords = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return principalpasswords;
        }

         public  List<PrincipalPasswordHistory> history(long id)
        {
            List<PrincipalPasswordHistory> principalpasswordHistory = DBPersist.ExecuteQueryByName<PrincipalPasswordHistory>("sec.principal_password-get-history", new BaseObject() { { "id", id } });

            return principalpasswordHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing PrincipalPasswordLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "sec.principal_password-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  PrincipalPassword get(long id)
        {
            Console.WriteLine($"Processing PrincipalPasswordLogic get ID={id}");

            PrincipalPassword principalpassword = DBPersist.select<PrincipalPassword>($"SELECT * FROM sec.principal_password WHERE id = {id}").FirstOrDefault();
            

            return principalpassword;
        }

        public  void insert(PrincipalPassword principalpassword)
        {
            Console.WriteLine($"Processing PrincipalPasswordLogic insert: {principalpassword}");

            principalpassword.is_active = 1;

            DBPersist.insert(principalpassword);
        }

        public  void put(PrincipalPassword principalpassword)
        {
            Console.WriteLine($"Processing PrincipalPasswordLogic put: {principalpassword}");

            principalpassword.is_active = 1;

            DBPersist.put(principalpassword);
        }

        public  void update(long id, PrincipalPassword principalpassword)
        {
            Console.WriteLine($"Processing PrincipalPasswordLogic update: ID = {id}\n{principalpassword}");

            principalpassword.id = id;
            DBPersist.update(principalpassword);
        }

        public  void delete(long id)
        {
            PrincipalPassword principalpassword = get(id);
            principalpassword.is_active = 0;
            DBPersist.update(principalpassword);
        }
    }
}
