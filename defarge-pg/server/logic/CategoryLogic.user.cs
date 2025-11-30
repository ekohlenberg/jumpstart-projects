
using System;


namespace defarge
{
    public interface ICategoryLogic
    {  
        // Generated methods
        List<Category> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<CategoryHistory> history(long id);
        Category get(long id);
        void insert(Category category);
        void update(long id, Category category);
        void put(Category category);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class CategoryLogic
    {
        protected CategoryLogic()
        {
           
        }
        
    }
}

