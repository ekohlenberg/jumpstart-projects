
using System;


namespace defarge
{
    public interface IOpRoleMemberLogic
    {  
        // Generated methods
        List<OpRoleMember> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<OpRoleMemberHistory> history(long id);
        OpRoleMember get(long id);
        void insert(OpRoleMember oprolemember);
        void update(long id, OpRoleMember oprolemember);
        void put(OpRoleMember oprolemember);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class OpRoleMemberLogic
    {
        protected OpRoleMemberLogic()
        {
           
        }
        
    }
}

