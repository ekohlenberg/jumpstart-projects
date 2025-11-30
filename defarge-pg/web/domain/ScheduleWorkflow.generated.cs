

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("")]
    public partial class ScheduleWorkflow : BaseObject
    {
        public ScheduleWorkflow(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "ScheduleWorkflow";
            tableName = "core.schedule_workflow";
            schemaName = "core";
            tableBaseName = "schedule_workflow";
            auditTableName = "history.core_schedule_workflow";



            _defaults["id"] = default(long);
            
            _defaults["schedule_id"] = default(long);
            
            _defaults["workflow_id"] = default(long);
            
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
            
            [ColumnInfo("", "Schedule", "map", "schedule", "schedule")]
            public long schedule_id
            {
                get
                {
                    long _schedule_id;

                             _schedule_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("schedule_id"))
                        {
                        _schedule_id = Convert.ToInt64(this["schedule_id"].ToString());
                        }
                    }
                    catch(Exception )
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
            
            [ColumnInfo("", "Workflow", "map", "workflow", "workflow")]
            public long workflow_id
            {
                get
                {
                    long _workflow_id;

                             _workflow_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("workflow_id"))
                        {
                        _workflow_id = Convert.ToInt64(this["workflow_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting workflow_id: {e.Message}");
                        _workflow_id = default(long);
                    }
                    return _workflow_id;
                }
                set
                {
                   
                    this["workflow_id"] = value;
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

    public partial class ScheduleWorkflowHistory : ScheduleWorkflow
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "ScheduleWorkflowHistory";
            tableName = "history.core_schedule_workflow";
            tableBaseName = "core_schedule_workflow";
          

            // Add the foreign key to the original object
            rwk.Add("schedule_workflow_id");
            _defaults["schedule_workflow_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo(" ID")]
        public long schedule_workflow_id
        {
            get
            {
                long _schedule_workflow_id = default(long);
                
                try
                {
                    if(this.ContainsKey("schedule_workflow_id"))
                    {
                        _schedule_workflow_id = Convert.ToInt64(this["schedule_workflow_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting schedule_workflow_id: {e.Message}");
                    _schedule_workflow_id = default(long);
                }
                return _schedule_workflow_id;
            }
            set
            {
                this["schedule_workflow_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class ScheduleWorkflowView : ScheduleWorkflow
    {

            [ColumnInfo("", "", "", "", "")]
            public string schedule_cron_expression
            {
                get
                {
                    string _schedule_cron_expression;

                            _schedule_cron_expression = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("schedule_cron_expression"))
                        {
                        _schedule_cron_expression = Convert.ToString(this["schedule_cron_expression"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting schedule_cron_expression: {e.Message}");
                        _schedule_cron_expression = default(string);
                    }
                    return _schedule_cron_expression;
                }
                set
                {
                   
                    this["schedule_cron_expression"] = value;
                }
            }
            
            [ColumnInfo("", "Workflow", "parent", "workflow", "workflow")]
            public long workflow_parent_workflow_id
            {
                get
                {
                    long _workflow_parent_workflow_id;

                             _workflow_parent_workflow_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("workflow_parent_workflow_id"))
                        {
                        _workflow_parent_workflow_id = Convert.ToInt64(this["workflow_parent_workflow_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting workflow_parent_workflow_id: {e.Message}");
                        _workflow_parent_workflow_id = default(long);
                    }
                    return _workflow_parent_workflow_id;
                }
                set
                {
                   
                    this["workflow_parent_workflow_id"] = value;
                }
            }
            
            [ColumnInfo("", "", "", "", "")]
            public string workflow_name
            {
                get
                {
                    string _workflow_name;

                            _workflow_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("workflow_name"))
                        {
                        _workflow_name = Convert.ToString(this["workflow_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting workflow_name: {e.Message}");
                        _workflow_name = default(string);
                    }
                    return _workflow_name;
                }
                set
                {
                   
                    this["workflow_name"] = value;
                }
            }
                }
}
