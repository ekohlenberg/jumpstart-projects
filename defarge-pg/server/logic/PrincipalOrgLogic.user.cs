
using System;


namespace defarge
{
    public interface IPrincipalOrgLogic
    {  
        // Generated methods
        List<PrincipalOrg> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<PrincipalOrgHistory> history(long id);
        PrincipalOrg get(long id);
        void insert(PrincipalOrg principalorg);
        void update(long id, PrincipalOrg principalorg);
        void put(PrincipalOrg principalorg);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class PrincipalOrgLogic
    {
        protected PrincipalOrgLogic()
        {
           
        }
        
    }
}

