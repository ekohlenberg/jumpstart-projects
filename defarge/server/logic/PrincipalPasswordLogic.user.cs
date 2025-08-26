
using System;


namespace defarge
{
    public interface IPrincipalPasswordLogic
    {  
        // Generated methods
        List<PrincipalPassword> select();
        PrincipalPassword get(long id);
        void insert(PrincipalPassword principalpassword);
        void update(long id, PrincipalPassword principalpassword);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class PrincipalPasswordLogic
    {
        public PrincipalPasswordLogic()
        {
           
        }
        
    }
}

