

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Metric Resource Map")]
    public partial class MetricResourceMap : BaseObject
    {
        public MetricResourceMap(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "MetricResourceMap";
            tableName = "app.metric_resource_map";
            schemaName = "app";
            tableBaseName = "metric_resource_map";
            auditTableName = "history.app_metric_resource_map";


            rwk.Add("resource_id");
            
            rwk.Add("metric_id");
            

            _defaults["id"] = default(long);
            
            _defaults["resource_id"] = default(long);
            
            _defaults["metric_id"] = default(long);
            
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
            
            [ColumnInfo("Resource", "Resource", "parent", "resource", "resource")]
            public long resource_id
            {
                get
                {
                    long _resource_id;

                             _resource_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("resource_id"))
                        {
                        _resource_id = Convert.ToInt64(this["resource_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting resource_id: {e.Message}");
                        _resource_id = default(long);
                    }
                    return _resource_id;
                }
                set
                {
                   
                    this["resource_id"] = value;
                }
            }
            
            [ColumnInfo("Metric", "Metric", "map", "metric", "metric")]
            public long metric_id
            {
                get
                {
                    long _metric_id;

                             _metric_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("metric_id"))
                        {
                        _metric_id = Convert.ToInt64(this["metric_id"].ToString());
                        }
                    }
                    catch(Exception )
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

    public partial class MetricResourceMapHistory : MetricResourceMap
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "MetricResourceMapHistory";
            tableName = "history.app_metric_resource_map";
            tableBaseName = "app_metric_resource_map";
          

            // Add the foreign key to the original object
            rwk.Add("metric_resource_map_id");
            _defaults["metric_resource_map_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Metric Resource Map ID")]
        public long metric_resource_map_id
        {
            get
            {
                long _metric_resource_map_id = default(long);
                
                try
                {
                    if(this.ContainsKey("metric_resource_map_id"))
                    {
                        _metric_resource_map_id = Convert.ToInt64(this["metric_resource_map_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting metric_resource_map_id: {e.Message}");
                    _metric_resource_map_id = default(long);
                }
                return _metric_resource_map_id;
            }
            set
            {
                this["metric_resource_map_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class MetricResourceMapView : MetricResourceMap
    {

            [ColumnInfo("Resource", "", "", "", "")]
            public string resource_name
            {
                get
                {
                    string _resource_name;

                            _resource_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("resource_name"))
                        {
                        _resource_name = Convert.ToString(this["resource_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting resource_name: {e.Message}");
                        _resource_name = default(string);
                    }
                    return _resource_name;
                }
                set
                {
                   
                    this["resource_name"] = value;
                }
            }
            
            [ColumnInfo("Resource", "ResourceType", "enum", "resource_type", "resourcetype")]
            public long resource_resource_type_id
            {
                get
                {
                    long _resource_resource_type_id;

                             _resource_resource_type_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("resource_resource_type_id"))
                        {
                        _resource_resource_type_id = Convert.ToInt64(this["resource_resource_type_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting resource_resource_type_id: {e.Message}");
                        _resource_resource_type_id = default(long);
                    }
                    return _resource_resource_type_id;
                }
                set
                {
                   
                    this["resource_resource_type_id"] = value;
                }
            }
            
            [ColumnInfo("Resource", "Org", "enum", "org", "org")]
            public long resource_internal_org_id
            {
                get
                {
                    long _resource_internal_org_id;

                             _resource_internal_org_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("resource_internal_org_id"))
                        {
                        _resource_internal_org_id = Convert.ToInt64(this["resource_internal_org_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting resource_internal_org_id: {e.Message}");
                        _resource_internal_org_id = default(long);
                    }
                    return _resource_internal_org_id;
                }
                set
                {
                   
                    this["resource_internal_org_id"] = value;
                }
            }
            
            [ColumnInfo("Resource", "Org", "enum", "org", "org")]
            public long resource_external_org_id
            {
                get
                {
                    long _resource_external_org_id;

                             _resource_external_org_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("resource_external_org_id"))
                        {
                        _resource_external_org_id = Convert.ToInt64(this["resource_external_org_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting resource_external_org_id: {e.Message}");
                        _resource_external_org_id = default(long);
                    }
                    return _resource_external_org_id;
                }
                set
                {
                   
                    this["resource_external_org_id"] = value;
                }
            }
            
            [ColumnInfo("Metric", "", "", "", "")]
            public string metric_name
            {
                get
                {
                    string _metric_name;

                            _metric_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("metric_name"))
                        {
                        _metric_name = Convert.ToString(this["metric_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting metric_name: {e.Message}");
                        _metric_name = default(string);
                    }
                    return _metric_name;
                }
                set
                {
                   
                    this["metric_name"] = value;
                }
            }
            
            [ColumnInfo("Metric", "Category", "enum", "category", "category")]
            public long metric_category_id
            {
                get
                {
                    long _metric_category_id;

                             _metric_category_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("metric_category_id"))
                        {
                        _metric_category_id = Convert.ToInt64(this["metric_category_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting metric_category_id: {e.Message}");
                        _metric_category_id = default(long);
                    }
                    return _metric_category_id;
                }
                set
                {
                   
                    this["metric_category_id"] = value;
                }
            }
                }
}
