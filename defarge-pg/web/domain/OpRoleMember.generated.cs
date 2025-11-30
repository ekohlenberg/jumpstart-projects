

using System;
using System.Reflection;
using System.Collections.Generic;

namespace defarge
{
    [ClassInfo("Operation Role Members")]
    public partial class OpRoleMember : BaseObject
    {
        public OpRoleMember(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "OpRoleMember";
            tableName = "sec.op_role_member";
            schemaName = "sec";
            tableBaseName = "op_role_member";
            auditTableName = "history.sec_op_role_member";


            rwk.Add("principal_id");
            
            rwk.Add("op_role_id");
            

            _defaults["id"] = default(long);
            
            _defaults["principal_id"] = default(long);
            
            _defaults["op_role_id"] = default(long);
            
            _defaults["is_active"] = default(int);
            
            _defaults["created_by"] = default(string);
            
            _defaults["last_updated"] = default(DateTime);
            
            _defaults["last_updated_by"] = default(string);
            
            _defaults["version"] = default(int);
                    }


            [ColumnInfo("Member ID", "", "", "", "")]
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
            
            [ColumnInfo("Username", "Principal", "map", "principal", "principal")]
            public long principal_id
            {
                get
                {
                    long _principal_id;

                             _principal_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("principal_id"))
                        {
                        _principal_id = Convert.ToInt64(this["principal_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting principal_id: {e.Message}");
                        _principal_id = default(long);
                    }
                    return _principal_id;
                }
                set
                {
                   
                    this["principal_id"] = value;
                }
            }
            
            [ColumnInfo("Role", "OpRole", "map", "op_role", "oprole")]
            public long op_role_id
            {
                get
                {
                    long _op_role_id;

                             _op_role_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("op_role_id"))
                        {
                        _op_role_id = Convert.ToInt64(this["op_role_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting op_role_id: {e.Message}");
                        _op_role_id = default(long);
                    }
                    return _op_role_id;
                }
                set
                {
                   
                    this["op_role_id"] = value;
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

    public partial class OpRoleMemberHistory : OpRoleMember
    {
        protected override void Initialize()
        {
            // History object initializer - override table name and add foreign key
            base.Initialize();
            
            domainName = "OpRoleMemberHistory";
            tableName = "history.sec_op_role_member";
            tableBaseName = "sec_op_role_member";
          

            // Add the foreign key to the original object
            rwk.Add("op_role_member_id");
            _defaults["op_role_member_id"] = default(long);
        }

        // Foreign key property to the original object
        [ColumnInfo("Operation Role Members ID")]
        public long op_role_member_id
        {
            get
            {
                long _op_role_member_id = default(long);
                
                try
                {
                    if(this.ContainsKey("op_role_member_id"))
                    {
                        _op_role_member_id = Convert.ToInt64(this["op_role_member_id"].ToString());
                    }
                }
                catch(Exception)
                {
                    //Logger.Error($"Error getting op_role_member_id: {e.Message}");
                    _op_role_member_id = default(long);
                }
                return _op_role_member_id;
            }
            set
            {
                this["op_role_member_id"] = value;
            }
        }
    }

    // View class that extends the base domain object with RWK columns from foreign key joins
    public class OpRoleMemberView : OpRoleMember
    {

            [ColumnInfo("Username", "", "", "", "")]
            public string principal_email
            {
                get
                {
                    string _principal_email;

                            _principal_email = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("principal_email"))
                        {
                        _principal_email = Convert.ToString(this["principal_email"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting principal_email: {e.Message}");
                        _principal_email = default(string);
                    }
                    return _principal_email;
                }
                set
                {
                   
                    this["principal_email"] = value;
                }
            }
            
            [ColumnInfo("Role", "", "", "", "")]
            public string op_role_name
            {
                get
                {
                    string _op_role_name;

                            _op_role_name = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("op_role_name"))
                        {
                        _op_role_name = Convert.ToString(this["op_role_name"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting op_role_name: {e.Message}");
                        _op_role_name = default(string);
                    }
                    return _op_role_name;
                }
                set
                {
                   
                    this["op_role_name"] = value;
                }
            }
                }
}
