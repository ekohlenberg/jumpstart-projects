
using System;


namespace defarge
{
    public interface IOpRoleLogic
    {  
        // Generated methods
        List<OpRole> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<OpRoleHistory> history(long id);
        OpRole get(long id);
        void insert(OpRole oprole);
        void update(long id, OpRole oprole);
        void put(OpRole oprole);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class OpRoleLogic
    {
        protected OpRoleLogic()
        {
           
        }
        
    }
}

