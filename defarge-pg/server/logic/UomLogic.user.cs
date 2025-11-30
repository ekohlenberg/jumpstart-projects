
using System;


namespace defarge
{
    public interface IUomLogic
    {  
        // Generated methods
        List<Uom> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<UomHistory> history(long id);
        Uom get(long id);
        void insert(Uom uom);
        void update(long id, Uom uom);
        void put(Uom uom);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class UomLogic
    {
        protected UomLogic()
        {
           
        }
        
    }
}

