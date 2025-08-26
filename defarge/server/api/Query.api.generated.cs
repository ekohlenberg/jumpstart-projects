
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
    public class QueryController : ControllerBase
    {
        // GET: api/<QueryController>
        [HttpGet]
        public IEnumerable<Query> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Query> querys = QueryLogic.Create().select();

            return querys;
        }

        // GET api/<QueryController>/5
        [HttpGet("{id}")]
        public Query Get(long id)
        {
            //Console.WriteLine($"Processing Query GET ID={id}");

            Query query = QueryLogic.Create().get(id);

            return query;
        }

        // POST api/<QueryController>
        [HttpPost]
        public void Post([FromBody] Query query)
        {
            //Console.WriteLine($"Processing Query POST: {query}");
            QueryLogic.Create().insert(query);
        }

        // PUT api/<QueryController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Query query)
        {
            //Console.WriteLine($"Processing Query PUT: ID = {id}\n{query}");
            QueryLogic.Create().update(id, query);
        }

        // DELETE api/<QueryController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            QueryLogic.Create().delete(id);
        }
    }
}
