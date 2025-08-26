
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
    public class PrincipalOrgController : ControllerBase
    {
        // GET: api/<PrincipalOrgController>
        [HttpGet]
        public IEnumerable<PrincipalOrg> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<PrincipalOrg> principalorgs = PrincipalOrgLogic.Create().select();

            return principalorgs;
        }

        // GET api/<PrincipalOrgController>/5
        [HttpGet("{id}")]
        public PrincipalOrg Get(long id)
        {
            //Console.WriteLine($"Processing PrincipalOrg GET ID={id}");

            PrincipalOrg principalorg = PrincipalOrgLogic.Create().get(id);

            return principalorg;
        }

        // POST api/<PrincipalOrgController>
        [HttpPost]
        public void Post([FromBody] PrincipalOrg principalorg)
        {
            //Console.WriteLine($"Processing PrincipalOrg POST: {principalorg}");
            PrincipalOrgLogic.Create().insert(principalorg);
        }

        // PUT api/<PrincipalOrgController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] PrincipalOrg principalorg)
        {
            //Console.WriteLine($"Processing PrincipalOrg PUT: ID = {id}\n{principalorg}");
            PrincipalOrgLogic.Create().update(id, principalorg);
        }

        // DELETE api/<PrincipalOrgController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            PrincipalOrgLogic.Create().delete(id);
        }
    }
}
