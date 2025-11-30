

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Query")]
    public partial class Sql : BaseObject
    {
        public Sql(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "Sql";
            tableName = "core.sql";
            schemaName = "core";
            tableBaseName = "sql";
            auditTableName = "history.core_sql";


            rwk.Add("name");
            

            _defaults["id"] = default(long);
            
            _defaults["name"] = default(string);
            
            _defaults["data_source_id"] = default(long);
            
            _defaults["sql_text"] = default(string);
            
            _defaults["description"] = default(string);
            
            _defaults["is_active"] = default(int);
            
            _defaults["created_by"] = default(string);
            
            _defaults["last_updated"] = default(DateTime);
            
            _defaults["last_updated_by"] = default(string);
            
            _defaults["version"] = default(int);
                    }


            [ColumnInfo("Query ID", "", "", "", "")]
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
            
            [ColumnInfo("Data Source ID", "DataSource", "enum", "data_source", "datasource")]
            public long data_source_id
            {
                get
                {
                    long _data_source_id;

                             _data_source_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("data_source_id"))
                        {
                        _data_source_id = Convert.ToInt64(this["data_source_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting data_source_id: {e.Message}");
                        _data_source_id = default(long);
                    }
                    return _data_source_id;
                }
                set
                {
                   
                    this["data_source_id"] = value;
                }
            }
            
            [ColumnInfo("SQL Text", "", "", "", "")]
            public string sql_text
            {
                get
                {
                    string _sql_text;

                            _sql_text = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("sql_text"))
                        {
                        _sql_text = Convert.ToString(this["sql_text"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting sql_text: {e.Message}");
                        _sql_text = default(string);
                    }
                    return _sql_text;
                }
                set
                {
                   
                    this["sql_text"] = value;
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

    public partial class SqlHistory : Sql
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "SqlHistory";
            tableName = "history.core_sql";
            tableBaseName = "core_sql";
          

            // Add the foreign key to the original object
            rwk.Add("sql_id");
            _defaults["sql_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Query ID")]
        public long sql_id
        {
            get
            {
                long _sql_id = default(long);
                
                try
                {
                    if(this.ContainsKey("sql_id"))
                    {
                        _sql_id = Convert.ToInt64(this["sql_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting sql_id: {e.Message}");
                    _sql_id = default(long);
                }
                return _sql_id;
            }
            set
            {
                this["sql_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class SqlView : Sql
    {

            [ColumnInfo("Data Source ID", "", "", "", "")]
            public string data_source_name
            {
                get
                {
                    string _data_source_name;

                            _data_source_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("data_source_name"))
                        {
                        _data_source_name = Convert.ToString(this["data_source_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting data_source_name: {e.Message}");
                        _data_source_name = default(string);
                    }
                    return _data_source_name;
                }
                set
                {
                   
                    this["data_source_name"] = value;
                }
            }
                }
}
