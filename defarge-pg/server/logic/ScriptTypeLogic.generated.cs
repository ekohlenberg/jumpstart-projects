
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ScriptTypeLogic : IScriptTypeLogic
    {


        public static IScriptTypeLogic Create()
        {
            var scripttype = new ScriptTypeLogic();

            var proxy = DispatchProxy.Create<IScriptTypeLogic, Proxy<IScriptTypeLogic>>();
            ((Proxy<IScriptTypeLogic>)proxy).Initialize();
            ((Proxy<IScriptTypeLogic>)proxy).Target = scripttype;
            ((Proxy<IScriptTypeLogic>)proxy).DomainObj = "ScriptType";

            return proxy;
        }

        public  List<ScriptType> select()
        {
            return select<ScriptType>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing ScriptTypeLogic select<TBaseObject> List");

            List<TBaseObject> scripttypes = select<TBaseObject>("core.script_type-select");

            
            return scripttypes;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing ScriptTypeLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> scripttypes = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return scripttypes;
        }

         public  List<ScriptTypeHistory> history(long id)
        {
            List<ScriptTypeHistory> scripttypeHistory = DBPersist.ExecuteQueryByName<ScriptTypeHistory>("core.script_type-get-history", new BaseObject() { { "id", id } });

            return scripttypeHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing ScriptTypeLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.script_type-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  ScriptType get(long id)
        {
            Console.WriteLine($"Processing ScriptTypeLogic get ID={id}");

            ScriptType scripttype = DBPersist.select<ScriptType>($"SELECT * FROM core.script_type WHERE id = {id}").FirstOrDefault();
            

            return scripttype;
        }

        public  void insert(ScriptType scripttype)
        {
            Console.WriteLine($"Processing ScriptTypeLogic insert: {scripttype}");

            scripttype.is_active = 1;

            DBPersist.insert(scripttype);
        }

        public  void put(ScriptType scripttype)
        {
            Console.WriteLine($"Processing ScriptTypeLogic put: {scripttype}");

            scripttype.is_active = 1;

            DBPersist.put(scripttype);
        }

        public  void update(long id, ScriptType scripttype)
        {
            Console.WriteLine($"Processing ScriptTypeLogic update: ID = {id}\n{scripttype}");

            scripttype.id = id;
            DBPersist.update(scripttype);
        }

        public  void delete(long id)
        {
            ScriptType scripttype = get(id);
            scripttype.is_active = 0;
            DBPersist.update(scripttype);
        }
    }
}
