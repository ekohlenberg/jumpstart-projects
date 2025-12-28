
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class OpRoleMemberLogic : IOpRoleMemberLogic
    {


        public static IOpRoleMemberLogic Create()
        {
            var oprolemember = new OpRoleMemberLogic();

            var proxy = DispatchProxy.Create<IOpRoleMemberLogic, Proxy<IOpRoleMemberLogic>>();
            ((Proxy<IOpRoleMemberLogic>)proxy).Initialize();
            ((Proxy<IOpRoleMemberLogic>)proxy).Target = oprolemember;
            ((Proxy<IOpRoleMemberLogic>)proxy).DomainObj = "OpRoleMember";

            return proxy;
        }

        public  List<OpRoleMember> select()
        {
            return select<OpRoleMember>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing OpRoleMemberLogic select<TBaseObject> List");

            List<TBaseObject> oprolemembers = select<TBaseObject>("sec.op_role_member-select");

            
            return oprolemembers;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing OpRoleMemberLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> oprolemembers = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return oprolemembers;
        }

         public  List<OpRoleMemberHistory> history(long id)
        {
            List<OpRoleMemberHistory> oprolememberHistory = DBPersist.ExecuteQueryByName<OpRoleMemberHistory>("sec.op_role_member-get-history", new BaseObject() { { "id", id } });

            return oprolememberHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing OpRoleMemberLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "sec.op_role_member-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  OpRoleMember get(long id)
        {
            Logger.Debug($"Processing OpRoleMemberLogic get ID={id}");

            OpRoleMember oprolemember = DBPersist.select<OpRoleMember>($"SELECT * FROM sec.op_role_member WHERE id = {id}").FirstOrDefault();
            

            return oprolemember;
        }

        public  void insert(OpRoleMember oprolemember)
        {
            Logger.Debug($"Processing OpRoleMemberLogic insert: {oprolemember}");

            oprolemember.is_active = 1;

            DBPersist.insert(oprolemember);
        }

        public  void put(OpRoleMember oprolemember)
        {
            Logger.Debug($"Processing OpRoleMemberLogic put: {oprolemember}");

            oprolemember.is_active = 1;

            DBPersist.put(oprolemember);
        }

        public  void update(long id, OpRoleMember oprolemember)
        {
            Logger.Debug($"Processing OpRoleMemberLogic update: ID = {id}\n{oprolemember}");

            oprolemember.id = id;
            DBPersist.update(oprolemember);
        }

        public  void delete(long id)
        {
            OpRoleMember oprolemember = get(id);
            oprolemember.is_active = 0;
            DBPersist.update(oprolemember);
        }
    }
}
