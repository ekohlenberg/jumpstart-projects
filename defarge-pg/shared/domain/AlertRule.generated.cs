

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Alert Rule")]
    public partial class AlertRule : BaseObject
    {
        public AlertRule(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "AlertRule";
            tableName = "app.alert_rule";
            schemaName = "app";
            tableBaseName = "alert_rule";
            auditTableName = "history.app_alert_rule";


            rwk.Add("metric_id");
            
            rwk.Add("name");
            
            rwk.Add("condition");
            

            _defaults["id"] = default(long);
            
            _defaults["metric_id"] = default(long);
            
            _defaults["name"] = default(string);
            
            _defaults["condition"] = default(string);
            
            _defaults["threshold"] = default(decimal);
            
            _defaults["recipients"] = default(string);
            
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
            
            [ColumnInfo("Condition", "", "", "", "")]
            public string condition
            {
                get
                {
                    string _condition;

                            _condition = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("condition"))
                        {
                        _condition = Convert.ToString(this["condition"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting condition: {e.Message}");
                        _condition = default(string);
                    }
                    return _condition;
                }
                set
                {
                   
                    this["condition"] = value;
                }
            }
            
            [ColumnInfo("Threshold", "", "", "", "")]
            public decimal threshold
            {
                get
                {
                    decimal _threshold;

                             _threshold = default(decimal);
                                                 
                    try
                    {
                        if(this.ContainsKey("threshold"))
                        {
                        _threshold = Convert.ToDecimal(this["threshold"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting threshold: {e.Message}");
                        _threshold = default(decimal);
                    }
                    return _threshold;
                }
                set
                {
                   
                    this["threshold"] = value;
                }
            }
            
            [ColumnInfo("Recipients", "", "", "", "")]
            public string recipients
            {
                get
                {
                    string _recipients;

                            _recipients = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("recipients"))
                        {
                        _recipients = Convert.ToString(this["recipients"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting recipients: {e.Message}");
                        _recipients = default(string);
                    }
                    return _recipients;
                }
                set
                {
                   
                    this["recipients"] = value;
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

    public partial class AlertRuleHistory : AlertRule
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "AlertRuleHistory";
            tableName = "history.app_alert_rule";
            tableBaseName = "app_alert_rule";
          

            // Add the foreign key to the original object
            rwk.Add("alert_rule_id");
            _defaults["alert_rule_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Alert Rule ID")]
        public long alert_rule_id
        {
            get
            {
                long _alert_rule_id = default(long);
                
                try
                {
                    if(this.ContainsKey("alert_rule_id"))
                    {
                        _alert_rule_id = Convert.ToInt64(this["alert_rule_id"].ToString());
                    }
                }
                catch(Exception)
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
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class AlertRuleView : AlertRule
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
