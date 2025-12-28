
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class SqlLogic : ISqlLogic
    {


        public static ISqlLogic Create()
        {
            var sql = new SqlLogic();

            var proxy = DispatchProxy.Create<ISqlLogic, Proxy<ISqlLogic>>();
            ((Proxy<ISqlLogic>)proxy).Initialize();
            ((Proxy<ISqlLogic>)proxy).Target = sql;
            ((Proxy<ISqlLogic>)proxy).DomainObj = "Sql";

            return proxy;
        }

        public  List<Sql> select()
        {
            return select<Sql>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing SqlLogic select<TBaseObject> List");

            List<TBaseObject> sqls = select<TBaseObject>("core.sql-select");

            
            return sqls;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing SqlLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> sqls = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return sqls;
        }

         public  List<SqlHistory> history(long id)
        {
            List<SqlHistory> sqlHistory = DBPersist.ExecuteQueryByName<SqlHistory>("core.sql-get-history", new BaseObject() { { "id", id } });

            return sqlHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing SqlLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.sql-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Sql get(long id)
        {
            Logger.Debug($"Processing SqlLogic get ID={id}");

            Sql sql = DBPersist.select<Sql>($"SELECT * FROM core.sql WHERE id = {id}").FirstOrDefault();
            

            return sql;
        }

        public  void insert(Sql sql)
        {
            Logger.Debug($"Processing SqlLogic insert: {sql}");

            sql.is_active = 1;

            DBPersist.insert(sql);
        }

        public  void put(Sql sql)
        {
            Logger.Debug($"Processing SqlLogic put: {sql}");

            sql.is_active = 1;

            DBPersist.put(sql);
        }

        public  void update(long id, Sql sql)
        {
            Logger.Debug($"Processing SqlLogic update: ID = {id}\n{sql}");

            sql.id = id;
            DBPersist.update(sql);
        }

        public  void delete(long id)
        {
            Sql sql = get(id);
            sql.is_active = 0;
            DBPersist.update(sql);
        }
    }
}
