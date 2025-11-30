
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
    public partial class OrgController : ControllerBase
    {
        // GET: api/<OrgController>
        [HttpGet]
        public IEnumerable<OrgView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<OrgView> orgs = OrgLogic.Create().select<OrgView>();

            return orgs;
        }

        // GET api/<OrgController>/5
        [HttpGet("{id}")]
        public Org Get(long id)
        {
            //Console.WriteLine($"Processing Org GET ID={id}");

            Org org = OrgLogic.Create().get(id);

            return org;
        }

        // GET api/<OrgController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Org> orgs = OrgLogic.Create().select<Org>();

            return orgs.Select(org => new EnumHelper(org.id, org.getRwkString()));
        }

        // POST api/<OrgController>
        [HttpPost]
        public OrgView Post([FromBody] OrgView orgView)
        {
            //Console.WriteLine($"Processing Org POST: {org}");
            
            JsonHelper.ProcessJsonElements(orgView);
            
            // Process any JsonElement values to ensure proper type conversion
            Org org = new Org(orgView);

            
            
            OrgLogic.Create().put(org); 

            orgView.id = org.id;

            return orgView;
        }

        // PUT api/<OrgController>/5
        [HttpPut("{id}")]
        public OrgView Put(long id, [FromBody] OrgView orgView)
        {
            //Console.WriteLine($"Processing Org PUT: ID = {id}\n{org}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(orgView);
            
            Org org = new Org(orgView);

            OrgLogic.Create().update(id, org);

            orgView.id = org.id;

            return orgView;
        }

        // DELETE api/<OrgController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            OrgLogic.Create().delete(id);
        }

        // GET api/<OrgController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<OrgHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<OrgHistory> historyList = OrgLogic.Create().history(id);

            return historyList;
        }


        
    }
}
