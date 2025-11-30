

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Alert")]
    public partial class Alert : BaseObject
    {
        public Alert(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "Alert";
            tableName = "app.alert";
            schemaName = "app";
            tableBaseName = "alert";
            auditTableName = "history.app_alert";


            rwk.Add("alert_rule_id");
            
            rwk.Add("metric_event_id");
            
            rwk.Add("triggered_at");
            

            _defaults["id"] = default(long);
            
            _defaults["alert_rule_id"] = default(long);
            
            _defaults["metric_event_id"] = default(long);
            
            _defaults["triggered_at"] = default(DateTime);
            
            _defaults["resolved_at"] = default(DateTime);
            
            _defaults["status"] = default(string);
            
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
            
            [ColumnInfo("Alert", "AlertRule", "map", "alert_rule", "alertrule")]
            public long alert_rule_id
            {
                get
                {
                    long _alert_rule_id;

                             _alert_rule_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("alert_rule_id"))
                        {
                        _alert_rule_id = Convert.ToInt64(this["alert_rule_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting alert_rule_id: {e.Message}");
                        _alert_rule_id = default(long);
                    }
                    return _alert_rule_id;
                }
                set
                {
                   
                    this["alert_rule_id"] = value;
                }
            }
            
            [ColumnInfo("Metric", "MetricEvent", "map", "metric_event", "metricevent")]
            public long metric_event_id
            {
                get
                {
                    long _metric_event_id;

                             _metric_event_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("metric_event_id"))
                        {
                        _metric_event_id = Convert.ToInt64(this["metric_event_id"].ToString());
                        }
                    }
                    catch(Exception )
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
            
            [ColumnInfo("Triggered", "", "", "", "")]
            public DateTime triggered_at
            {
                get
                {
                    DateTime _triggered_at;

                             _triggered_at = default(DateTime);
                                                 
                    try
                    {
                        if(this.ContainsKey("triggered_at"))
                        {
                        _triggered_at = Convert.ToDateTime(this["triggered_at"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting triggered_at: {e.Message}");
                        _triggered_at = default(DateTime);
                    }
                    return _triggered_at;
                }
                set
                {
                   
                    this["triggered_at"] = value;
                }
            }
            
            [ColumnInfo("Resolved", "", "", "", "")]
            public DateTime resolved_at
            {
                get
                {
                    DateTime _resolved_at;

                             _resolved_at = default(DateTime);
                                                 
                    try
                    {
                        if(this.ContainsKey("resolved_at"))
                        {
                        _resolved_at = Convert.ToDateTime(this["resolved_at"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting resolved_at: {e.Message}");
                        _resolved_at = default(DateTime);
                    }
                    return _resolved_at;
                }
                set
                {
                   
                    this["resolved_at"] = value;
                }
            }
            
            [ColumnInfo("Status", "", "", "", "")]
            public string status
            {
                get
                {
                    string _status;

                            _status = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("status"))
                        {
                        _status = Convert.ToString(this["status"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting status: {e.Message}");
                        _status = default(string);
                    }
                    return _status;
                }
                set
                {
                   
                    this["status"] = value;
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

    public partial class AlertHistory : Alert
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "AlertHistory";
            tableName = "history.app_alert";
            tableBaseName = "app_alert";
          

            // Add the foreign key to the original object
            rwk.Add("alert_id");
            _defaults["alert_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Alert ID")]
        public long alert_id
        {
            get
            {
                long _alert_id = default(long);
                
                try
                {
                    if(this.ContainsKey("alert_id"))
                    {
                        _alert_id = Convert.ToInt64(this["alert_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting alert_id: {e.Message}");
                    _alert_id = default(long);
                }
                return _alert_id;
            }
            set
            {
                this["alert_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class AlertView : Alert
    {

            [ColumnInfo("Alert", "Metric", "parent", "metric", "metric")]
            public long alert_rule_metric_id
            {
                get
                {
                    long _alert_rule_metric_id;

                             _alert_rule_metric_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("alert_rule_metric_id"))
                        {
                        _alert_rule_metric_id = Convert.ToInt64(this["alert_rule_metric_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting alert_rule_metric_id: {e.Message}");
                        _alert_rule_metric_id = default(long);
                    }
                    return _alert_rule_metric_id;
                }
                set
                {
                   
                    this["alert_rule_metric_id"] = value;
                }
            }
            
            [ColumnInfo("Alert", "", "", "", "")]
            public string alert_rule_name
            {
                get
                {
                    string _alert_rule_name;

                            _alert_rule_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("alert_rule_name"))
                        {
                        _alert_rule_name = Convert.ToString(this["alert_rule_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting alert_rule_name: {e.Message}");
                        _alert_rule_name = default(string);
                    }
                    return _alert_rule_name;
                }
                set
                {
                   
                    this["alert_rule_name"] = value;
                }
            }
            
            [ColumnInfo("Alert", "", "", "", "")]
            public string alert_rule_condition
            {
                get
                {
                    string _alert_rule_condition;

                            _alert_rule_condition = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("alert_rule_condition"))
                        {
                        _alert_rule_condition = Convert.ToString(this["alert_rule_condition"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting alert_rule_condition: {e.Message}");
                        _alert_rule_condition = default(string);
                    }
                    return _alert_rule_condition;
                }
                set
                {
                   
                    this["alert_rule_condition"] = value;
                }
            }
            
            [ColumnInfo("Metric", "Metric", "parent", "metric", "metric")]
            public long metric_event_metric_id
            {
                get
                {
                    long _metric_event_metric_id;

                             _metric_event_metric_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("metric_event_metric_id"))
                        {
                        _metric_event_metric_id = Convert.ToInt64(this["metric_event_metric_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting metric_event_metric_id: {e.Message}");
                        _metric_event_metric_id = default(long);
                    }
                    return _metric_event_metric_id;
                }
                set
                {
                   
                    this["metric_event_metric_id"] = value;
                }
            }
            
            [ColumnInfo("Metric", "", "", "", "")]
            public DateTime metric_event_event_time
            {
                get
                {
                    DateTime _metric_event_event_time;

                             _metric_event_event_time = default(DateTime);
                                                 
                    try
                    {
                        if(this.ContainsKey("metric_event_event_time"))
                        {
                        _metric_event_event_time = Convert.ToDateTime(this["metric_event_event_time"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting metric_event_event_time: {e.Message}");
                        _metric_event_event_time = default(DateTime);
                    }
                    return _metric_event_event_time;
                }
                set
                {
                   
                    this["metric_event_event_time"] = value;
                }
            }
                }
}
