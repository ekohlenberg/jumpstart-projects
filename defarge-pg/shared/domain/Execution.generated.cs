

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Execution Log")]
    public partial class Execution : BaseObject
    {
        public Execution(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "Execution";
            tableName = "core.execution";
            schemaName = "core";
            tableBaseName = "execution";
            auditTableName = "history.core_execution";


            rwk.Add("token");
            
            rwk.Add("workflow_process_id");
            
            rwk.Add("start_time");
            
            rwk.Add("end_time");
            

            _defaults["id"] = default(long);
            
            _defaults["token"] = default(string);
            
            _defaults["workflow_process_id"] = default(long);
            
            _defaults["start_time"] = default(DateTime);
            
            _defaults["end_time"] = default(DateTime);
            
            _defaults["exec_status_id"] = default(long);
            
            _defaults["stdout"] = default(string);
            
            _defaults["stderr"] = default(string);
            
            _defaults["is_active"] = default(int);
            
            _defaults["created_by"] = default(string);
            
            _defaults["last_updated"] = default(DateTime);
            
            _defaults["last_updated_by"] = default(string);
            
            _defaults["version"] = default(int);
                    }


            [ColumnInfo("Execution ID", "", "", "", "")]
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
            
            [ColumnInfo("Token", "", "", "", "")]
            public string token
            {
                get
                {
                    string _token;

                            _token = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("token"))
                        {
                        _token = Convert.ToString(this["token"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting token: {e.Message}");
                        _token = default(string);
                    }
                    return _token;
                }
                set
                {
                   
                    this["token"] = value;
                }
            }
            
            [ColumnInfo("Process", "Process", "rwk", "process", "process")]
            public long workflow_process_id
            {
                get
                {
                    long _workflow_process_id;

                             _workflow_process_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("workflow_process_id"))
                        {
                        _workflow_process_id = Convert.ToInt64(this["workflow_process_id"].ToString());
                        }
                    }
                    catch(Exception )
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
            
            [ColumnInfo("Start Time", "", "", "", "")]
            public DateTime start_time
            {
                get
                {
                    DateTime _start_time;

                             _start_time = default(DateTime);
                                                 
                    try
                    {
                        if(this.ContainsKey("start_time"))
                        {
                        _start_time = Convert.ToDateTime(this["start_time"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting start_time: {e.Message}");
                        _start_time = default(DateTime);
                    }
                    return _start_time;
                }
                set
                {
                   
                    this["start_time"] = value;
                }
            }
            
            [ColumnInfo("End Time", "", "", "", "")]
            public DateTime end_time
            {
                get
                {
                    DateTime _end_time;

                             _end_time = default(DateTime);
                                                 
                    try
                    {
                        if(this.ContainsKey("end_time"))
                        {
                        _end_time = Convert.ToDateTime(this["end_time"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting end_time: {e.Message}");
                        _end_time = default(DateTime);
                    }
                    return _end_time;
                }
                set
                {
                   
                    this["end_time"] = value;
                }
            }
            
            [ColumnInfo("Status", "", "", "", "")]
            public long exec_status_id
            {
                get
                {
                    long _exec_status_id;

                             _exec_status_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("exec_status_id"))
                        {
                        _exec_status_id = Convert.ToInt64(this["exec_status_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting exec_status_id: {e.Message}");
                        _exec_status_id = default(long);
                    }
                    return _exec_status_id;
                }
                set
                {
                   
                    this["exec_status_id"] = value;
                }
            }
            
            [ColumnInfo("Stdout", "", "", "", "")]
            public string stdout
            {
                get
                {
                    string _stdout;

                            _stdout = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("stdout"))
                        {
                        _stdout = Convert.ToString(this["stdout"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting stdout: {e.Message}");
                        _stdout = default(string);
                    }
                    return _stdout;
                }
                set
                {
                   
                    this["stdout"] = value;
                }
            }
            
            [ColumnInfo("Stderr", "", "", "", "")]
            public string stderr
            {
                get
                {
                    string _stderr;

                            _stderr = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("stderr"))
                        {
                        _stderr = Convert.ToString(this["stderr"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting stderr: {e.Message}");
                        _stderr = default(string);
                    }
                    return _stderr;
                }
                set
                {
                   
                    this["stderr"] = value;
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

    public partial class ExecutionHistory : Execution
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "ExecutionHistory";
            tableName = "history.core_execution";
            tableBaseName = "core_execution";
          

            // Add the foreign key to the original object
            rwk.Add("execution_id");
            _defaults["execution_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Execution Log ID")]
        public long execution_id
        {
            get
            {
                long _execution_id = default(long);
                
                try
                {
                    if(this.ContainsKey("execution_id"))
                    {
                        _execution_id = Convert.ToInt64(this["execution_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting execution_id: {e.Message}");
                    _execution_id = default(long);
                }
                return _execution_id;
            }
            set
            {
                this["execution_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class ExecutionView : Execution
    {

            [ColumnInfo("Process", "", "", "", "")]
            public string workflow_process_name
            {
                get
                {
                    string _workflow_process_name;

                            _workflow_process_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("workflow_process_name"))
                        {
                        _workflow_process_name = Convert.ToString(this["workflow_process_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting workflow_process_name: {e.Message}");
                        _workflow_process_name = default(string);
                    }
                    return _workflow_process_name;
                }
                set
                {
                   
                    this["workflow_process_name"] = value;
                }
            }
                }
}
