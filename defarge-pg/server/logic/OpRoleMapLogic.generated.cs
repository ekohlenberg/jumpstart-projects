
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class OpRoleMapLogic : IOpRoleMapLogic
    {


        public static IOpRoleMapLogic Create()
        {
            var oprolemap = new OpRoleMapLogic();

            var proxy = DispatchProxy.Create<IOpRoleMapLogic, Proxy<IOpRoleMapLogic>>();
            ((Proxy<IOpRoleMapLogic>)proxy).Initialize();
            ((Proxy<IOpRoleMapLogic>)proxy).Target = oprolemap;
            ((Proxy<IOpRoleMapLogic>)proxy).DomainObj = "OpRoleMap";

            return proxy;
        }

        public  List<OpRoleMap> select()
        {
            return select<OpRoleMap>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing OpRoleMapLogic select<TBaseObject> List");

            List<TBaseObject> oprolemaps = select<TBaseObject>("sec.op_role_map-select");

            
            return oprolemaps;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing OpRoleMapLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> oprolemaps = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return oprolemaps;
        }

         public  List<OpRoleMapHistory> history(long id)
        {
            List<OpRoleMapHistory> oprolemapHistory = DBPersist.ExecuteQueryByName<OpRoleMapHistory>("sec.op_role_map-get-history", new BaseObject() { { "id", id } });

            return oprolemapHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing OpRoleMapLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "sec.op_role_map-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  OpRoleMap get(long id)
        {
            Logger.Debug($"Processing OpRoleMapLogic get ID={id}");

            OpRoleMap oprolemap = DBPersist.select<OpRoleMap>($"SELECT * FROM sec.op_role_map WHERE id = {id}").FirstOrDefault();
            

            return oprolemap;
        }

        public  void insert(OpRoleMap oprolemap)
        {
            Logger.Debug($"Processing OpRoleMapLogic insert: {oprolemap}");

            oprolemap.is_active = 1;

            DBPersist.insert(oprolemap);
        }

        public  void put(OpRoleMap oprolemap)
        {
            Logger.Debug($"Processing OpRoleMapLogic put: {oprolemap}");

            oprolemap.is_active = 1;

            DBPersist.put(oprolemap);
        }

        public  void update(long id, OpRoleMap oprolemap)
        {
            Logger.Debug($"Processing OpRoleMapLogic update: ID = {id}\n{oprolemap}");

            oprolemap.id = id;
            DBPersist.update(oprolemap);
        }

        public  void delete(long id)
        {
            OpRoleMap oprolemap = get(id);
            oprolemap.is_active = 0;
            DBPersist.update(oprolemap);
        }
    }
}
