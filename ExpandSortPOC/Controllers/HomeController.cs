using System.Web.Mvc;

namespace ExpandSortPOC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            if (Request.Url != null) ViewBag.Host = Request.Url.Host;
            return View();
        }
    }
}