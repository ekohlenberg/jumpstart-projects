
using System;


namespace defarge
{
    public interface IQueryLogic
    {  
        // Generated methods
        List<Query> select();
        Query get(long id);
        void insert(Query query);
        void update(long id, Query query);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class QueryLogic
    {
        public QueryLogic()
        {
           
        }
        
    }
}

