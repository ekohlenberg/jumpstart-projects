

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("On Failure Code")]
    public partial class OnFailure : BaseObject
    {
        public OnFailure(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "OnFailure";
            tableName = "core.on_failure";
            schemaName = "core";
            tableBaseName = "on_failure";
            auditTableName = "history.core_on_failure";


            rwk.Add("action");
            

            _defaults["id"] = default(long);
            
            _defaults["action"] = default(string);
            
            _defaults["is_active"] = default(int);
            
            _defaults["created_by"] = default(string);
            
            _defaults["last_updated"] = default(DateTime);
            
            _defaults["last_updated_by"] = default(string);
            
            _defaults["version"] = default(int);
                    }


            [ColumnInfo("On Failure ID", "", "", "", "")]
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
            
            [ColumnInfo("Action", "", "", "", "")]
            public string action
            {
                get
                {
                    string _action;

                            _action = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("action"))
                        {
                        _action = Convert.ToString(this["action"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting action: {e.Message}");
                        _action = default(string);
                    }
                    return _action;
                }
                set
                {
                   
                    this["action"] = value;
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

    public partial class OnFailureHistory : OnFailure
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "OnFailureHistory";
            tableName = "history.core_on_failure";
            tableBaseName = "core_on_failure";
          

            // Add the foreign key to the original object
            rwk.Add("on_failure_id");
            _defaults["on_failure_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("On Failure Code ID")]
        public long on_failure_id
        {
            get
            {
                long _on_failure_id = default(long);
                
                try
                {
                    if(this.ContainsKey("on_failure_id"))
                    {
                        _on_failure_id = Convert.ToInt64(this["on_failure_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting on_failure_id: {e.Message}");
                    _on_failure_id = default(long);
                }
                return _on_failure_id;
            }
            set
            {
                this["on_failure_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class OnFailureView : OnFailure
    {
    }
}
