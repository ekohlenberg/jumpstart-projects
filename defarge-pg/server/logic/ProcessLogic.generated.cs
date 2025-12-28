
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ProcessLogic : IProcessLogic
    {


        public static IProcessLogic Create()
        {
            var process = new ProcessLogic();

            var proxy = DispatchProxy.Create<IProcessLogic, Proxy<IProcessLogic>>();
            ((Proxy<IProcessLogic>)proxy).Initialize();
            ((Proxy<IProcessLogic>)proxy).Target = process;
            ((Proxy<IProcessLogic>)proxy).DomainObj = "Process";

            return proxy;
        }

        public  List<Process> select()
        {
            return select<Process>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing ProcessLogic select<TBaseObject> List");

            List<TBaseObject> processs = select<TBaseObject>("core.process-select");

            
            return processs;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ProcessLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> processs = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return processs;
        }

         public  List<ProcessHistory> history(long id)
        {
            List<ProcessHistory> processHistory = DBPersist.ExecuteQueryByName<ProcessHistory>("core.process-get-history", new BaseObject() { { "id", id } });

            return processHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ProcessLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.process-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Process get(long id)
        {
            Logger.Debug($"Processing ProcessLogic get ID={id}");

            Process process = DBPersist.select<Process>($"SELECT * FROM core.process WHERE id = {id}").FirstOrDefault();
            

            return process;
        }

        public  void insert(Process process)
        {
            Logger.Debug($"Processing ProcessLogic insert: {process}");

            process.is_active = 1;

            DBPersist.insert(process);
        }

        public  void put(Process process)
        {
            Logger.Debug($"Processing ProcessLogic put: {process}");

            process.is_active = 1;

            DBPersist.put(process);
        }

        public  void update(long id, Process process)
        {
            Logger.Debug($"Processing ProcessLogic update: ID = {id}\n{process}");

            process.id = id;
            DBPersist.update(process);
        }

        public  void delete(long id)
        {
            Process process = get(id);
            process.is_active = 0;
            DBPersist.update(process);
        }
    }
}
