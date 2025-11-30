

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Scheduler")]
    public partial class Scheduler : BaseObject
    {
        public Scheduler(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "Scheduler";
            tableName = "core.scheduler";
            schemaName = "core";
            tableBaseName = "scheduler";
            auditTableName = "history.core_scheduler";


            rwk.Add("hostname");
            
            rwk.Add("ip_address");
            
            rwk.Add("port");
            

            _defaults["id"] = default(long);
            
            _defaults["hostname"] = default(string);
            
            _defaults["ip_address"] = default(string);
            
            _defaults["port"] = default(int);
            
            _defaults["username"] = default(string);
            
            _defaults["url"] = default(string);
            
            _defaults["user_domain"] = default(string);
            
            _defaults["os_name"] = default(string);
            
            _defaults["os_version"] = default(string);
            
            _defaults["architecture"] = default(string);
            
            _defaults["registered_at"] = default(DateTime);
            
            _defaults["scheduler_status_id"] = default(long);
            
            _defaults["is_active"] = default(int);
            
            _defaults["created_by"] = default(string);
            
            _defaults["last_updated"] = default(DateTime);
            
            _defaults["last_updated_by"] = default(string);
            
            _defaults["version"] = default(int);
                    }


            [ColumnInfo("Scheduler ID", "", "", "", "")]
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
            
            [ColumnInfo("Hostname", "", "", "", "")]
            public string hostname
            {
                get
                {
                    string _hostname;

                            _hostname = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("hostname"))
                        {
                        _hostname = Convert.ToString(this["hostname"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting hostname: {e.Message}");
                        _hostname = default(string);
                    }
                    return _hostname;
                }
                set
                {
                   
                    this["hostname"] = value;
                }
            }
            
            [ColumnInfo("Address", "", "", "", "")]
            public string ip_address
            {
                get
                {
                    string _ip_address;

                            _ip_address = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("ip_address"))
                        {
                        _ip_address = Convert.ToString(this["ip_address"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting ip_address: {e.Message}");
                        _ip_address = default(string);
                    }
                    return _ip_address;
                }
                set
                {
                   
                    this["ip_address"] = value;
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
            
            [ColumnInfo("Username", "", "", "", "")]
            public string username
            {
                get
                {
                    string _username;

                            _username = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("username"))
                        {
                        _username = Convert.ToString(this["username"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting username: {e.Message}");
                        _username = default(string);
                    }
                    return _username;
                }
                set
                {
                   
                    this["username"] = value;
                }
            }
            
            [ColumnInfo("URL", "", "", "", "")]
            public string url
            {
                get
                {
                    string _url;

                            _url = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("url"))
                        {
                        _url = Convert.ToString(this["url"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting url: {e.Message}");
                        _url = default(string);
                    }
                    return _url;
                }
                set
                {
                   
                    this["url"] = value;
                }
            }
            
            [ColumnInfo("User Domani", "", "", "", "")]
            public string user_domain
            {
                get
                {
                    string _user_domain;

                            _user_domain = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("user_domain"))
                        {
                        _user_domain = Convert.ToString(this["user_domain"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting user_domain: {e.Message}");
                        _user_domain = default(string);
                    }
                    return _user_domain;
                }
                set
                {
                   
                    this["user_domain"] = value;
                }
            }
            
            [ColumnInfo("OS Name", "", "", "", "")]
            public string os_name
            {
                get
                {
                    string _os_name;

                            _os_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("os_name"))
                        {
                        _os_name = Convert.ToString(this["os_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting os_name: {e.Message}");
                        _os_name = default(string);
                    }
                    return _os_name;
                }
                set
                {
                   
                    this["os_name"] = value;
                }
            }
            
            [ColumnInfo("OS Version", "", "", "", "")]
            public string os_version
            {
                get
                {
                    string _os_version;

                            _os_version = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("os_version"))
                        {
                        _os_version = Convert.ToString(this["os_version"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting os_version: {e.Message}");
                        _os_version = default(string);
                    }
                    return _os_version;
                }
                set
                {
                   
                    this["os_version"] = value;
                }
            }
            
            [ColumnInfo("Architecture", "", "", "", "")]
            public string architecture
            {
                get
                {
                    string _architecture;

                            _architecture = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("architecture"))
                        {
                        _architecture = Convert.ToString(this["architecture"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting architecture: {e.Message}");
                        _architecture = default(string);
                    }
                    return _architecture;
                }
                set
                {
                   
                    this["architecture"] = value;
                }
            }
            
            [ColumnInfo("Registered At", "", "", "", "")]
            public DateTime registered_at
            {
                get
                {
                    DateTime _registered_at;

                             _registered_at = default(DateTime);
                                                 
                    try
                    {
                        if(this.ContainsKey("registered_at"))
                        {
                        _registered_at = Convert.ToDateTime(this["registered_at"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting registered_at: {e.Message}");
                        _registered_at = default(DateTime);
                    }
                    return _registered_at;
                }
                set
                {
                   
                    this["registered_at"] = value;
                }
            }
            
            [ColumnInfo("Status", "SchedulerStatus", "enum", "scheduler_status", "schedulerstatus")]
            public long scheduler_status_id
            {
                get
                {
                    long _scheduler_status_id;

                             _scheduler_status_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("scheduler_status_id"))
                        {
                        _scheduler_status_id = Convert.ToInt64(this["scheduler_status_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting scheduler_status_id: {e.Message}");
                        _scheduler_status_id = default(long);
                    }
                    return _scheduler_status_id;
                }
                set
                {
                   
                    this["scheduler_status_id"] = value;
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

    public partial class SchedulerHistory : Scheduler
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "SchedulerHistory";
            tableName = "history.core_scheduler";
            tableBaseName = "core_scheduler";
          

            // Add the foreign key to the original object
            rwk.Add("scheduler_id");
            _defaults["scheduler_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Scheduler ID")]
        public long scheduler_id
        {
            get
            {
                long _scheduler_id = default(long);
                
                try
                {
                    if(this.ContainsKey("scheduler_id"))
                    {
                        _scheduler_id = Convert.ToInt64(this["scheduler_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting scheduler_id: {e.Message}");
                    _scheduler_id = default(long);
                }
                return _scheduler_id;
            }
            set
            {
                this["scheduler_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class SchedulerView : Scheduler
    {

            [ColumnInfo("Status", "", "", "", "")]
            public string scheduler_status_name
            {
                get
                {
                    string _scheduler_status_name;

                            _scheduler_status_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("scheduler_status_name"))
                        {
                        _scheduler_status_name = Convert.ToString(this["scheduler_status_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting scheduler_status_name: {e.Message}");
                        _scheduler_status_name = default(string);
                    }
                    return _scheduler_status_name;
                }
                set
                {
                   
                    this["scheduler_status_name"] = value;
                }
            }
                }
}
