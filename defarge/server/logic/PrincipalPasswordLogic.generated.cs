
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
            Console.WriteLine("Processing PrincipalPasswordLogic select List");

            List<PrincipalPassword> principalpasswords = new List<PrincipalPassword>();

            void principalpasswordCallback(System.Data.Common.DbDataReader rdr)
            {
                PrincipalPassword principalpassword = new PrincipalPassword();

                DBPersist.autoAssign(rdr, principalpassword);

                principalpasswords.Add(principalpassword);
            };

            DBPersist.select(principalpasswordCallback, $"select * from sec.principal_password");

            return principalpasswords;
        }

        public  PrincipalPassword get(long id)
        {
            Console.WriteLine($"Processing PrincipalPasswordLogic get ID={id}");

            PrincipalPassword principalpassword = new PrincipalPassword();
            principalpassword.id = id;

            DBPersist.get(principalpassword);

            return principalpassword;
        }

        public  void insert(PrincipalPassword principalpassword)
        {
            Console.WriteLine($"Processing PrincipalPasswordLogic insert: {principalpassword}");

            principalpassword.is_active = 1;

            DBPersist.insert(principalpassword);
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
