

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Main Menu")]
    public partial class NavMenu : BaseObject
    {
        public NavMenu(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "NavMenu";
            tableName = "core.nav_menu";
            schemaName = "core";
            tableBaseName = "nav_menu";
            auditTableName = "history.core_nav_menu";


            rwk.Add("name");
            

            _defaults["id"] = default(long);
            
            _defaults["parent_id"] = default(long);
            
            _defaults["ordinal"] = default(int);
            
            _defaults["name"] = default(string);
            
            _defaults["link"] = default(string);
            
            _defaults["is_active"] = default(int);
            
            _defaults["created_by"] = default(string);
            
            _defaults["last_updated"] = default(DateTime);
            
            _defaults["last_updated_by"] = default(string);
            
            _defaults["version"] = default(int);
                    }


            [ColumnInfo("Nav Menu ID", "", "", "", "")]
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
            
            [ColumnInfo("Parent Menu ID", "NavMenu", "parent", "nav_menu", "navmenu")]
            public long parent_id
            {
                get
                {
                    long _parent_id;

                             _parent_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("parent_id"))
                        {
                        _parent_id = Convert.ToInt64(this["parent_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting parent_id: {e.Message}");
                        _parent_id = default(long);
                    }
                    return _parent_id;
                }
                set
                {
                   
                    this["parent_id"] = value;
                }
            }
            
            [ColumnInfo("Ordinal", "", "", "", "")]
            public int ordinal
            {
                get
                {
                    int _ordinal;

                             _ordinal = default(int);
                                                 
                    try
                    {
                        if(this.ContainsKey("ordinal"))
                        {
                        _ordinal = Convert.ToInt32(this["ordinal"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting ordinal: {e.Message}");
                        _ordinal = default(int);
                    }
                    return _ordinal;
                }
                set
                {
                   
                    this["ordinal"] = value;
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
            
            [ColumnInfo("Link", "", "", "", "")]
            public string link
            {
                get
                {
                    string _link;

                            _link = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("link"))
                        {
                        _link = Convert.ToString(this["link"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting link: {e.Message}");
                        _link = default(string);
                    }
                    return _link;
                }
                set
                {
                   
                    this["link"] = value;
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

    public partial class NavMenuHistory : NavMenu
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "NavMenuHistory";
            tableName = "history.core_nav_menu";
            tableBaseName = "core_nav_menu";
          

            // Add the foreign key to the original object
            rwk.Add("nav_menu_id");
            _defaults["nav_menu_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Main Menu ID")]
        public long nav_menu_id
        {
            get
            {
                long _nav_menu_id = default(long);
                
                try
                {
                    if(this.ContainsKey("nav_menu_id"))
                    {
                        _nav_menu_id = Convert.ToInt64(this["nav_menu_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting nav_menu_id: {e.Message}");
                    _nav_menu_id = default(long);
                }
                return _nav_menu_id;
            }
            set
            {
                this["nav_menu_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class NavMenuView : NavMenu
    {

            [ColumnInfo("Parent Menu ID", "", "", "", "")]
            public string parent_name
            {
                get
                {
                    string _parent_name;

                            _parent_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("parent_name"))
                        {
                        _parent_name = Convert.ToString(this["parent_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting parent_name: {e.Message}");
                        _parent_name = default(string);
                    }
                    return _parent_name;
                }
                set
                {
                   
                    this["parent_name"] = value;
                }
            }
                }
}
