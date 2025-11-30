
using System;


namespace defarge
{
    public interface IOpRoleMapLogic
    {  
        // Generated methods
        List<OpRoleMap> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<OpRoleMapHistory> history(long id);
        OpRoleMap get(long id);
        void insert(OpRoleMap oprolemap);
        void update(long id, OpRoleMap oprolemap);
        void put(OpRoleMap oprolemap);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class OpRoleMapLogic
    {
        protected OpRoleMapLogic()
        {
           
        }
        
    }
}

