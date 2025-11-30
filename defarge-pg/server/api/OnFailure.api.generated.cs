
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
    public partial class OnFailureController : ControllerBase
    {
        // GET: api/<OnFailureController>
        [HttpGet]
        public IEnumerable<OnFailureView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<OnFailureView> onfailures = OnFailureLogic.Create().select<OnFailureView>();

            return onfailures;
        }

        // GET api/<OnFailureController>/5
        [HttpGet("{id}")]
        public OnFailure Get(long id)
        {
            //Console.WriteLine($"Processing OnFailure GET ID={id}");

            OnFailure onfailure = OnFailureLogic.Create().get(id);

            return onfailure;
        }

        // GET api/<OnFailureController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<OnFailure> onfailures = OnFailureLogic.Create().select<OnFailure>();

            return onfailures.Select(onfailure => new EnumHelper(onfailure.id, onfailure.getRwkString()));
        }

        // POST api/<OnFailureController>
        [HttpPost]
        public OnFailureView Post([FromBody] OnFailureView onfailureView)
        {
            //Console.WriteLine($"Processing OnFailure POST: {onfailure}");
            
            JsonHelper.ProcessJsonElements(onfailureView);
            
            // Process any JsonElement values to ensure proper type conversion
            OnFailure onfailure = new OnFailure(onfailureView);

            
            
            OnFailureLogic.Create().put(onfailure); 

            onfailureView.id = onfailure.id;

            return onfailureView;
        }

        // PUT api/<OnFailureController>/5
        [HttpPut("{id}")]
        public OnFailureView Put(long id, [FromBody] OnFailureView onfailureView)
        {
            //Console.WriteLine($"Processing OnFailure PUT: ID = {id}\n{onfailure}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(onfailureView);
            
            OnFailure onfailure = new OnFailure(onfailureView);

            OnFailureLogic.Create().update(id, onfailure);

            onfailureView.id = onfailure.id;

            return onfailureView;
        }

        // DELETE api/<OnFailureController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            OnFailureLogic.Create().delete(id);
        }

        // GET api/<OnFailureController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<OnFailureHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<OnFailureHistory> historyList = OnFailureLogic.Create().history(id);

            return historyList;
        }


        
    }
}
