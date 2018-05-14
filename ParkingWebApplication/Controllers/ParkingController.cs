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
        public int GetFree()
        {
            return parking.GetBusySpaceOnParking();
        }

        // GET: api/Parking/busy
        [HttpGet("busy")]
        public int GetBusy()
        {
            return parking.GetBusySpaceOnParking();
        }
        
        // GET: api/Parking/income
        [HttpGet("income")]
        public int GetTotalIncome()
        {
            return parking.GetBalance();
        }              
    }
}
