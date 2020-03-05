using System.Web.Mvc;

namespace OWIN.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [Authorize]
        public ActionResult Protected()
        {
            return View();
        }
    }
}
