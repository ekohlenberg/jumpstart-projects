
using System;


namespace defarge
{
    public interface IPrincipalLogic
    {  
        // Generated methods
        List<Principal> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<PrincipalHistory> history(long id);
        Principal get(long id);
        void insert(Principal principal);
        void update(long id, Principal principal);
        void put(Principal principal);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class PrincipalLogic
    {
        protected PrincipalLogic()
        {
           
        }
        
    }
}

