
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ExecStatusLogic : IExecStatusLogic
    {


        public static IExecStatusLogic Create()
        {
            var execstatus = new ExecStatusLogic();

            var proxy = DispatchProxy.Create<IExecStatusLogic, Proxy<IExecStatusLogic>>();
            ((Proxy<IExecStatusLogic>)proxy).Initialize();
            ((Proxy<IExecStatusLogic>)proxy).Target = execstatus;
            ((Proxy<IExecStatusLogic>)proxy).DomainObj = "ExecStatus";

            return proxy;
        }

        public  List<ExecStatus> select()
        {
            return select<ExecStatus>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing ExecStatusLogic select<TBaseObject> List");

            List<TBaseObject> execstatuss = select<TBaseObject>("core.exec_status-select");

            
            return execstatuss;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ExecStatusLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> execstatuss = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return execstatuss;
        }

         public  List<ExecStatusHistory> history(long id)
        {
            List<ExecStatusHistory> execstatusHistory = DBPersist.ExecuteQueryByName<ExecStatusHistory>("core.exec_status-get-history", new BaseObject() { { "id", id } });

            return execstatusHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ExecStatusLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.exec_status-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  ExecStatus get(long id)
        {
            Logger.Debug($"Processing ExecStatusLogic get ID={id}");

            ExecStatus execstatus = DBPersist.select<ExecStatus>($"SELECT * FROM core.exec_status WHERE id = {id}").FirstOrDefault();
            

            return execstatus;
        }

        public  void insert(ExecStatus execstatus)
        {
            Logger.Debug($"Processing ExecStatusLogic insert: {execstatus}");

            execstatus.is_active = 1;

            DBPersist.insert(execstatus);
        }

        public  void put(ExecStatus execstatus)
        {
            Logger.Debug($"Processing ExecStatusLogic put: {execstatus}");

            execstatus.is_active = 1;

            DBPersist.put(execstatus);
        }

        public  void update(long id, ExecStatus execstatus)
        {
            Logger.Debug($"Processing ExecStatusLogic update: ID = {id}\n{execstatus}");

            execstatus.id = id;
            DBPersist.update(execstatus);
        }

        public  void delete(long id)
        {
            ExecStatus execstatus = get(id);
            execstatus.is_active = 0;
            DBPersist.update(execstatus);
        }
    }
}
