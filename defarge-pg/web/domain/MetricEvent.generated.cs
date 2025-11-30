

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Metric Event")]
    public partial class MetricEvent : BaseObject
    {
        public MetricEvent(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "MetricEvent";
            tableName = "app.metric_event";
            schemaName = "app";
            tableBaseName = "metric_event";
            auditTableName = "history.app_metric_event";


            rwk.Add("metric_id");
            
            rwk.Add("event_time");
            

            _defaults["id"] = default(long);
            
            _defaults["metric_id"] = default(long);
            
            _defaults["event_time"] = default(DateTime);
            
            _defaults["value"] = default(decimal);
            
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
            
            [ColumnInfo("Metric", "Metric", "parent", "metric", "metric")]
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
            
            [ColumnInfo("Event Time", "", "", "", "")]
            public DateTime event_time
            {
                get
                {
                    DateTime _event_time;

                             _event_time = default(DateTime);
                                                 
                    try
                    {
                        if(this.ContainsKey("event_time"))
                        {
                        _event_time = Convert.ToDateTime(this["event_time"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting event_time: {e.Message}");
                        _event_time = default(DateTime);
                    }
                    return _event_time;
                }
                set
                {
                   
                    this["event_time"] = value;
                }
            }
            
            [ColumnInfo("Value", "", "", "", "")]
            public decimal value
            {
                get
                {
                    decimal _value;

                             _value = default(decimal);
                                                 
                    try
                    {
                        if(this.ContainsKey("value"))
                        {
                        _value = Convert.ToDecimal(this["value"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting value: {e.Message}");
                        _value = default(decimal);
                    }
                    return _value;
                }
                set
                {
                   
                    this["value"] = value;
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

    public partial class MetricEventHistory : MetricEvent
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "MetricEventHistory";
            tableName = "history.app_metric_event";
            tableBaseName = "app_metric_event";
          

            // Add the foreign key to the original object
            rwk.Add("metric_event_id");
            _defaults["metric_event_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Metric Event ID")]
        public long metric_event_id
        {
            get
            {
                long _metric_event_id = default(long);
                
                try
                {
                    if(this.ContainsKey("metric_event_id"))
                    {
                        _metric_event_id = Convert.ToInt64(this["metric_event_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting metric_event_id: {e.Message}");
                    _metric_event_id = default(long);
                }
                return _metric_event_id;
            }
            set
            {
                this["metric_event_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class MetricEventView : MetricEvent
    {

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
