using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingLibrary;

namespace ParkingWebApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/Transaction")]
    public class TransactionController : Controller
    {
        private readonly string BAD_REQUEST = "Bad request";
        private IParkingPlace parking = Parking.Instance;
        // GET: api/Transaction/log
        [HttpGet("log")]
        public async Task<IActionResult> GetTransactionLog()
        {
            var transactions = await parking.GetTransactionsFromFile();
            if (transactions.Count == 0) return BadRequest(String.Format("Not found transaction in logs"));
            else return Ok(transactions);
        }

        // GET: api/Transaction/minute
        [HttpGet("minute")]
        public async Task<IActionResult> GetTransactionByLastMinute()
        {
            var transactions = await parking.GetTransactionsByLastMinute();
            if (transactions.Count == 0) return BadRequest(String.Format("Not found transaction by last minute"));
            else return Ok(transactions);
        }

        // GET: api/Transaction/bycar/5
        [HttpGet("bycar/"+"{id}")]
        public async Task<IActionResult> GetTransactionByLastMinuteByCar(int id)
        {
            var transactions = await parking.GetTransactionsByLastMinute(id);
            if (transactions.Count == 0) return BadRequest(String.Format("Not found transaction in logs for car ID {0}", id));
            else return Ok(transactions);
        }
        
        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]int value)
        {
            if (await parking.RefillCarBalance(id, value)) return Ok(String.Format("Balance For car ID {0} was successfuly reffiled on {1}", id, value));
            else return BadRequest(BAD_REQUEST);
        }        
    }
}
