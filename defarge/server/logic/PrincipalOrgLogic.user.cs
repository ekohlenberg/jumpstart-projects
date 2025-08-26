
using System;


namespace defarge
{
    public interface IPrincipalOrgLogic
    {  
        // Generated methods
        List<PrincipalOrg> select();
        PrincipalOrg get(long id);
        void insert(PrincipalOrg principalorg);
        void update(long id, PrincipalOrg principalorg);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class PrincipalOrgLogic
    {
        public PrincipalOrgLogic()
        {
           
        }
        
    }
}

