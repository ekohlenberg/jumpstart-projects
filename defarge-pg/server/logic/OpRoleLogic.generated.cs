
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class OpRoleLogic : IOpRoleLogic
    {


        public static IOpRoleLogic Create()
        {
            var oprole = new OpRoleLogic();

            var proxy = DispatchProxy.Create<IOpRoleLogic, Proxy<IOpRoleLogic>>();
            ((Proxy<IOpRoleLogic>)proxy).Initialize();
            ((Proxy<IOpRoleLogic>)proxy).Target = oprole;
            ((Proxy<IOpRoleLogic>)proxy).DomainObj = "OpRole";

            return proxy;
        }

        public  List<OpRole> select()
        {
            return select<OpRole>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing OpRoleLogic select<TBaseObject> List");

            List<TBaseObject> oproles = select<TBaseObject>("sec.op_role-select");

            
            return oproles;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing OpRoleLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> oproles = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return oproles;
        }

         public  List<OpRoleHistory> history(long id)
        {
            List<OpRoleHistory> oproleHistory = DBPersist.ExecuteQueryByName<OpRoleHistory>("sec.op_role-get-history", new BaseObject() { { "id", id } });

            return oproleHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing OpRoleLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "sec.op_role-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  OpRole get(long id)
        {
            Logger.Debug($"Processing OpRoleLogic get ID={id}");

            OpRole oprole = DBPersist.select<OpRole>($"SELECT * FROM sec.op_role WHERE id = {id}").FirstOrDefault();
            

            return oprole;
        }

        public  void insert(OpRole oprole)
        {
            Logger.Debug($"Processing OpRoleLogic insert: {oprole}");

            oprole.is_active = 1;

            DBPersist.insert(oprole);
        }

        public  void put(OpRole oprole)
        {
            Logger.Debug($"Processing OpRoleLogic put: {oprole}");

            oprole.is_active = 1;

            DBPersist.put(oprole);
        }

        public  void update(long id, OpRole oprole)
        {
            Logger.Debug($"Processing OpRoleLogic update: ID = {id}\n{oprole}");

            oprole.id = id;
            DBPersist.update(oprole);
        }

        public  void delete(long id)
        {
            OpRole oprole = get(id);
            oprole.is_active = 0;
            DBPersist.update(oprole);
        }
    }
}
