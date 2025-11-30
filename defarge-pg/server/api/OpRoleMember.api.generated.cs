
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
    public partial class OpRoleMemberController : ControllerBase
    {
        // GET: api/<OpRoleMemberController>
        [HttpGet]
        public IEnumerable<OpRoleMemberView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<OpRoleMemberView> oprolemembers = OpRoleMemberLogic.Create().select<OpRoleMemberView>();

            return oprolemembers;
        }

        // GET api/<OpRoleMemberController>/5
        [HttpGet("{id}")]
        public OpRoleMember Get(long id)
        {
            //Console.WriteLine($"Processing OpRoleMember GET ID={id}");

            OpRoleMember oprolemember = OpRoleMemberLogic.Create().get(id);

            return oprolemember;
        }

        // GET api/<OpRoleMemberController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<OpRoleMember> oprolemembers = OpRoleMemberLogic.Create().select<OpRoleMember>();

            return oprolemembers.Select(oprolemember => new EnumHelper(oprolemember.id, oprolemember.getRwkString()));
        }

        // POST api/<OpRoleMemberController>
        [HttpPost]
        public OpRoleMemberView Post([FromBody] OpRoleMemberView oprolememberView)
        {
            //Console.WriteLine($"Processing OpRoleMember POST: {oprolemember}");
            
            JsonHelper.ProcessJsonElements(oprolememberView);
            
            // Process any JsonElement values to ensure proper type conversion
            OpRoleMember oprolemember = new OpRoleMember(oprolememberView);

            
            
            OpRoleMemberLogic.Create().put(oprolemember); 

            oprolememberView.id = oprolemember.id;

            return oprolememberView;
        }

        // PUT api/<OpRoleMemberController>/5
        [HttpPut("{id}")]
        public OpRoleMemberView Put(long id, [FromBody] OpRoleMemberView oprolememberView)
        {
            //Console.WriteLine($"Processing OpRoleMember PUT: ID = {id}\n{oprolemember}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(oprolememberView);
            
            OpRoleMember oprolemember = new OpRoleMember(oprolememberView);

            OpRoleMemberLogic.Create().update(id, oprolemember);

            oprolememberView.id = oprolemember.id;

            return oprolememberView;
        }

        // DELETE api/<OpRoleMemberController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            OpRoleMemberLogic.Create().delete(id);
        }

        // GET api/<OpRoleMemberController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<OpRoleMemberHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<OpRoleMemberHistory> historyList = OpRoleMemberLogic.Create().history(id);

            return historyList;
        }


        
    }
}
