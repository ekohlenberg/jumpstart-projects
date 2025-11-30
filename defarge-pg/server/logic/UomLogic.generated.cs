
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class UomLogic : IUomLogic
    {


        public static IUomLogic Create()
        {
            var uom = new UomLogic();

            var proxy = DispatchProxy.Create<IUomLogic, Proxy<IUomLogic>>();
            ((Proxy<IUomLogic>)proxy).Initialize();
            ((Proxy<IUomLogic>)proxy).Target = uom;
            ((Proxy<IUomLogic>)proxy).DomainObj = "Uom";

            return proxy;
        }

        public  List<Uom> select()
        {
            return select<Uom>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing UomLogic select<TBaseObject> List");

            List<TBaseObject> uoms = select<TBaseObject>("app.uom-select");

            
            return uoms;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing UomLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> uoms = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return uoms;
        }

         public  List<UomHistory> history(long id)
        {
            List<UomHistory> uomHistory = DBPersist.ExecuteQueryByName<UomHistory>("app.uom-get-history", new BaseObject() { { "id", id } });

            return uomHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing UomLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "app.uom-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Uom get(long id)
        {
            Console.WriteLine($"Processing UomLogic get ID={id}");

            Uom uom = DBPersist.select<Uom>($"SELECT * FROM app.uom WHERE id = {id}").FirstOrDefault();
            

            return uom;
        }

        public  void insert(Uom uom)
        {
            Console.WriteLine($"Processing UomLogic insert: {uom}");

            uom.is_active = 1;

            DBPersist.insert(uom);
        }

        public  void put(Uom uom)
        {
            Console.WriteLine($"Processing UomLogic put: {uom}");

            uom.is_active = 1;

            DBPersist.put(uom);
        }

        public  void update(long id, Uom uom)
        {
            Console.WriteLine($"Processing UomLogic update: ID = {id}\n{uom}");

            uom.id = id;
            DBPersist.update(uom);
        }

        public  void delete(long id)
        {
            Uom uom = get(id);
            uom.is_active = 0;
            DBPersist.update(uom);
        }
    }
}
