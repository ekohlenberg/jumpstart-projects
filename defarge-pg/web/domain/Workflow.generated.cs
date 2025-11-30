

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Workflow")]
    public partial class Workflow : BaseObject
    {
        public Workflow(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "Workflow";
            tableName = "core.workflow";
            schemaName = "core";
            tableBaseName = "workflow";
            auditTableName = "history.core_workflow";


            rwk.Add("parent_workflow_id");
            
            rwk.Add("name");
            

            _defaults["id"] = default(long);
            
            _defaults["parent_workflow_id"] = default(long);
            
            _defaults["name"] = default(string);
            
            _defaults["description"] = default(string);
            
            _defaults["is_active"] = default(int);
            
            _defaults["created_by"] = default(string);
            
            _defaults["last_updated"] = default(DateTime);
            
            _defaults["last_updated_by"] = default(string);
            
            _defaults["version"] = default(int);
                    }


            [ColumnInfo("", "", "", "", "")]
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
            
            [ColumnInfo("", "Workflow", "parent", "workflow", "workflow")]
            public long parent_workflow_id
            {
                get
                {
                    long _parent_workflow_id;

                             _parent_workflow_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("parent_workflow_id"))
                        {
                        _parent_workflow_id = Convert.ToInt64(this["parent_workflow_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting parent_workflow_id: {e.Message}");
                        _parent_workflow_id = default(long);
                    }
                    return _parent_workflow_id;
                }
                set
                {
                   
                    this["parent_workflow_id"] = value;
                }
            }
            
            [ColumnInfo("", "", "", "", "")]
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
            
            [ColumnInfo("", "", "", "", "")]
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

    public partial class WorkflowHistory : Workflow
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "WorkflowHistory";
            tableName = "history.core_workflow";
            tableBaseName = "core_workflow";
          

            // Add the foreign key to the original object
            rwk.Add("workflow_id");
            _defaults["workflow_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Workflow ID")]
        public long workflow_id
        {
            get
            {
                long _workflow_id = default(long);
                
                try
                {
                    if(this.ContainsKey("workflow_id"))
                    {
                        _workflow_id = Convert.ToInt64(this["workflow_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting workflow_id: {e.Message}");
                    _workflow_id = default(long);
                }
                return _workflow_id;
            }
            set
            {
                this["workflow_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class WorkflowView : Workflow
    {

            [ColumnInfo("", "Workflow", "parent", "workflow", "workflow")]
            public long parent_workflow_parent_workflow_id
            {
                get
                {
                    long _parent_workflow_parent_workflow_id;

                             _parent_workflow_parent_workflow_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("parent_workflow_parent_workflow_id"))
                        {
                        _parent_workflow_parent_workflow_id = Convert.ToInt64(this["parent_workflow_parent_workflow_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting parent_workflow_parent_workflow_id: {e.Message}");
                        _parent_workflow_parent_workflow_id = default(long);
                    }
                    return _parent_workflow_parent_workflow_id;
                }
                set
                {
                   
                    this["parent_workflow_parent_workflow_id"] = value;
                }
            }
            
            [ColumnInfo("", "", "", "", "")]
            public string parent_workflow_name
            {
                get
                {
                    string _parent_workflow_name;

                            _parent_workflow_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("parent_workflow_name"))
                        {
                        _parent_workflow_name = Convert.ToString(this["parent_workflow_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting parent_workflow_name: {e.Message}");
                        _parent_workflow_name = default(string);
                    }
                    return _parent_workflow_name;
                }
                set
                {
                   
                    this["parent_workflow_name"] = value;
                }
            }
                }
}
