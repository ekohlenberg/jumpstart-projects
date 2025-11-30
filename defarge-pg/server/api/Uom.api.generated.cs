
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
    public partial class UomController : ControllerBase
    {
        // GET: api/<UomController>
        [HttpGet]
        public IEnumerable<UomView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<UomView> uoms = UomLogic.Create().select<UomView>();

            return uoms;
        }

        // GET api/<UomController>/5
        [HttpGet("{id}")]
        public Uom Get(long id)
        {
            //Console.WriteLine($"Processing Uom GET ID={id}");

            Uom uom = UomLogic.Create().get(id);

            return uom;
        }

        // GET api/<UomController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Uom> uoms = UomLogic.Create().select<Uom>();

            return uoms.Select(uom => new EnumHelper(uom.id, uom.getRwkString()));
        }

        // POST api/<UomController>
        [HttpPost]
        public UomView Post([FromBody] UomView uomView)
        {
            //Console.WriteLine($"Processing Uom POST: {uom}");
            
            JsonHelper.ProcessJsonElements(uomView);
            
            // Process any JsonElement values to ensure proper type conversion
            Uom uom = new Uom(uomView);

            
            
            UomLogic.Create().put(uom); 

            uomView.id = uom.id;

            return uomView;
        }

        // PUT api/<UomController>/5
        [HttpPut("{id}")]
        public UomView Put(long id, [FromBody] UomView uomView)
        {
            //Console.WriteLine($"Processing Uom PUT: ID = {id}\n{uom}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(uomView);
            
            Uom uom = new Uom(uomView);

            UomLogic.Create().update(id, uom);

            uomView.id = uom.id;

            return uomView;
        }

        // DELETE api/<UomController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            UomLogic.Create().delete(id);
        }

        // GET api/<UomController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<UomHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<UomHistory> historyList = UomLogic.Create().history(id);

            return historyList;
        }


        
    }
}
