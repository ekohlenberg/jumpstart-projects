
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class OrgLogic : IOrgLogic
    {


        public static IOrgLogic Create()
        {
            var org = new OrgLogic();

            var proxy = DispatchProxy.Create<IOrgLogic, Proxy<IOrgLogic>>();
            ((Proxy<IOrgLogic>)proxy).Initialize();
            ((Proxy<IOrgLogic>)proxy).Target = org;
            ((Proxy<IOrgLogic>)proxy).DomainObj = "Org";

            return proxy;
        }

        public  List<Org> select()
        {
            return select<Org>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing OrgLogic select<TBaseObject> List");

            List<TBaseObject> orgs = select<TBaseObject>("app.org-select");

            
            return orgs;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing OrgLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> orgs = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return orgs;
        }

         public  List<OrgHistory> history(long id)
        {
            List<OrgHistory> orgHistory = DBPersist.ExecuteQueryByName<OrgHistory>("app.org-get-history", new BaseObject() { { "id", id } });

            return orgHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing OrgLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "app.org-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Org get(long id)
        {
            Logger.Debug($"Processing OrgLogic get ID={id}");

            Org org = DBPersist.select<Org>($"SELECT * FROM app.org WHERE id = {id}").FirstOrDefault();
            

            return org;
        }

        public  void insert(Org org)
        {
            Logger.Debug($"Processing OrgLogic insert: {org}");

            org.is_active = 1;

            DBPersist.insert(org);
        }

        public  void put(Org org)
        {
            Logger.Debug($"Processing OrgLogic put: {org}");

            org.is_active = 1;

            DBPersist.put(org);
        }

        public  void update(long id, Org org)
        {
            Logger.Debug($"Processing OrgLogic update: ID = {id}\n{org}");

            org.id = id;
            DBPersist.update(org);
        }

        public  void delete(long id)
        {
            Org org = get(id);
            org.is_active = 0;
            DBPersist.update(org);
        }
    }
}
