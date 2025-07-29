
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.Common;
using System.Collections.Immutable;
using Npgsql;
using System.Linq;

namespace legr3
{
    public class DBPersist
    {
        public delegate void SelectCallback(DbDataReader rdr);
        
        static public void select( SelectCallback selectCallback, string sql)
        {
        
            Logger.Debug($"Excuting sql {sql}.");
            
            try
            {
                string connectionStr = Config.getString("db.connection");

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionStr))
                {
                    connection.Open();

                    using (DbCommand command = (DbCommand) new NpgsqlCommand(sql, connection))
                    {
                        using (DbDataReader rdr = (DbDataReader) command.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                selectCallback(rdr);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string m = $"Error executing select: {sql}";

                Logger.Error( m, ex);
                throw new Exception(m, ex);
            }
        }

        static public void select( SelectCallback selectCallback, string sqlTemplate, BaseObject filter)
        {

            string sql = substituteTemplate(filter, sqlTemplate);

            select(selectCallback, sql);
        }

        static public long insert( BaseObject baseObject )
        {
            long id = identity(baseObject);
            int ver = version(baseObject);

            baseObject["id"] = id;
            baseObject["version"] = ver;
            baseObject["created_by"] = Environment.UserName;
            baseObject["last_updated"] = DateTime.Now;
            baseObject["last_updated_by"] = Environment.UserName;

            string sql = insertSql(baseObject, baseObject.tableName);
            execCmd(sql);

            audit(baseObject);

            return id;
        }

        static public long audit( BaseObject baseObject )
        {
            BaseObject auditBaseObject = new BaseObject(baseObject);

            string auditFKCol = baseObject.tableBaseName + "_id";
            auditBaseObject[auditFKCol] = baseObject["id"];
            long id = identity(baseObject);
            auditBaseObject["id"] = id;

            Console.WriteLine("Audit: " + auditBaseObject.ToString());

            string sql = insertSql(auditBaseObject, baseObject.auditTableName);
            execCmd(sql);

            return id;
        }
        static public void update(BaseObject baseObject)
        {
            baseObject["version"] = version(baseObject);
            baseObject["last_updated"] = DateTime.Now;
            baseObject["last_updated_by"] = Environment.UserName;

            string sql = updateSql(baseObject);
            execCmd(sql);

            audit(baseObject);
        }

        public static void execCmd( BaseObject parameters, string sqlTemplate)
        {
            string sql = substituteTemplate(parameters, sqlTemplate);
            execCmd(sql);
        }
        public static void execCmd(string sql)
        {
            try
            {
                string connectionStr = Config.getString("db.connection");

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionStr))
                {
                    connection.Open();

                    using (DbCommand command = (DbCommand) new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Logger.Debug(sql);
                    }
                }
            }
            catch(Exception x)
            {
                Logger.Error(x.Message + ": " + sql);
            }
        }

        static string insertSql( BaseObject baseObject, string tableName )
        {
            StringBuilder sql = new StringBuilder("insert into " + tableName + " ");
            StringBuilder cols = new StringBuilder("");
            StringBuilder vals = new StringBuilder("");

            foreach (string k in baseObject.Keys)
            {
                //if (k != "id")
                //{
                    object v = baseObject[k];
                    
                    if (v == null) continue;
                    if (v == DBNull.Value) continue;
                    if (string.IsNullOrEmpty(v.ToString())) continue;

                    if (cols.Length > 0)
                    {
                        cols.Append(",");
                        vals.Append(",");
                    }
                    cols.Append(bracket(k));
                    vals.Append(toSql(v));
                //}
            }

            sql.Append("(");
            sql.Append(cols);
            sql.Append(") values (");
            sql.Append(vals);
            sql.Append(");");

            return sql.ToString();
        }

        static string updateSql( BaseObject baseObject)
        {
            StringBuilder sql = new StringBuilder("update " + baseObject.tableName + " set ");
            StringBuilder expressions = new StringBuilder();
            StringBuilder where = new StringBuilder();

            exprSql(baseObject, baseObject.Keys, ", ", expressions);

            where.Append(" where id=");
            where.Append(toSql(baseObject["id"]));

            sql.Append(expressions);
            sql.Append(where);
            sql.Append(";");

            return sql.ToString();
        }

        private static void exprSql(BaseObject baseObject, IEnumerable<string> attrList, string sepToken, StringBuilder expressions)
        {
            foreach (string k in attrList)
            {
                if (k != "id")
                {
                    object v = toSql(baseObject[k]);
                    if (v == null) continue;
                    if (v == DBNull.Value) continue;
                    if (string.IsNullOrEmpty(v.ToString())) continue;

                    if (expressions.Length > 0)
                    {
                        expressions.Append(sepToken);
                    }
                    string expr = string.Empty;
                    expr += bracket(k);
                    expr += "=";
                    expr += v;

                    expressions.Append(expr);
                }
            }
        }

        
        static string bracket(string k)
        {
            //return "[" + k + "]";
            return k;
        }

        static string toSql( object v)
        {
            string result = string.Empty;
            if (v == null) return result;

            if (v.GetType().Equals(typeof(DateTime)))
            {
                DateTime d = (DateTime)v;
                result = "'" + d.ToString("MM/dd/yyyy HH:mm:ss") +"'";
            }
            else if (v.GetType().Equals(typeof(string)))
            {
                result = "'" + v.ToString().Replace("'", "''") + "'";
            }
            else if (v.GetType().FullName.Contains("Text"))
            {
                result = "'" + v.ToString().Replace("'", "''") + "'";
            }
            else
            {
                result = v.ToString();
            }

            return result;
          
        }

        static public void get(BaseObject t)
        {
            string sql = getSql(t);

            SelectCallback sc = (rdr) =>
            {
                autoAssign(rdr, t);
            };

            select(sc, sql);
        }


        static public void put(BaseObject baseObject, string rwkCol)
        {
            string sql = "select * from ^(tableName) where ^(rwkCol) = ^(rwkValue)";
            bool found = false;

            BaseObject filter = new BaseObject();
            filter["tableName"] = baseObject.tableName;
            filter["rwkCol"] = rwkCol;
            filter["rwkValue"] = toSql(baseObject[rwkCol].ToString());

            SelectCallback scb = (rdr) =>
            {
                found = true;
                baseObject["id"] = rdr["id"];
            };

            select(scb, sql, filter);

            if (found)
            {
                update(baseObject);
            }
            else
            {
                insert(baseObject);
            }
        }

        static public void put(BaseObject baseObject)
        {
            string sql = "select * from ^(tableName) where ^(expression)";
            int count = 0;
            StringBuilder expression = new StringBuilder();

            if (baseObject.getRwk().Count <= 0) throw new Exception(baseObject.GetType().Name + ".rwk list is empty. DBPersist.put(BaseObject) requires at least one attribute in the rwk list.");

            exprSql(baseObject, baseObject.getRwk(), " and ", expression);

            BaseObject filter = new BaseObject();
            filter["tableName"] = baseObject.tableName;
            filter["expression"] = expression.ToString();

            SelectCallback scb = (rdr) =>
            {
                count++;
                baseObject["id"] = rdr["id"];
            };

            select(scb, sql, filter);

            if (count == 1)
            {
                update(baseObject);
            }
            else if (count == 0)
            {
                insert(baseObject);
            }
            else
            {
                throw new Exception(baseObject.GetType().Name + ".rwk returned more that one row. sql=" + sql); ;
            }
        }

        static long identity(BaseObject baseObject)
        {
            long id = 0;

            //string sql = "select next value for object_identity";
            string sql = "SELECT nextval('$(tableName)_identity');";
            sql = sql.Replace("$(tableName)", baseObject.tableName);

            SelectCallback scb = (rdr) =>
            {
                id = Convert.ToInt64(rdr[0]);
            };

            select(scb, sql);

            return id;
        }

        static int version(BaseObject baseObject)
        {
            int ver = 0;

            
            
            string sqlTemplate = @"with ver_check as (
            select max(version) as v from ^(table)
            where id=^(id)
            union all select 0 as v
            )
            select max(v)+1 from ver_check";
            
            BaseObject p = new BaseObject();
            
            long id = 0;
            if (baseObject.ContainsKey("id"))
            {
                if (!Int64.TryParse(baseObject["id"].ToString(), out id))
                {
                    id = 0;
                }
            }
                
            
            p["table"] = baseObject.tableName;
            p["id"] = id;
            string sql = substituteTemplate(p, sqlTemplate);

            SelectCallback scb = (rdr) =>
            {
                ver = Convert.ToInt32(rdr[0]);
            };

            select(scb, sql);

            return ver;
        }
        static string getSql( BaseObject t)
        {
            string sqlTemplate = "select * from ^(table) where id=^(id)";

            BaseObject p = new BaseObject();

            p["id"] = t["id"];
            p["table"] = t.tableName;

            return substituteTemplate(p, sqlTemplate);

        }

        public static void autoAssign( DbDataReader rdr, BaseObject t)
        {
            for (int i = 0; i < rdr.FieldCount; i++)
            {
                string k = rdr.GetName(i);
                if (t.ContainsKey(k)) { t[k] = rdr.GetValue(i); }
                else { t.Add(k, rdr.GetValue(i)); }
            }
        }

        protected static string substituteTemplate( BaseObject parameters, string sqlTemplate)
        {
            StringBuilder sb = new StringBuilder(sqlTemplate);

            foreach( string k in parameters.Keys)
            {
                object v = string.Empty;
                parameters.TryGetValue(k, out v);

                string paramName = "^(" + k + ")";
                sb.Replace(paramName, v.ToString());
            }

            return sb.ToString();
        }

    }
}
