
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
            return select<PrincipalOrg>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing PrincipalOrgLogic select<TBaseObject> List");

            List<TBaseObject> principalorgs = select<TBaseObject>("app.principal_org-select");

            
            return principalorgs;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing PrincipalOrgLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> principalorgs = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return principalorgs;
        }

         public  List<PrincipalOrgHistory> history(long id)
        {
            List<PrincipalOrgHistory> principalorgHistory = DBPersist.ExecuteQueryByName<PrincipalOrgHistory>("app.principal_org-get-history", new BaseObject() { { "id", id } });

            return principalorgHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing PrincipalOrgLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "app.principal_org-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  PrincipalOrg get(long id)
        {
            Logger.Debug($"Processing PrincipalOrgLogic get ID={id}");

            PrincipalOrg principalorg = DBPersist.select<PrincipalOrg>($"SELECT * FROM app.principal_org WHERE id = {id}").FirstOrDefault();
            

            return principalorg;
        }

        public  void insert(PrincipalOrg principalorg)
        {
            Logger.Debug($"Processing PrincipalOrgLogic insert: {principalorg}");

            principalorg.is_active = 1;

            DBPersist.insert(principalorg);
        }

        public  void put(PrincipalOrg principalorg)
        {
            Logger.Debug($"Processing PrincipalOrgLogic put: {principalorg}");

            principalorg.is_active = 1;

            DBPersist.put(principalorg);
        }

        public  void update(long id, PrincipalOrg principalorg)
        {
            Logger.Debug($"Processing PrincipalOrgLogic update: ID = {id}\n{principalorg}");

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
