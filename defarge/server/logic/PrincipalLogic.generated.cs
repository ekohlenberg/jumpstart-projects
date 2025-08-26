
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
            Console.WriteLine("Processing PrincipalLogic select List");

            List<Principal> principals = new List<Principal>();

            void principalCallback(System.Data.Common.DbDataReader rdr)
            {
                Principal principal = new Principal();

                DBPersist.autoAssign(rdr, principal);

                principals.Add(principal);
            };

            DBPersist.select(principalCallback, $"select * from app.principal");

            return principals;
        }

        public  Principal get(long id)
        {
            Console.WriteLine($"Processing PrincipalLogic get ID={id}");

            Principal principal = new Principal();
            principal.id = id;

            DBPersist.get(principal);

            return principal;
        }

        public  void insert(Principal principal)
        {
            Console.WriteLine($"Processing PrincipalLogic insert: {principal}");

            principal.is_active = 1;

            DBPersist.insert(principal);
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
