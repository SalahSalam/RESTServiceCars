using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RESTServiceCars.Model;

namespace carsRESTprovider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private static readonly List<Car> Cars = new List<Car>
        {
            new Car {Id=1, Model = "Amazon", Vendor = "Volvo", Price = 12345},
            new Car {Id=2, Model = "A8", Vendor = "Audi", Price = 2222222},
            new Car {Id=3, Model = "Punto", Vendor = "Fiat", Price = 102022}
        };

        private static int _nextId = 4;

        // GET: api/Cars
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return Cars;
        }

        // GET: api/Cars/5
        [HttpGet]
        [Route("{id}")]
        public Car Get(int id)
        {
            return Cars.FirstOrDefault(car => car.Id == id);
        }

        // POST: api/Cars
        [HttpPost]
        public int Post([FromBody] Car car)
        {
            car.Id = _nextId++;
            Cars.Add(car);
            return car.Id;
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string car)
        {
            //int index = Cars.FindIndex(car1 => car1.Id == id);
            //if (index > 0) { }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return Cars.RemoveAll(car => car.Id == id);
        }
    }
}