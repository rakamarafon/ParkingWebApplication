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
    [Route("api/Parking")]
    public class ParkingController : Controller
    {
        private IParkingPlace parking = Parking.Instance; 
        // GET: api/Parking/free
        [HttpGet("free")]
        public async Task<int> GetFree()
        {
            return await parking.GetFreeSpaceOnParking();
        }

        // GET: api/Parking/busy
        [HttpGet("busy")]
        public async Task<int> GetBusy()
        {
            return await parking.GetBusySpaceOnParking();
        }
        
        // GET: api/Parking/income
        [HttpGet("income")]
        public async Task<int> GetTotalIncome()
        {
            return await parking.GetBalance();
        }              
    }
}
