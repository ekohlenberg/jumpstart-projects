
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class QueryLogic : IQueryLogic
    {


        public static IQueryLogic Create()
        {
            var query = new QueryLogic();

            var proxy = DispatchProxy.Create<IQueryLogic, Proxy<IQueryLogic>>();
            ((Proxy<IQueryLogic>)proxy).Initialize();
            ((Proxy<IQueryLogic>)proxy).Target = query;
            ((Proxy<IQueryLogic>)proxy).DomainObj = "Query";

            return proxy;
        }



        public  List<Query> select()
        {
            Console.WriteLine("Processing QueryLogic select List");

            List<Query> querys = new List<Query>();

            void queryCallback(System.Data.Common.DbDataReader rdr)
            {
                Query query = new Query();

                DBPersist.autoAssign(rdr, query);

                querys.Add(query);
            };

            DBPersist.select(queryCallback, $"select * from core.query");

            return querys;
        }

        public  Query get(long id)
        {
            Console.WriteLine($"Processing QueryLogic get ID={id}");

            Query query = new Query();
            query.id = id;

            DBPersist.get(query);

            return query;
        }

        public  void insert(Query query)
        {
            Console.WriteLine($"Processing QueryLogic insert: {query}");

            query.is_active = 1;

            DBPersist.insert(query);
        }

        public  void update(long id, Query query)
        {
            Console.WriteLine($"Processing QueryLogic update: ID = {id}\n{query}");

            query.id = id;
            DBPersist.update(query);
        }

        public  void delete(long id)
        {
            Query query = get(id);
            query.is_active = 0;
            DBPersist.update(query);
        }
    }
}
