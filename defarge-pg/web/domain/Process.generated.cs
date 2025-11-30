

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Process")]
    public partial class Process : BaseObject
    {
        public Process(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "Process";
            tableName = "core.process";
            schemaName = "core";
            tableBaseName = "process";
            auditTableName = "history.core_process";


            rwk.Add("name");
            

            _defaults["id"] = default(long);
            
            _defaults["name"] = default(string);
            
            _defaults["script_id"] = default(long);
            
            _defaults["is_active"] = default(int);
            
            _defaults["created_by"] = default(string);
            
            _defaults["last_updated"] = default(DateTime);
            
            _defaults["last_updated_by"] = default(string);
            
            _defaults["version"] = default(int);
                    }


            [ColumnInfo("Process ID", "", "", "", "")]
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
            
            [ColumnInfo("Script", "Script", "rwk", "script", "script")]
            public long script_id
            {
                get
                {
                    long _script_id;

                             _script_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("script_id"))
                        {
                        _script_id = Convert.ToInt64(this["script_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting script_id: {e.Message}");
                        _script_id = default(long);
                    }
                    return _script_id;
                }
                set
                {
                   
                    this["script_id"] = value;
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

    public partial class ProcessHistory : Process
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "ProcessHistory";
            tableName = "history.core_process";
            tableBaseName = "core_process";
          

            // Add the foreign key to the original object
            rwk.Add("process_id");
            _defaults["process_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Process ID")]
        public long process_id
        {
            get
            {
                long _process_id = default(long);
                
                try
                {
                    if(this.ContainsKey("process_id"))
                    {
                        _process_id = Convert.ToInt64(this["process_id"].ToString());
                    }
                }
                catch(Exception)
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
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class ProcessView : Process
    {

            [ColumnInfo("Script", "", "", "", "")]
            public string script_name
            {
                get
                {
                    string _script_name;

                            _script_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("script_name"))
                        {
                        _script_name = Convert.ToString(this["script_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting script_name: {e.Message}");
                        _script_name = default(string);
                    }
                    return _script_name;
                }
                set
                {
                   
                    this["script_name"] = value;
                }
            }
            
            [ColumnInfo("Script", "ScriptType", "enum", "script_type", "scripttype")]
            public long script_script_type_id
            {
                get
                {
                    long _script_script_type_id;

                             _script_script_type_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("script_script_type_id"))
                        {
                        _script_script_type_id = Convert.ToInt64(this["script_script_type_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting script_script_type_id: {e.Message}");
                        _script_script_type_id = default(long);
                    }
                    return _script_script_type_id;
                }
                set
                {
                   
                    this["script_script_type_id"] = value;
                }
            }
                }
}
