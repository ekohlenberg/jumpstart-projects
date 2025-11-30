

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Metric")]
    public partial class Metric : BaseObject
    {
        public Metric(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "Metric";
            tableName = "app.metric";
            schemaName = "app";
            tableBaseName = "metric";
            auditTableName = "history.app_metric";


            rwk.Add("name");
            
            rwk.Add("category_id");
            

            _defaults["id"] = default(long);
            
            _defaults["name"] = default(string);
            
            _defaults["category_id"] = default(long);
            
            _defaults["uom_id"] = default(long);
            
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
            
            [ColumnInfo("Category", "Category", "enum", "category", "category")]
            public long category_id
            {
                get
                {
                    long _category_id;

                             _category_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("category_id"))
                        {
                        _category_id = Convert.ToInt64(this["category_id"].ToString());
                        }
                    }
                    catch(Exception )
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
            
            [ColumnInfo("Unit", "Uom", "enum", "uom", "uom")]
            public long uom_id
            {
                get
                {
                    long _uom_id;

                             _uom_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("uom_id"))
                        {
                        _uom_id = Convert.ToInt64(this["uom_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting uom_id: {e.Message}");
                        _uom_id = default(long);
                    }
                    return _uom_id;
                }
                set
                {
                   
                    this["uom_id"] = value;
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

    public partial class MetricHistory : Metric
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "MetricHistory";
            tableName = "history.app_metric";
            tableBaseName = "app_metric";
          

            // Add the foreign key to the original object
            rwk.Add("metric_id");
            _defaults["metric_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Metric ID")]
        public long metric_id
        {
            get
            {
                long _metric_id = default(long);
                
                try
                {
                    if(this.ContainsKey("metric_id"))
                    {
                        _metric_id = Convert.ToInt64(this["metric_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting metric_id: {e.Message}");
                    _metric_id = default(long);
                }
                return _metric_id;
            }
            set
            {
                this["metric_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class MetricView : Metric
    {

            [ColumnInfo("Category", "Category", "parent", "category", "category")]
            public long category_parent_id
            {
                get
                {
                    long _category_parent_id;

                             _category_parent_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("category_parent_id"))
                        {
                        _category_parent_id = Convert.ToInt64(this["category_parent_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting category_parent_id: {e.Message}");
                        _category_parent_id = default(long);
                    }
                    return _category_parent_id;
                }
                set
                {
                   
                    this["category_parent_id"] = value;
                }
            }
            
            [ColumnInfo("Category", "", "", "", "")]
            public string category_name
            {
                get
                {
                    string _category_name;

                            _category_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("category_name"))
                        {
                        _category_name = Convert.ToString(this["category_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting category_name: {e.Message}");
                        _category_name = default(string);
                    }
                    return _category_name;
                }
                set
                {
                   
                    this["category_name"] = value;
                }
            }
            
            [ColumnInfo("Unit", "", "", "", "")]
            public string uom_name
            {
                get
                {
                    string _uom_name;

                            _uom_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("uom_name"))
                        {
                        _uom_name = Convert.ToString(this["uom_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting uom_name: {e.Message}");
                        _uom_name = default(string);
                    }
                    return _uom_name;
                }
                set
                {
                   
                    this["uom_name"] = value;
                }
            }
                }
}
