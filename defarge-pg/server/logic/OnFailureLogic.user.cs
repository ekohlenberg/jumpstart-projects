
using System;


namespace defarge
{
    public interface IOnFailureLogic
    {  
        // Generated methods
        List<OnFailure> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<OnFailureHistory> history(long id);
        OnFailure get(long id);
        void insert(OnFailure onfailure);
        void update(long id, OnFailure onfailure);
        void put(OnFailure onfailure);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class OnFailureLogic
    {
        protected OnFailureLogic()
        {
           
        }
        
    }
}

