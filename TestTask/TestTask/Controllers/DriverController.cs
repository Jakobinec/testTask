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
    /// Driver controller
    /// </summary>
    public class DriverController : ApiController
    {
        /// <summary>
        /// Gets all drivers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Driver> GetAll()
        {
            using (AppContext db = new AppContext())
            {
                return db.Drivers.ToList();
            }
        }

        /// <summary>
        /// Gets driver by id
        /// </summary>
        /// <param name="id">Target id</param>
        /// <returns></returns>
        [HttpGet]
        public Driver Get(int id)
        {
            using (AppContext db = new AppContext())
            {
                return db.Drivers.First(driver => driver.Id == id);
            }
        }

        /// <summary>
        /// Saves the driver
        /// </summary>
        /// <param name="driver"></param>
        [HttpPut]
        public void CreateDriver([FromUri]Driver driver)
        {
            using (AppContext db = new AppContext())
            {
                db.Drivers.Add(driver);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the driver
        /// </summary>
        /// <param name="driver"></param>
        [HttpPost]
        public void UpdateDriver([FromUri]Driver driver)
        {
            using (AppContext db = new AppContext())
            {
                db.Drivers.Attach(driver);
                db.Entry(driver).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a driver by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public void DeleteDriver(int id)
        {
            using (AppContext db = new AppContext())
            {
                Driver driver = new Driver() { Id = id };
                db.Drivers.Attach(driver);
                db.Drivers.Remove(driver);
                db.SaveChanges();
            }
        }
    }
}
