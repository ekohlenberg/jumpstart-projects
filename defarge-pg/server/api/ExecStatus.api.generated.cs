
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
    public partial class ExecStatusController : ControllerBase
    {
        // GET: api/<ExecStatusController>
        [HttpGet]
        public IEnumerable<ExecStatusView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<ExecStatusView> execstatuss = ExecStatusLogic.Create().select<ExecStatusView>();

            return execstatuss;
        }

        // GET api/<ExecStatusController>/5
        [HttpGet("{id}")]
        public ExecStatus Get(long id)
        {
            //Console.WriteLine($"Processing ExecStatus GET ID={id}");

            ExecStatus execstatus = ExecStatusLogic.Create().get(id);

            return execstatus;
        }

        // GET api/<ExecStatusController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<ExecStatus> execstatuss = ExecStatusLogic.Create().select<ExecStatus>();

            return execstatuss.Select(execstatus => new EnumHelper(execstatus.id, execstatus.getRwkString()));
        }

        // POST api/<ExecStatusController>
        [HttpPost]
        public ExecStatusView Post([FromBody] ExecStatusView execstatusView)
        {
            //Console.WriteLine($"Processing ExecStatus POST: {execstatus}");
            
            JsonHelper.ProcessJsonElements(execstatusView);
            
            // Process any JsonElement values to ensure proper type conversion
            ExecStatus execstatus = new ExecStatus(execstatusView);

            
            
            ExecStatusLogic.Create().put(execstatus); 

            execstatusView.id = execstatus.id;

            return execstatusView;
        }

        // PUT api/<ExecStatusController>/5
        [HttpPut("{id}")]
        public ExecStatusView Put(long id, [FromBody] ExecStatusView execstatusView)
        {
            //Console.WriteLine($"Processing ExecStatus PUT: ID = {id}\n{execstatus}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(execstatusView);
            
            ExecStatus execstatus = new ExecStatus(execstatusView);

            ExecStatusLogic.Create().update(id, execstatus);

            execstatusView.id = execstatus.id;

            return execstatusView;
        }

        // DELETE api/<ExecStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ExecStatusLogic.Create().delete(id);
        }

        // GET api/<ExecStatusController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<ExecStatusHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<ExecStatusHistory> historyList = ExecStatusLogic.Create().history(id);

            return historyList;
        }


        
    }
}
