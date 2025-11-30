
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class AlertLogic : IAlertLogic
    {


        public static IAlertLogic Create()
        {
            var alert = new AlertLogic();

            var proxy = DispatchProxy.Create<IAlertLogic, Proxy<IAlertLogic>>();
            ((Proxy<IAlertLogic>)proxy).Initialize();
            ((Proxy<IAlertLogic>)proxy).Target = alert;
            ((Proxy<IAlertLogic>)proxy).DomainObj = "Alert";

            return proxy;
        }

        public  List<Alert> select()
        {
            return select<Alert>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing AlertLogic select<TBaseObject> List");

            List<TBaseObject> alerts = select<TBaseObject>("app.alert-select");

            
            return alerts;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing AlertLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> alerts = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return alerts;
        }

         public  List<AlertHistory> history(long id)
        {
            List<AlertHistory> alertHistory = DBPersist.ExecuteQueryByName<AlertHistory>("app.alert-get-history", new BaseObject() { { "id", id } });

            return alertHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing AlertLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "app.alert-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Alert get(long id)
        {
            Console.WriteLine($"Processing AlertLogic get ID={id}");

            Alert alert = DBPersist.select<Alert>($"SELECT * FROM app.alert WHERE id = {id}").FirstOrDefault();
            

            return alert;
        }

        public  void insert(Alert alert)
        {
            Console.WriteLine($"Processing AlertLogic insert: {alert}");

            alert.is_active = 1;

            DBPersist.insert(alert);
        }

        public  void put(Alert alert)
        {
            Console.WriteLine($"Processing AlertLogic put: {alert}");

            alert.is_active = 1;

            DBPersist.put(alert);
        }

        public  void update(long id, Alert alert)
        {
            Console.WriteLine($"Processing AlertLogic update: ID = {id}\n{alert}");

            alert.id = id;
            DBPersist.update(alert);
        }

        public  void delete(long id)
        {
            Alert alert = get(id);
            alert.is_active = 0;
            DBPersist.update(alert);
        }
    }
}
