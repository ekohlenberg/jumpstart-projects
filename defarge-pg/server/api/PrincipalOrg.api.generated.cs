
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
    public partial class PrincipalOrgController : ControllerBase
    {
        // GET: api/<PrincipalOrgController>
        [HttpGet]
        public IEnumerable<PrincipalOrgView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<PrincipalOrgView> principalorgs = PrincipalOrgLogic.Create().select<PrincipalOrgView>();

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

        // GET api/<PrincipalOrgController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<PrincipalOrg> principalorgs = PrincipalOrgLogic.Create().select<PrincipalOrg>();

            return principalorgs.Select(principalorg => new EnumHelper(principalorg.id, principalorg.getRwkString()));
        }

        // POST api/<PrincipalOrgController>
        [HttpPost]
        public PrincipalOrgView Post([FromBody] PrincipalOrgView principalorgView)
        {
            //Console.WriteLine($"Processing PrincipalOrg POST: {principalorg}");
            
            JsonHelper.ProcessJsonElements(principalorgView);
            
            // Process any JsonElement values to ensure proper type conversion
            PrincipalOrg principalorg = new PrincipalOrg(principalorgView);

            
            
            PrincipalOrgLogic.Create().put(principalorg); 

            principalorgView.id = principalorg.id;

            return principalorgView;
        }

        // PUT api/<PrincipalOrgController>/5
        [HttpPut("{id}")]
        public PrincipalOrgView Put(long id, [FromBody] PrincipalOrgView principalorgView)
        {
            //Console.WriteLine($"Processing PrincipalOrg PUT: ID = {id}\n{principalorg}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(principalorgView);
            
            PrincipalOrg principalorg = new PrincipalOrg(principalorgView);

            PrincipalOrgLogic.Create().update(id, principalorg);

            principalorgView.id = principalorg.id;

            return principalorgView;
        }

        // DELETE api/<PrincipalOrgController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            PrincipalOrgLogic.Create().delete(id);
        }

        // GET api/<PrincipalOrgController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<PrincipalOrgHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<PrincipalOrgHistory> historyList = PrincipalOrgLogic.Create().history(id);

            return historyList;
        }


        
    }
}
