
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
    public partial class PrincipalPasswordController : ControllerBase
    {
        // GET: api/<PrincipalPasswordController>
        [HttpGet]
        public IEnumerable<PrincipalPasswordView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<PrincipalPasswordView> principalpasswords = PrincipalPasswordLogic.Create().select<PrincipalPasswordView>();

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

        // GET api/<PrincipalPasswordController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<PrincipalPassword> principalpasswords = PrincipalPasswordLogic.Create().select<PrincipalPassword>();

            return principalpasswords.Select(principalpassword => new EnumHelper(principalpassword.id, principalpassword.getRwkString()));
        }

        // POST api/<PrincipalPasswordController>
        [HttpPost]
        public PrincipalPasswordView Post([FromBody] PrincipalPasswordView principalpasswordView)
        {
            //Console.WriteLine($"Processing PrincipalPassword POST: {principalpassword}");
            
            JsonHelper.ProcessJsonElements(principalpasswordView);
            
            // Process any JsonElement values to ensure proper type conversion
            PrincipalPassword principalpassword = new PrincipalPassword(principalpasswordView);

            
            
            PrincipalPasswordLogic.Create().put(principalpassword); 

            principalpasswordView.id = principalpassword.id;

            return principalpasswordView;
        }

        // PUT api/<PrincipalPasswordController>/5
        [HttpPut("{id}")]
        public PrincipalPasswordView Put(long id, [FromBody] PrincipalPasswordView principalpasswordView)
        {
            //Console.WriteLine($"Processing PrincipalPassword PUT: ID = {id}\n{principalpassword}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(principalpasswordView);
            
            PrincipalPassword principalpassword = new PrincipalPassword(principalpasswordView);

            PrincipalPasswordLogic.Create().update(id, principalpassword);

            principalpasswordView.id = principalpassword.id;

            return principalpasswordView;
        }

        // DELETE api/<PrincipalPasswordController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            PrincipalPasswordLogic.Create().delete(id);
        }

        // GET api/<PrincipalPasswordController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<PrincipalPasswordHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<PrincipalPasswordHistory> historyList = PrincipalPasswordLogic.Create().history(id);

            return historyList;
        }


        
    }
}
