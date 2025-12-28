
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ServerNodeLogic : IServerNodeLogic
    {


        public static IServerNodeLogic Create()
        {
            var servernode = new ServerNodeLogic();

            var proxy = DispatchProxy.Create<IServerNodeLogic, Proxy<IServerNodeLogic>>();
            ((Proxy<IServerNodeLogic>)proxy).Initialize();
            ((Proxy<IServerNodeLogic>)proxy).Target = servernode;
            ((Proxy<IServerNodeLogic>)proxy).DomainObj = "ServerNode";

            return proxy;
        }

        public  List<ServerNode> select()
        {
            return select<ServerNode>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing ServerNodeLogic select<TBaseObject> List");

            List<TBaseObject> servernodes = select<TBaseObject>("core.server_node-select");

            
            return servernodes;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ServerNodeLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> servernodes = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return servernodes;
        }

         public  List<ServerNodeHistory> history(long id)
        {
            List<ServerNodeHistory> servernodeHistory = DBPersist.ExecuteQueryByName<ServerNodeHistory>("core.server_node-get-history", new BaseObject() { { "id", id } });

            return servernodeHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ServerNodeLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.server_node-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  ServerNode get(long id)
        {
            Logger.Debug($"Processing ServerNodeLogic get ID={id}");

            ServerNode servernode = DBPersist.select<ServerNode>($"SELECT * FROM core.server_node WHERE id = {id}").FirstOrDefault();
            

            return servernode;
        }

        public  void insert(ServerNode servernode)
        {
            Logger.Debug($"Processing ServerNodeLogic insert: {servernode}");

            servernode.is_active = 1;

            DBPersist.insert(servernode);
        }

        public  void put(ServerNode servernode)
        {
            Logger.Debug($"Processing ServerNodeLogic put: {servernode}");

            servernode.is_active = 1;

            DBPersist.put(servernode);
        }

        public  void update(long id, ServerNode servernode)
        {
            Logger.Debug($"Processing ServerNodeLogic update: ID = {id}\n{servernode}");

            servernode.id = id;
            DBPersist.update(servernode);
        }

        public  void delete(long id)
        {
            ServerNode servernode = get(id);
            servernode.is_active = 0;
            DBPersist.update(servernode);
        }
    }
}
