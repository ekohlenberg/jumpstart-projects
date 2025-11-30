
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
    public partial class PrincipalController : ControllerBase
    {
        // GET: api/<PrincipalController>
        [HttpGet]
        public IEnumerable<PrincipalView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<PrincipalView> principals = PrincipalLogic.Create().select<PrincipalView>();

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

        // GET api/<PrincipalController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Principal> principals = PrincipalLogic.Create().select<Principal>();

            return principals.Select(principal => new EnumHelper(principal.id, principal.getRwkString()));
        }

        // POST api/<PrincipalController>
        [HttpPost]
        public PrincipalView Post([FromBody] PrincipalView principalView)
        {
            //Console.WriteLine($"Processing Principal POST: {principal}");
            
            JsonHelper.ProcessJsonElements(principalView);
            
            // Process any JsonElement values to ensure proper type conversion
            Principal principal = new Principal(principalView);

            
            
            PrincipalLogic.Create().put(principal); 

            principalView.id = principal.id;

            return principalView;
        }

        // PUT api/<PrincipalController>/5
        [HttpPut("{id}")]
        public PrincipalView Put(long id, [FromBody] PrincipalView principalView)
        {
            //Console.WriteLine($"Processing Principal PUT: ID = {id}\n{principal}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(principalView);
            
            Principal principal = new Principal(principalView);

            PrincipalLogic.Create().update(id, principal);

            principalView.id = principal.id;

            return principalView;
        }

        // DELETE api/<PrincipalController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            PrincipalLogic.Create().delete(id);
        }

        // GET api/<PrincipalController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<PrincipalHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<PrincipalHistory> historyList = PrincipalLogic.Create().history(id);

            return historyList;
        }


        
    }
}
