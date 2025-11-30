

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Resource")]
    public partial class Resource : BaseObject
    {
        public Resource(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "Resource";
            tableName = "app.resource";
            schemaName = "app";
            tableBaseName = "resource";
            auditTableName = "history.app_resource";


            rwk.Add("name");
            
            rwk.Add("resource_type_id");
            
            rwk.Add("internal_org_id");
            
            rwk.Add("external_org_id");
            

            _defaults["id"] = default(long);
            
            _defaults["name"] = default(string);
            
            _defaults["resource_type_id"] = default(long);
            
            _defaults["internal_org_id"] = default(long);
            
            _defaults["external_org_id"] = default(long);
            
            _defaults["ip_address"] = default(string);
            
            _defaults["description"] = default(string);
            
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
            
            [ColumnInfo("Resource Type", "ResourceType", "enum", "resource_type", "resourcetype")]
            public long resource_type_id
            {
                get
                {
                    long _resource_type_id;

                             _resource_type_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("resource_type_id"))
                        {
                        _resource_type_id = Convert.ToInt64(this["resource_type_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting resource_type_id: {e.Message}");
                        _resource_type_id = default(long);
                    }
                    return _resource_type_id;
                }
                set
                {
                   
                    this["resource_type_id"] = value;
                }
            }
            
            [ColumnInfo("Internal Organization", "Org", "enum", "org", "org")]
            public long internal_org_id
            {
                get
                {
                    long _internal_org_id;

                             _internal_org_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("internal_org_id"))
                        {
                        _internal_org_id = Convert.ToInt64(this["internal_org_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting internal_org_id: {e.Message}");
                        _internal_org_id = default(long);
                    }
                    return _internal_org_id;
                }
                set
                {
                   
                    this["internal_org_id"] = value;
                }
            }
            
            [ColumnInfo("External Organization", "Org", "enum", "org", "org")]
            public long external_org_id
            {
                get
                {
                    long _external_org_id;

                             _external_org_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("external_org_id"))
                        {
                        _external_org_id = Convert.ToInt64(this["external_org_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting external_org_id: {e.Message}");
                        _external_org_id = default(long);
                    }
                    return _external_org_id;
                }
                set
                {
                   
                    this["external_org_id"] = value;
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
            
            [ColumnInfo("Description", "", "", "", "")]
            public string description
            {
                get
                {
                    string _description;

                            _description = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("description"))
                        {
                        _description = Convert.ToString(this["description"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting description: {e.Message}");
                        _description = default(string);
                    }
                    return _description;
                }
                set
                {
                   
                    this["description"] = value;
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

    public partial class ResourceHistory : Resource
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "ResourceHistory";
            tableName = "history.app_resource";
            tableBaseName = "app_resource";
          

            // Add the foreign key to the original object
            rwk.Add("resource_id");
            _defaults["resource_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Resource ID")]
        public long resource_id
        {
            get
            {
                long _resource_id = default(long);
                
                try
                {
                    if(this.ContainsKey("resource_id"))
                    {
                        _resource_id = Convert.ToInt64(this["resource_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting resource_id: {e.Message}");
                    _resource_id = default(long);
                }
                return _resource_id;
            }
            set
            {
                this["resource_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class ResourceView : Resource
    {

            [ColumnInfo("Resource Type", "", "", "", "")]
            public string resource_type_name
            {
                get
                {
                    string _resource_type_name;

                            _resource_type_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("resource_type_name"))
                        {
                        _resource_type_name = Convert.ToString(this["resource_type_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting resource_type_name: {e.Message}");
                        _resource_type_name = default(string);
                    }
                    return _resource_type_name;
                }
                set
                {
                   
                    this["resource_type_name"] = value;
                }
            }
            
            [ColumnInfo("Internal Organization", "", "", "", "")]
            public string internal_org_name
            {
                get
                {
                    string _internal_org_name;

                            _internal_org_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("internal_org_name"))
                        {
                        _internal_org_name = Convert.ToString(this["internal_org_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting internal_org_name: {e.Message}");
                        _internal_org_name = default(string);
                    }
                    return _internal_org_name;
                }
                set
                {
                   
                    this["internal_org_name"] = value;
                }
            }
            
            [ColumnInfo("External Organization", "", "", "", "")]
            public string external_org_name
            {
                get
                {
                    string _external_org_name;

                            _external_org_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("external_org_name"))
                        {
                        _external_org_name = Convert.ToString(this["external_org_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting external_org_name: {e.Message}");
                        _external_org_name = default(string);
                    }
                    return _external_org_name;
                }
                set
                {
                   
                    this["external_org_name"] = value;
                }
            }
                }
}
