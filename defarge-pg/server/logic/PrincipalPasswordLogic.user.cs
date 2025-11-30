
using System;


namespace defarge
{
    public interface IPrincipalPasswordLogic
    {  
        // Generated methods
        List<PrincipalPassword> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<PrincipalPasswordHistory> history(long id);
        PrincipalPassword get(long id);
        void insert(PrincipalPassword principalpassword);
        void update(long id, PrincipalPassword principalpassword);
        void put(PrincipalPassword principalpassword);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class PrincipalPasswordLogic
    {
        protected PrincipalPasswordLogic()
        {
           
        }
        
    }
}

