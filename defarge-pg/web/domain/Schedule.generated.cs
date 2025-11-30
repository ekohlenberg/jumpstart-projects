

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Schedule")]
    public partial class Schedule : BaseObject
    {
        public Schedule(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "Schedule";
            tableName = "core.schedule";
            schemaName = "core";
            tableBaseName = "schedule";
            auditTableName = "history.core_schedule";


            rwk.Add("cron_expression");
            

            _defaults["id"] = default(long);
            
            _defaults["cron_expression"] = default(string);
            
            _defaults["next_run_time"] = default(DateTime);
            
            _defaults["last_run_time"] = default(DateTime);
            
            _defaults["status"] = default(string);
            
            _defaults["is_active"] = default(int);
            
            _defaults["created_by"] = default(string);
            
            _defaults["last_updated"] = default(DateTime);
            
            _defaults["last_updated_by"] = default(string);
            
            _defaults["version"] = default(int);
                    }


            [ColumnInfo("", "", "", "", "")]
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
            
            [ColumnInfo("", "", "", "", "")]
            public string cron_expression
            {
                get
                {
                    string _cron_expression;

                            _cron_expression = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("cron_expression"))
                        {
                        _cron_expression = Convert.ToString(this["cron_expression"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting cron_expression: {e.Message}");
                        _cron_expression = default(string);
                    }
                    return _cron_expression;
                }
                set
                {
                   
                    this["cron_expression"] = value;
                }
            }
            
            [ColumnInfo("", "", "", "", "")]
            public DateTime next_run_time
            {
                get
                {
                    DateTime _next_run_time;

                             _next_run_time = default(DateTime);
                                                 
                    try
                    {
                        if(this.ContainsKey("next_run_time"))
                        {
                        _next_run_time = Convert.ToDateTime(this["next_run_time"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting next_run_time: {e.Message}");
                        _next_run_time = default(DateTime);
                    }
                    return _next_run_time;
                }
                set
                {
                   
                    this["next_run_time"] = value;
                }
            }
            
            [ColumnInfo("", "", "", "", "")]
            public DateTime last_run_time
            {
                get
                {
                    DateTime _last_run_time;

                             _last_run_time = default(DateTime);
                                                 
                    try
                    {
                        if(this.ContainsKey("last_run_time"))
                        {
                        _last_run_time = Convert.ToDateTime(this["last_run_time"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting last_run_time: {e.Message}");
                        _last_run_time = default(DateTime);
                    }
                    return _last_run_time;
                }
                set
                {
                   
                    this["last_run_time"] = value;
                }
            }
            
            [ColumnInfo("", "", "", "", "")]
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

    public partial class ScheduleHistory : Schedule
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "ScheduleHistory";
            tableName = "history.core_schedule";
            tableBaseName = "core_schedule";
          

            // Add the foreign key to the original object
            rwk.Add("schedule_id");
            _defaults["schedule_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Schedule ID")]
        public long schedule_id
        {
            get
            {
                long _schedule_id = default(long);
                
                try
                {
                    if(this.ContainsKey("schedule_id"))
                    {
                        _schedule_id = Convert.ToInt64(this["schedule_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting schedule_id: {e.Message}");
                    _schedule_id = default(long);
                }
                return _schedule_id;
            }
            set
            {
                this["schedule_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class ScheduleView : Schedule
    {
    }
}
