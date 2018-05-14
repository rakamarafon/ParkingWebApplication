﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ParkingWebApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/Transaction")]
    public class TransactionController : Controller
    {
        private readonly string BAD_REQUEST = "Bad request";
        // GET: api/Transaction/log
        [HttpGet("log")]
        public IEnumerable<string> GetTransactionLog()
        {
            return ParkingLibrary.Parking.Instance.GetTransactionsFromFile();
        }

        // GET: api/Transaction/minute
        [HttpGet("minute")]
        public IEnumerable<ParkingLibrary.Transaction> GetTransactionByLastMinute()
        {
            return ParkingLibrary.Parking.Instance.GetTransactionsByLastMinute();
        }
        
        // POST: api/Transaction/bycar
        [HttpGet("bycar")]
        public IEnumerable<ParkingLibrary.Transaction> GetTransactionByLastMinuteByCar(int id)
        {
            return ParkingLibrary.Parking.Instance.GetTransactionsByLastMinute(id);
        }
        
        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]int value)
        {
            if (ParkingLibrary.Parking.Instance.RefillCarBalance(id, value)) return Ok(String.Format("Balance For car ID {0} was successfuly reffiled on {1}", id, value));
            else return BadRequest(BAD_REQUEST);
        }        
    }
}
