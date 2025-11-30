
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ScriptLogic : IScriptLogic
    {


        public static IScriptLogic Create()
        {
            var script = new ScriptLogic();

            var proxy = DispatchProxy.Create<IScriptLogic, Proxy<IScriptLogic>>();
            ((Proxy<IScriptLogic>)proxy).Initialize();
            ((Proxy<IScriptLogic>)proxy).Target = script;
            ((Proxy<IScriptLogic>)proxy).DomainObj = "Script";

            return proxy;
        }

        public  List<Script> select()
        {
            return select<Script>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing ScriptLogic select<TBaseObject> List");

            List<TBaseObject> scripts = select<TBaseObject>("core.script-select");

            
            return scripts;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing ScriptLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> scripts = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return scripts;
        }

         public  List<ScriptHistory> history(long id)
        {
            List<ScriptHistory> scriptHistory = DBPersist.ExecuteQueryByName<ScriptHistory>("core.script-get-history", new BaseObject() { { "id", id } });

            return scriptHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing ScriptLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.script-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Script get(long id)
        {
            Console.WriteLine($"Processing ScriptLogic get ID={id}");

            Script script = DBPersist.select<Script>($"SELECT * FROM core.script WHERE id = {id}").FirstOrDefault();
            

            return script;
        }

        public  void insert(Script script)
        {
            Console.WriteLine($"Processing ScriptLogic insert: {script}");

            script.is_active = 1;

            DBPersist.insert(script);
        }

        public  void put(Script script)
        {
            Console.WriteLine($"Processing ScriptLogic put: {script}");

            script.is_active = 1;

            DBPersist.put(script);
        }

        public  void update(long id, Script script)
        {
            Console.WriteLine($"Processing ScriptLogic update: ID = {id}\n{script}");

            script.id = id;
            DBPersist.update(script);
        }

        public  void delete(long id)
        {
            Script script = get(id);
            script.is_active = 0;
            DBPersist.update(script);
        }
    }
}
