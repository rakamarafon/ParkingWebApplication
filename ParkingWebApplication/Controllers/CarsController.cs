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
    [Route("api/Cars")]
    public class CarsController : Controller
    {
        private readonly string BAD_REQUEST = "Bad request";
        private IParkingPlace parking = Parking.Instance; 
        // GET: api/Cars
        [HttpGet]
        public async Task<IEnumerable<Car>> Get()
        {
            return await parking.GetCarList();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<Car> Get(int id)
        {
            return await parking.GetCar(id);
        }
        
        // POST: api/Cars
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Car value)
        {
            int result = await parking.AddCar(value);
            if (result == (int)ErrorsCod.FullParking) return BadRequest("In the parking lot there are no free places");
            else if (result == (int)ErrorsCod.ParkingHasCarWthThisID) return BadRequest(String.Format("Car with ID:{0} already in the parking place", value.CarId));
            else if (result == (int)ErrorsCod.Success) return Ok(String.Format("car with ID:{0} was successfuly added", value.CarId));
            else return BadRequest(BAD_REQUEST);
        }
        
        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = await parking.RemoveCar(id);
            if (result == (int)ErrorsCod.EmptyList) return BadRequest("There are no cars on the parking place");
            else if (result == (int)ErrorsCod.NoCar) return BadRequest("No car with such ID");
            else if (result == (int)ErrorsCod.MinusBalance) return BadRequest(String.Format("Car with ID {0} has unpositive balance! Reffil car balance and try again", id));
            else if (result == (int)ErrorsCod.Success) return Ok(String.Format("Car with ID {0} was successfuly deleted", id));
            else return BadRequest(BAD_REQUEST);
        }
    }
}
