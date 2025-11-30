
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
    public partial class DataSourceController : ControllerBase
    {
        // GET: api/<DataSourceController>
        [HttpGet]
        public IEnumerable<DataSourceView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<DataSourceView> datasources = DataSourceLogic.Create().select<DataSourceView>();

            return datasources;
        }

        // GET api/<DataSourceController>/5
        [HttpGet("{id}")]
        public DataSource Get(long id)
        {
            //Console.WriteLine($"Processing DataSource GET ID={id}");

            DataSource datasource = DataSourceLogic.Create().get(id);

            return datasource;
        }

        // GET api/<DataSourceController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<DataSource> datasources = DataSourceLogic.Create().select<DataSource>();

            return datasources.Select(datasource => new EnumHelper(datasource.id, datasource.getRwkString()));
        }

        // POST api/<DataSourceController>
        [HttpPost]
        public DataSourceView Post([FromBody] DataSourceView datasourceView)
        {
            //Console.WriteLine($"Processing DataSource POST: {datasource}");
            
            JsonHelper.ProcessJsonElements(datasourceView);
            
            // Process any JsonElement values to ensure proper type conversion
            DataSource datasource = new DataSource(datasourceView);

            
            
            DataSourceLogic.Create().put(datasource); 

            datasourceView.id = datasource.id;

            return datasourceView;
        }

        // PUT api/<DataSourceController>/5
        [HttpPut("{id}")]
        public DataSourceView Put(long id, [FromBody] DataSourceView datasourceView)
        {
            //Console.WriteLine($"Processing DataSource PUT: ID = {id}\n{datasource}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(datasourceView);
            
            DataSource datasource = new DataSource(datasourceView);

            DataSourceLogic.Create().update(id, datasource);

            datasourceView.id = datasource.id;

            return datasourceView;
        }

        // DELETE api/<DataSourceController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            DataSourceLogic.Create().delete(id);
        }

        // GET api/<DataSourceController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<DataSourceHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<DataSourceHistory> historyList = DataSourceLogic.Create().history(id);

            return historyList;
        }


        
    }
}
