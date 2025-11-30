

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Category")]
    public partial class Category : BaseObject
    {
        public Category(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "Category";
            tableName = "app.category";
            schemaName = "app";
            tableBaseName = "category";
            auditTableName = "history.app_category";


            rwk.Add("parent_id");
            
            rwk.Add("name");
            

            _defaults["id"] = default(long);
            
            _defaults["parent_id"] = default(long);
            
            _defaults["name"] = default(string);
            
            _defaults["is_active"] = default(int);
            
            _defaults["created_by"] = default(string);
            
            _defaults["last_updated"] = default(DateTime);
            
            _defaults["last_updated_by"] = default(string);
            
            _defaults["version"] = default(int);
                    }


            [ColumnInfo("ID", "", "", "", "")]
            public long id
            {
                get
                {
                    long _id;

                             _id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("id"))
                        {
                        _id = Convert.ToInt64(this["id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting id: {e.Message}");
                        _id = default(long);
                    }
                    return _id;
                }
                set
                {
                   
                    this["id"] = value;
                }
            }
            
            [ColumnInfo("Parent Category", "Category", "parent", "category", "category")]
            public long parent_id
            {
                get
                {
                    long _parent_id;

                             _parent_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("parent_id"))
                        {
                        _parent_id = Convert.ToInt64(this["parent_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting parent_id: {e.Message}");
                        _parent_id = default(long);
                    }
                    return _parent_id;
                }
                set
                {
                   
                    this["parent_id"] = value;
                }
            }
            
            [ColumnInfo("Name", "", "", "", "")]
            public string name
            {
                get
                {
                    string _name;

                            _name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("name"))
                        {
                        _name = Convert.ToString(this["name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting name: {e.Message}");
                        _name = default(string);
                    }
                    return _name;
                }
                set
                {
                   
                    this["name"] = value;
                }
            }
            
            [ColumnInfo("Active", "", "", "", "")]
            public int is_active
            {
                get
                {
                    int _is_active;

                             _is_active = default(int);
                                                 
                    try
                    {
                        if(this.ContainsKey("is_active"))
                        {
                        _is_active = Convert.ToInt32(this["is_active"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting is_active: {e.Message}");
                        _is_active = default(int);
                    }
                    return _is_active;
                }
                set
                {
                   
                    this["is_active"] = value;
                }
            }
            
            [ColumnInfo("Created By", "", "", "", "")]
            public string created_by
            {
                get
                {
                    string _created_by;

                            _created_by = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("created_by"))
                        {
                        _created_by = Convert.ToString(this["created_by"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting created_by: {e.Message}");
                        _created_by = default(string);
                    }
                    return _created_by;
                }
                set
                {
                   
                    this["created_by"] = value;
                }
            }
            
            [ColumnInfo("Last Updated", "", "", "", "")]
            public DateTime last_updated
            {
                get
                {
                    DateTime _last_updated;

                             _last_updated = default(DateTime);
                                                 
                    try
                    {
                        if(this.ContainsKey("last_updated"))
                        {
                        _last_updated = Convert.ToDateTime(this["last_updated"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting last_updated: {e.Message}");
                        _last_updated = default(DateTime);
                    }
                    return _last_updated;
                }
                set
                {
                   
                    this["last_updated"] = value;
                }
            }
            
            [ColumnInfo("Last Updated By", "", "", "", "")]
            public string last_updated_by
            {
                get
                {
                    string _last_updated_by;

                            _last_updated_by = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("last_updated_by"))
                        {
                        _last_updated_by = Convert.ToString(this["last_updated_by"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting last_updated_by: {e.Message}");
                        _last_updated_by = default(string);
                    }
                    return _last_updated_by;
                }
                set
                {
                   
                    this["last_updated_by"] = value;
                }
            }
            
            [ColumnInfo("Version", "", "", "", "")]
            public int version
            {
                get
                {
                    int _version;

                             _version = default(int);
                                                 
                    try
                    {
                        if(this.ContainsKey("version"))
                        {
                        _version = Convert.ToInt32(this["version"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting version: {e.Message}");
                        _version = default(int);
                    }
                    return _version;
                }
                set
                {
                   
                    this["version"] = value;
                }
            }
                }

    public partial class CategoryHistory : Category
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "CategoryHistory";
            tableName = "history.app_category";
            tableBaseName = "app_category";
          

            // Add the foreign key to the original object
            rwk.Add("category_id");
            _defaults["category_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Category ID")]
        public long category_id
        {
            get
            {
                long _category_id = default(long);
                
                try
                {
                    if(this.ContainsKey("category_id"))
                    {
                        _category_id = Convert.ToInt64(this["category_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting category_id: {e.Message}");
                    _category_id = default(long);
                }
                return _category_id;
            }
            set
            {
                this["category_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class CategoryView : Category
    {

            [ColumnInfo("Parent Category", "Category", "parent", "category", "category")]
            public long parent_parent_id
            {
                get
                {
                    long _parent_parent_id;

                             _parent_parent_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("parent_parent_id"))
                        {
                        _parent_parent_id = Convert.ToInt64(this["parent_parent_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting parent_parent_id: {e.Message}");
                        _parent_parent_id = default(long);
                    }
                    return _parent_parent_id;
                }
                set
                {
                   
                    this["parent_parent_id"] = value;
                }
            }
            
            [ColumnInfo("Parent Category", "", "", "", "")]
            public string parent_name
            {
                get
                {
                    string _parent_name;

                            _parent_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("parent_name"))
                        {
                        _parent_name = Convert.ToString(this["parent_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting parent_name: {e.Message}");
                        _parent_name = default(string);
                    }
                    return _parent_name;
                }
                set
                {
                   
                    this["parent_name"] = value;
                }
            }
                }
}
