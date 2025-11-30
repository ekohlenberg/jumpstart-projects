
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class SqlController : ControllerBase
    {
        // GET: api/<SqlController>
        [HttpGet]
        public IEnumerable<SqlView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<SqlView> sqls = SqlLogic.Create().select<SqlView>();

            return sqls;
        }

        // GET api/<SqlController>/5
        [HttpGet("{id}")]
        public Sql Get(long id)
        {
            //Console.WriteLine($"Processing Sql GET ID={id}");

            Sql sql = SqlLogic.Create().get(id);

            return sql;
        }

        // GET api/<SqlController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Sql> sqls = SqlLogic.Create().select<Sql>();

            return sqls.Select(sql => new EnumHelper(sql.id, sql.getRwkString()));
        }

        // POST api/<SqlController>
        [HttpPost]
        public SqlView Post([FromBody] SqlView sqlView)
        {
            //Console.WriteLine($"Processing Sql POST: {sql}");
            
            JsonHelper.ProcessJsonElements(sqlView);
            
            // Process any JsonElement values to ensure proper type conversion
            Sql sql = new Sql(sqlView);

            
            
            SqlLogic.Create().put(sql); 

            sqlView.id = sql.id;

            return sqlView;
        }

        // PUT api/<SqlController>/5
        [HttpPut("{id}")]
        public SqlView Put(long id, [FromBody] SqlView sqlView)
        {
            //Console.WriteLine($"Processing Sql PUT: ID = {id}\n{sql}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(sqlView);
            
            Sql sql = new Sql(sqlView);

            SqlLogic.Create().update(id, sql);

            sqlView.id = sql.id;

            return sqlView;
        }

        // DELETE api/<SqlController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            SqlLogic.Create().delete(id);
        }

        // GET api/<SqlController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<SqlHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<SqlHistory> historyList = SqlLogic.Create().history(id);

            return historyList;
        }


        
    }
}
