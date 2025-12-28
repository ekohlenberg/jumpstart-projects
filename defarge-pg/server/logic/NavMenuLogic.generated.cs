
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class NavMenuLogic : INavMenuLogic
    {


        public static INavMenuLogic Create()
        {
            var navmenu = new NavMenuLogic();

            var proxy = DispatchProxy.Create<INavMenuLogic, Proxy<INavMenuLogic>>();
            ((Proxy<INavMenuLogic>)proxy).Initialize();
            ((Proxy<INavMenuLogic>)proxy).Target = navmenu;
            ((Proxy<INavMenuLogic>)proxy).DomainObj = "NavMenu";

            return proxy;
        }

        public  List<NavMenu> select()
        {
            return select<NavMenu>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing NavMenuLogic select<TBaseObject> List");

            List<TBaseObject> navmenus = select<TBaseObject>("core.nav_menu-select");

            
            return navmenus;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing NavMenuLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> navmenus = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return navmenus;
        }

         public  List<NavMenuHistory> history(long id)
        {
            List<NavMenuHistory> navmenuHistory = DBPersist.ExecuteQueryByName<NavMenuHistory>("core.nav_menu-get-history", new BaseObject() { { "id", id } });

            return navmenuHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing NavMenuLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.nav_menu-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  NavMenu get(long id)
        {
            Logger.Debug($"Processing NavMenuLogic get ID={id}");

            NavMenu navmenu = DBPersist.select<NavMenu>($"SELECT * FROM core.nav_menu WHERE id = {id}").FirstOrDefault();
            

            return navmenu;
        }

        public  void insert(NavMenu navmenu)
        {
            Logger.Debug($"Processing NavMenuLogic insert: {navmenu}");

            navmenu.is_active = 1;

            DBPersist.insert(navmenu);
        }

        public  void put(NavMenu navmenu)
        {
            Logger.Debug($"Processing NavMenuLogic put: {navmenu}");

            navmenu.is_active = 1;

            DBPersist.put(navmenu);
        }

        public  void update(long id, NavMenu navmenu)
        {
            Logger.Debug($"Processing NavMenuLogic update: ID = {id}\n{navmenu}");

            navmenu.id = id;
            DBPersist.update(navmenu);
        }

        public  void delete(long id)
        {
            NavMenu navmenu = get(id);
            navmenu.is_active = 0;
            DBPersist.update(navmenu);
        }
    }
}
