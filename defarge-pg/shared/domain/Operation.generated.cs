

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Operations")]
    public partial class Operation : BaseObject
    {
        public Operation(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "Operation";
            tableName = "sec.operation";
            schemaName = "sec";
            tableBaseName = "operation";
            auditTableName = "history.sec_operation";


            rwk.Add("objectname");
            
            rwk.Add("methodname");
            

            _defaults["id"] = default(long);
            
            _defaults["objectname"] = default(string);
            
            _defaults["methodname"] = default(string);
            
            _defaults["is_active"] = default(int);
            
            _defaults["created_by"] = default(string);
            
            _defaults["last_updated"] = default(DateTime);
            
            _defaults["last_updated_by"] = default(string);
            
            _defaults["version"] = default(int);
                    }


            [ColumnInfo("Action ID", "", "", "", "")]
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
            
            [ColumnInfo("Object", "", "", "", "")]
            public string objectname
            {
                get
                {
                    string _objectname;

                            _objectname = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("objectname"))
                        {
                        _objectname = Convert.ToString(this["objectname"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting objectname: {e.Message}");
                        _objectname = default(string);
                    }
                    return _objectname;
                }
                set
                {
                   
                    this["objectname"] = value;
                }
            }
            
            [ColumnInfo("Method", "", "", "", "")]
            public string methodname
            {
                get
                {
                    string _methodname;

                            _methodname = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("methodname"))
                        {
                        _methodname = Convert.ToString(this["methodname"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting methodname: {e.Message}");
                        _methodname = default(string);
                    }
                    return _methodname;
                }
                set
                {
                   
                    this["methodname"] = value;
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

    public partial class OperationHistory : Operation
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "OperationHistory";
            tableName = "history.sec_operation";
            tableBaseName = "sec_operation";
          

            // Add the foreign key to the original object
            rwk.Add("operation_id");
            _defaults["operation_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Operations ID")]
        public long operation_id
        {
            get
            {
                long _operation_id = default(long);
                
                try
                {
                    if(this.ContainsKey("operation_id"))
                    {
                        _operation_id = Convert.ToInt64(this["operation_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting operation_id: {e.Message}");
                    _operation_id = default(long);
                }
                return _operation_id;
            }
            set
            {
                this["operation_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class OperationView : Operation
    {
    }
}
