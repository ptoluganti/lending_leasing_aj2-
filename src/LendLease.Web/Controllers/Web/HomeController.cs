using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LendLease.Web.Controllers.Web
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }

    public class PartialController : Controller
    {
        // GET: /<controller>/
        public IActionResult Message() => PartialView();
        public IActionResult Displaytemplate() => PartialView();
    }

}
