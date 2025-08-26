
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
    public class PrincipalPasswordController : ControllerBase
    {
        // GET: api/<PrincipalPasswordController>
        [HttpGet]
        public IEnumerable<PrincipalPassword> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<PrincipalPassword> principalpasswords = PrincipalPasswordLogic.Create().select();

            return principalpasswords;
        }

        // GET api/<PrincipalPasswordController>/5
        [HttpGet("{id}")]
        public PrincipalPassword Get(long id)
        {
            //Console.WriteLine($"Processing PrincipalPassword GET ID={id}");

            PrincipalPassword principalpassword = PrincipalPasswordLogic.Create().get(id);

            return principalpassword;
        }

        // POST api/<PrincipalPasswordController>
        [HttpPost]
        public void Post([FromBody] PrincipalPassword principalpassword)
        {
            //Console.WriteLine($"Processing PrincipalPassword POST: {principalpassword}");
            PrincipalPasswordLogic.Create().insert(principalpassword);
        }

        // PUT api/<PrincipalPasswordController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] PrincipalPassword principalpassword)
        {
            //Console.WriteLine($"Processing PrincipalPassword PUT: ID = {id}\n{principalpassword}");
            PrincipalPasswordLogic.Create().update(id, principalpassword);
        }

        // DELETE api/<PrincipalPasswordController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            PrincipalPasswordLogic.Create().delete(id);
        }
    }
}
