
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class CategoryLogic : ICategoryLogic
    {


        public static ICategoryLogic Create()
        {
            var category = new CategoryLogic();

            var proxy = DispatchProxy.Create<ICategoryLogic, Proxy<ICategoryLogic>>();
            ((Proxy<ICategoryLogic>)proxy).Initialize();
            ((Proxy<ICategoryLogic>)proxy).Target = category;
            ((Proxy<ICategoryLogic>)proxy).DomainObj = "Category";

            return proxy;
        }

        public  List<Category> select()
        {
            return select<Category>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing CategoryLogic select<TBaseObject> List");

            List<TBaseObject> categorys = select<TBaseObject>("app.category-select");

            
            return categorys;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing CategoryLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> categorys = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return categorys;
        }

         public  List<CategoryHistory> history(long id)
        {
            List<CategoryHistory> categoryHistory = DBPersist.ExecuteQueryByName<CategoryHistory>("app.category-get-history", new BaseObject() { { "id", id } });

            return categoryHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing CategoryLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "app.category-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Category get(long id)
        {
            Logger.Debug($"Processing CategoryLogic get ID={id}");

            Category category = DBPersist.select<Category>($"SELECT * FROM app.category WHERE id = {id}").FirstOrDefault();
            

            return category;
        }

        public  void insert(Category category)
        {
            Logger.Debug($"Processing CategoryLogic insert: {category}");

            category.is_active = 1;

            DBPersist.insert(category);
        }

        public  void put(Category category)
        {
            Logger.Debug($"Processing CategoryLogic put: {category}");

            category.is_active = 1;

            DBPersist.put(category);
        }

        public  void update(long id, Category category)
        {
            Logger.Debug($"Processing CategoryLogic update: ID = {id}\n{category}");

            category.id = id;
            DBPersist.update(category);
        }

        public  void delete(long id)
        {
            Category category = get(id);
            category.is_active = 0;
            DBPersist.update(category);
        }
    }
}
