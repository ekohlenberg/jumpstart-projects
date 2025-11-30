
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
    public partial class OperationController : ControllerBase
    {
        // GET: api/<OperationController>
        [HttpGet]
        public IEnumerable<OperationView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<OperationView> operations = OperationLogic.Create().select<OperationView>();

            return operations;
        }

        // GET api/<OperationController>/5
        [HttpGet("{id}")]
        public Operation Get(long id)
        {
            //Console.WriteLine($"Processing Operation GET ID={id}");

            Operation operation = OperationLogic.Create().get(id);

            return operation;
        }

        // GET api/<OperationController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Operation> operations = OperationLogic.Create().select<Operation>();

            return operations.Select(operation => new EnumHelper(operation.id, operation.getRwkString()));
        }

        // POST api/<OperationController>
        [HttpPost]
        public OperationView Post([FromBody] OperationView operationView)
        {
            //Console.WriteLine($"Processing Operation POST: {operation}");
            
            JsonHelper.ProcessJsonElements(operationView);
            
            // Process any JsonElement values to ensure proper type conversion
            Operation operation = new Operation(operationView);

            
            
            OperationLogic.Create().put(operation); 

            operationView.id = operation.id;

            return operationView;
        }

        // PUT api/<OperationController>/5
        [HttpPut("{id}")]
        public OperationView Put(long id, [FromBody] OperationView operationView)
        {
            //Console.WriteLine($"Processing Operation PUT: ID = {id}\n{operation}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(operationView);
            
            Operation operation = new Operation(operationView);

            OperationLogic.Create().update(id, operation);

            operationView.id = operation.id;

            return operationView;
        }

        // DELETE api/<OperationController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            OperationLogic.Create().delete(id);
        }

        // GET api/<OperationController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<OperationHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<OperationHistory> historyList = OperationLogic.Create().history(id);

            return historyList;
        }


        
    }
}
