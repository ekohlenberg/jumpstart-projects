
using System;


namespace defarge
{
    public interface IScriptLogic
    {  
        // Generated methods
        List<Script> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<ScriptHistory> history(long id);
        Script get(long id);
        void insert(Script script);
        void update(long id, Script script);
        void put(Script script);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ScriptLogic
    {
        protected ScriptLogic()
        {
           
        }
        
    }
}

