
using System;


namespace defarge
{
    public interface IScriptTypeLogic
    {  
        // Generated methods
        List<ScriptType> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<ScriptTypeHistory> history(long id);
        ScriptType get(long id);
        void insert(ScriptType scripttype);
        void update(long id, ScriptType scripttype);
        void put(ScriptType scripttype);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ScriptTypeLogic
    {
        protected ScriptTypeLogic()
        {
           
        }
        
    }
}

