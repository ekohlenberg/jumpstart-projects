
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
    public class PrincipalController : ControllerBase
    {
        // GET: api/<PrincipalController>
        [HttpGet]
        public IEnumerable<Principal> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Principal> principals = PrincipalLogic.Create().select();

            return principals;
        }

        // GET api/<PrincipalController>/5
        [HttpGet("{id}")]
        public Principal Get(long id)
        {
            //Console.WriteLine($"Processing Principal GET ID={id}");

            Principal principal = PrincipalLogic.Create().get(id);

            return principal;
        }

        // POST api/<PrincipalController>
        [HttpPost]
        public void Post([FromBody] Principal principal)
        {
            //Console.WriteLine($"Processing Principal POST: {principal}");
            PrincipalLogic.Create().insert(principal);
        }

        // PUT api/<PrincipalController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Principal principal)
        {
            //Console.WriteLine($"Processing Principal PUT: ID = {id}\n{principal}");
            PrincipalLogic.Create().update(id, principal);
        }

        // DELETE api/<PrincipalController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            PrincipalLogic.Create().delete(id);
        }
    }
}
