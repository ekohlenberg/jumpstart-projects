
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ServerNodeStatusLogic : IServerNodeStatusLogic
    {


        public static IServerNodeStatusLogic Create()
        {
            var servernodestatus = new ServerNodeStatusLogic();

            var proxy = DispatchProxy.Create<IServerNodeStatusLogic, Proxy<IServerNodeStatusLogic>>();
            ((Proxy<IServerNodeStatusLogic>)proxy).Initialize();
            ((Proxy<IServerNodeStatusLogic>)proxy).Target = servernodestatus;
            ((Proxy<IServerNodeStatusLogic>)proxy).DomainObj = "ServerNodeStatus";

            return proxy;
        }

        public  List<ServerNodeStatus> select()
        {
            return select<ServerNodeStatus>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing ServerNodeStatusLogic select<TBaseObject> List");

            List<TBaseObject> servernodestatuss = select<TBaseObject>("core.server_node_status-select");

            
            return servernodestatuss;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ServerNodeStatusLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> servernodestatuss = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return servernodestatuss;
        }

         public  List<ServerNodeStatusHistory> history(long id)
        {
            List<ServerNodeStatusHistory> servernodestatusHistory = DBPersist.ExecuteQueryByName<ServerNodeStatusHistory>("core.server_node_status-get-history", new BaseObject() { { "id", id } });

            return servernodestatusHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ServerNodeStatusLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.server_node_status-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  ServerNodeStatus get(long id)
        {
            Logger.Debug($"Processing ServerNodeStatusLogic get ID={id}");

            ServerNodeStatus servernodestatus = DBPersist.select<ServerNodeStatus>($"SELECT * FROM core.server_node_status WHERE id = {id}").FirstOrDefault();
            

            return servernodestatus;
        }

        public  void insert(ServerNodeStatus servernodestatus)
        {
            Logger.Debug($"Processing ServerNodeStatusLogic insert: {servernodestatus}");

            servernodestatus.is_active = 1;

            DBPersist.insert(servernodestatus);
        }

        public  void put(ServerNodeStatus servernodestatus)
        {
            Logger.Debug($"Processing ServerNodeStatusLogic put: {servernodestatus}");

            servernodestatus.is_active = 1;

            DBPersist.put(servernodestatus);
        }

        public  void update(long id, ServerNodeStatus servernodestatus)
        {
            Logger.Debug($"Processing ServerNodeStatusLogic update: ID = {id}\n{servernodestatus}");

            servernodestatus.id = id;
            DBPersist.update(servernodestatus);
        }

        public  void delete(long id)
        {
            ServerNodeStatus servernodestatus = get(id);
            servernodestatus.is_active = 0;
            DBPersist.update(servernodestatus);
        }
    }
}
