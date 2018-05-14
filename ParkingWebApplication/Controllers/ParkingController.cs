using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ParkingWebApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/Parking")]
    public class ParkingController : Controller
    {
        // GET: api/Parking/free
        [HttpGet("free")]
        public int GetFree()
        {
            return ParkingLibrary.Parking.Instance.GetFreeSpaceOnParking();
        }

        // GET: api/Parking/busy
        [HttpGet("busy")]
        public int GetBusy()
        {
            return ParkingLibrary.Parking.Instance.GetBusySpaceOnParking();
        }
        
        // GET: api/Parking/income
        [HttpGet("income")]
        public int GetTotalIncome()
        {
            return ParkingLibrary.Parking.Instance.Balance;
        }              
    }
}
