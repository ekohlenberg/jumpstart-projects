

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("")]
    public partial class WorkflowProcess : BaseObject
    {
        public WorkflowProcess(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "WorkflowProcess";
            tableName = "core.workflow_process";
            schemaName = "core";
            tableBaseName = "workflow_process";
            auditTableName = "history.core_workflow_process";


            rwk.Add("workflow_id");
            
            rwk.Add("process_id");
            

            _defaults["id"] = default(long);
            
            _defaults["workflow_id"] = default(long);
            
            _defaults["process_id"] = default(long);
            
            _defaults["agent_id"] = default(long);
            
            _defaults["seq"] = default(int);
            
            _defaults["on_failure_action_id"] = default(long);
            
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
            
            [ColumnInfo("", "Process", "map", "process", "process")]
            public long process_id
            {
                get
                {
                    long _process_id;

                             _process_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("process_id"))
                        {
                        _process_id = Convert.ToInt64(this["process_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting process_id: {e.Message}");
                        _process_id = default(long);
                    }
                    return _process_id;
                }
                set
                {
                   
                    this["process_id"] = value;
                }
            }
            
            [ColumnInfo("", "Server", "map", "server", "server")]
            public long agent_id
            {
                get
                {
                    long _agent_id;

                             _agent_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("agent_id"))
                        {
                        _agent_id = Convert.ToInt64(this["agent_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting agent_id: {e.Message}");
                        _agent_id = default(long);
                    }
                    return _agent_id;
                }
                set
                {
                   
                    this["agent_id"] = value;
                }
            }
            
            [ColumnInfo("Sequence", "", "", "", "")]
            public int seq
            {
                get
                {
                    int _seq;

                             _seq = default(int);
                                                 
                    try
                    {
                        if(this.ContainsKey("seq"))
                        {
                        _seq = Convert.ToInt32(this["seq"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting seq: {e.Message}");
                        _seq = default(int);
                    }
                    return _seq;
                }
                set
                {
                   
                    this["seq"] = value;
                }
            }
            
            [ColumnInfo("", "OnFailure", "enum", "on_failure", "onfailure")]
            public long on_failure_action_id
            {
                get
                {
                    long _on_failure_action_id;

                             _on_failure_action_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("on_failure_action_id"))
                        {
                        _on_failure_action_id = Convert.ToInt64(this["on_failure_action_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting on_failure_action_id: {e.Message}");
                        _on_failure_action_id = default(long);
                    }
                    return _on_failure_action_id;
                }
                set
                {
                   
                    this["on_failure_action_id"] = value;
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

    public partial class WorkflowProcessHistory : WorkflowProcess
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "WorkflowProcessHistory";
            tableName = "history.core_workflow_process";
            tableBaseName = "core_workflow_process";
          

            // Add the foreign key to the original object
            rwk.Add("workflow_process_id");
            _defaults["workflow_process_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo(" ID")]
        public long workflow_process_id
        {
            get
            {
                long _workflow_process_id = default(long);
                
                try
                {
                    if(this.ContainsKey("workflow_process_id"))
                    {
                        _workflow_process_id = Convert.ToInt64(this["workflow_process_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting workflow_process_id: {e.Message}");
                    _workflow_process_id = default(long);
                }
                return _workflow_process_id;
            }
            set
            {
                this["workflow_process_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class WorkflowProcessView : WorkflowProcess
    {

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
            
            [ColumnInfo("", "", "", "", "")]
            public string process_name
            {
                get
                {
                    string _process_name;

                            _process_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("process_name"))
                        {
                        _process_name = Convert.ToString(this["process_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting process_name: {e.Message}");
                        _process_name = default(string);
                    }
                    return _process_name;
                }
                set
                {
                   
                    this["process_name"] = value;
                }
            }
            
            [ColumnInfo("", "", "", "", "")]
            public string on_failure_action_action
            {
                get
                {
                    string _on_failure_action_action;

                            _on_failure_action_action = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("on_failure_action_action"))
                        {
                        _on_failure_action_action = Convert.ToString(this["on_failure_action_action"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting on_failure_action_action: {e.Message}");
                        _on_failure_action_action = default(string);
                    }
                    return _on_failure_action_action;
                }
                set
                {
                   
                    this["on_failure_action_action"] = value;
                }
            }
                }
}
