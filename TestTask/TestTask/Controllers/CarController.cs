using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TestTask.DB;
using TestTask.Models;

namespace TestTask.Controllers
{
    /// <summary>
    /// Car controller
    /// </summary>
    public class CarController : ApiController
    {
        /// <summary>
        /// Gets all cars
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Car> GetAll()
        {
            using (AppContext db = new AppContext())
            {
                return db.Cars.ToList();
            }
        }

        /// <summary>
        /// Gets car by id
        /// </summary>
        /// <param name="id">Target id</param>
        /// <returns></returns>
        [HttpGet]
        public Car Get(int id)
        {
            using (AppContext db = new AppContext())
            {
                return db.Cars.First(car => car.Id == id);
            }
        }

        /// <summary>
        /// Saves the car
        /// </summary>
        /// <param name="car"></param>
        [HttpPut]
        public void CreateCar([FromUri]Car car)
        {
            using (AppContext db = new AppContext())
            {
                db.Cars.Add(car);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the car
        /// </summary>
        /// <param name="car"></param>
        [HttpPost]
        public void UpdateCar([FromUri]Car car)
        {
            using (AppContext db = new AppContext())
            {
                db.Cars.Attach(car);
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a car by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public void DeleteCar(int id)
        {
            using (AppContext db = new AppContext())
            {
                Car car = new Car() { Id = id };
                db.Cars.Attach(car);
                db.Cars.Remove(car);
                db.SaveChanges();
            }
        }
    }
}
