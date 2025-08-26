
using System;


namespace defarge
{
    public interface IPrincipalLogic
    {  
        // Generated methods
        List<Principal> select();
        Principal get(long id);
        void insert(Principal principal);
        void update(long id, Principal principal);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class PrincipalLogic
    {
        public PrincipalLogic()
        {
           
        }
        
    }
}

