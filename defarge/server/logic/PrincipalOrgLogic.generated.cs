
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class PrincipalOrgLogic : IPrincipalOrgLogic
    {


        public static IPrincipalOrgLogic Create()
        {
            var principalorg = new PrincipalOrgLogic();

            var proxy = DispatchProxy.Create<IPrincipalOrgLogic, Proxy<IPrincipalOrgLogic>>();
            ((Proxy<IPrincipalOrgLogic>)proxy).Initialize();
            ((Proxy<IPrincipalOrgLogic>)proxy).Target = principalorg;
            ((Proxy<IPrincipalOrgLogic>)proxy).DomainObj = "PrincipalOrg";

            return proxy;
        }



        public  List<PrincipalOrg> select()
        {
            Console.WriteLine("Processing PrincipalOrgLogic select List");

            List<PrincipalOrg> principalorgs = new List<PrincipalOrg>();

            void principalorgCallback(System.Data.Common.DbDataReader rdr)
            {
                PrincipalOrg principalorg = new PrincipalOrg();

                DBPersist.autoAssign(rdr, principalorg);

                principalorgs.Add(principalorg);
            };

            DBPersist.select(principalorgCallback, $"select * from app.principal_org");

            return principalorgs;
        }

        public  PrincipalOrg get(long id)
        {
            Console.WriteLine($"Processing PrincipalOrgLogic get ID={id}");

            PrincipalOrg principalorg = new PrincipalOrg();
            principalorg.id = id;

            DBPersist.get(principalorg);

            return principalorg;
        }

        public  void insert(PrincipalOrg principalorg)
        {
            Console.WriteLine($"Processing PrincipalOrgLogic insert: {principalorg}");

            principalorg.is_active = 1;

            DBPersist.insert(principalorg);
        }

        public  void update(long id, PrincipalOrg principalorg)
        {
            Console.WriteLine($"Processing PrincipalOrgLogic update: ID = {id}\n{principalorg}");

            principalorg.id = id;
            DBPersist.update(principalorg);
        }

        public  void delete(long id)
        {
            PrincipalOrg principalorg = get(id);
            principalorg.is_active = 0;
            DBPersist.update(principalorg);
        }
    }
}
