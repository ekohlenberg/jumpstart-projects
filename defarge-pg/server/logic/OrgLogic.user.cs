
using System;


namespace defarge
{
    public interface IOrgLogic
    {  
        // Generated methods
        List<Org> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<OrgHistory> history(long id);
        Org get(long id);
        void insert(Org org);
        void update(long id, Org org);
        void put(Org org);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class OrgLogic
    {
        protected OrgLogic()
        {
           
        }
        
    }
}

