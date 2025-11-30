

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Organization")]
    public partial class Org : BaseObject
    {
        public Org(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "Org";
            tableName = "app.org";
            schemaName = "app";
            tableBaseName = "org";
            auditTableName = "history.app_org";


            rwk.Add("name");
            

            _defaults["id"] = default(long);
            
            _defaults["name"] = default(string);
            
            _defaults["is_active"] = default(int);
            
            _defaults["created_by"] = default(string);
            
            _defaults["last_updated"] = default(DateTime);
            
            _defaults["last_updated_by"] = default(string);
            
            _defaults["version"] = default(int);
                    }


            [ColumnInfo("Organization ID", "", "", "", "")]
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

    public partial class OrgHistory : Org
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "OrgHistory";
            tableName = "history.app_org";
            tableBaseName = "app_org";
          

            // Add the foreign key to the original object
            rwk.Add("org_id");
            _defaults["org_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Organization ID")]
        public long org_id
        {
            get
            {
                long _org_id = default(long);
                
                try
                {
                    if(this.ContainsKey("org_id"))
                    {
                        _org_id = Convert.ToInt64(this["org_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting org_id: {e.Message}");
                    _org_id = default(long);
                }
                return _org_id;
            }
            set
            {
                this["org_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class OrgView : Org
    {
    }
}
