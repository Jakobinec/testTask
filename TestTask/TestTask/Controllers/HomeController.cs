using System.Web.Mvc;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Comes to car edit form or create form if id does not set
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ViewCar(int id=0)
        {
            ViewBag.id = id;
            return View("CarView");
        }

        /// <summary>
        /// Comes to driver edit form or create form if id does not set
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ViewDriver(int id=0)
        {
            ViewBag.id = id;
            return View("DriverView");
        }
    }
}