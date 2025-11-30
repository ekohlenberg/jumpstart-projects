
using System;


namespace defarge
{
    public interface INavMenuLogic
    {  
        // Generated methods
        List<NavMenu> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<NavMenuHistory> history(long id);
        NavMenu get(long id);
        void insert(NavMenu navmenu);
        void update(long id, NavMenu navmenu);
        void put(NavMenu navmenu);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class NavMenuLogic
    {
        protected NavMenuLogic()
        {
           
        }
        
    }
}

