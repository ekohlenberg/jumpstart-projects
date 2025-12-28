
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ServerNodeTypeLogic : IServerNodeTypeLogic
    {


        public static IServerNodeTypeLogic Create()
        {
            var servernodetype = new ServerNodeTypeLogic();

            var proxy = DispatchProxy.Create<IServerNodeTypeLogic, Proxy<IServerNodeTypeLogic>>();
            ((Proxy<IServerNodeTypeLogic>)proxy).Initialize();
            ((Proxy<IServerNodeTypeLogic>)proxy).Target = servernodetype;
            ((Proxy<IServerNodeTypeLogic>)proxy).DomainObj = "ServerNodeType";

            return proxy;
        }

        public  List<ServerNodeType> select()
        {
            return select<ServerNodeType>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing ServerNodeTypeLogic select<TBaseObject> List");

            List<TBaseObject> servernodetypes = select<TBaseObject>("core.server_node_type-select");

            
            return servernodetypes;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ServerNodeTypeLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> servernodetypes = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return servernodetypes;
        }

         public  List<ServerNodeTypeHistory> history(long id)
        {
            List<ServerNodeTypeHistory> servernodetypeHistory = DBPersist.ExecuteQueryByName<ServerNodeTypeHistory>("core.server_node_type-get-history", new BaseObject() { { "id", id } });

            return servernodetypeHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ServerNodeTypeLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.server_node_type-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  ServerNodeType get(long id)
        {
            Logger.Debug($"Processing ServerNodeTypeLogic get ID={id}");

            ServerNodeType servernodetype = DBPersist.select<ServerNodeType>($"SELECT * FROM core.server_node_type WHERE id = {id}").FirstOrDefault();
            

            return servernodetype;
        }

        public  void insert(ServerNodeType servernodetype)
        {
            Logger.Debug($"Processing ServerNodeTypeLogic insert: {servernodetype}");

            servernodetype.is_active = 1;

            DBPersist.insert(servernodetype);
        }

        public  void put(ServerNodeType servernodetype)
        {
            Logger.Debug($"Processing ServerNodeTypeLogic put: {servernodetype}");

            servernodetype.is_active = 1;

            DBPersist.put(servernodetype);
        }

        public  void update(long id, ServerNodeType servernodetype)
        {
            Logger.Debug($"Processing ServerNodeTypeLogic update: ID = {id}\n{servernodetype}");

            servernodetype.id = id;
            DBPersist.update(servernodetype);
        }

        public  void delete(long id)
        {
            ServerNodeType servernodetype = get(id);
            servernodetype.is_active = 0;
            DBPersist.update(servernodetype);
        }
    }
}
