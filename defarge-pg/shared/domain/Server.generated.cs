

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Server")]
    public partial class Server : BaseObject
    {
        public Server(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "Server";
            tableName = "core.server";
            schemaName = "core";
            tableBaseName = "server";
            auditTableName = "history.core_server";


            rwk.Add("name");
            
            rwk.Add("type");
            
            rwk.Add("address");
            
            rwk.Add("port");
            

            _defaults["id"] = default(long);
            
            _defaults["name"] = default(string);
            
            _defaults["type"] = default(string);
            
            _defaults["address"] = default(string);
            
            _defaults["port"] = default(int);
            
            _defaults["is_default"] = default(int);
            
            _defaults["is_active"] = default(int);
            
            _defaults["created_by"] = default(string);
            
            _defaults["last_updated"] = default(DateTime);
            
            _defaults["last_updated_by"] = default(string);
            
            _defaults["version"] = default(int);
                    }


            [ColumnInfo("Server ID", "", "", "", "")]
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
            
            [ColumnInfo("Type", "", "", "", "")]
            public string type
            {
                get
                {
                    string _type;

                            _type = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("type"))
                        {
                        _type = Convert.ToString(this["type"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting type: {e.Message}");
                        _type = default(string);
                    }
                    return _type;
                }
                set
                {
                   
                    this["type"] = value;
                }
            }
            
            [ColumnInfo("Address", "", "", "", "")]
            public string address
            {
                get
                {
                    string _address;

                            _address = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("address"))
                        {
                        _address = Convert.ToString(this["address"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting address: {e.Message}");
                        _address = default(string);
                    }
                    return _address;
                }
                set
                {
                   
                    this["address"] = value;
                }
            }
            
            [ColumnInfo("Port", "", "", "", "")]
            public int port
            {
                get
                {
                    int _port;

                             _port = default(int);
                                                 
                    try
                    {
                        if(this.ContainsKey("port"))
                        {
                        _port = Convert.ToInt32(this["port"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting port: {e.Message}");
                        _port = default(int);
                    }
                    return _port;
                }
                set
                {
                   
                    this["port"] = value;
                }
            }
            
            [ColumnInfo("Is Default", "", "", "", "")]
            public int is_default
            {
                get
                {
                    int _is_default;

                             _is_default = default(int);
                                                 
                    try
                    {
                        if(this.ContainsKey("is_default"))
                        {
                        _is_default = Convert.ToInt32(this["is_default"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting is_default: {e.Message}");
                        _is_default = default(int);
                    }
                    return _is_default;
                }
                set
                {
                   
                    this["is_default"] = value;
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

    public partial class ServerHistory : Server
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "ServerHistory";
            tableName = "history.core_server";
            tableBaseName = "core_server";
          

            // Add the foreign key to the original object
            rwk.Add("server_id");
            _defaults["server_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Server ID")]
        public long server_id
        {
            get
            {
                long _server_id = default(long);
                
                try
                {
                    if(this.ContainsKey("server_id"))
                    {
                        _server_id = Convert.ToInt64(this["server_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting server_id: {e.Message}");
                    _server_id = default(long);
                }
                return _server_id;
            }
            set
            {
                this["server_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class ServerView : Server
    {
    }
}
