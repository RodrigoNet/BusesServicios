using ServiciosClietnes.UTIL;
using System.Web.Mvc;

namespace ServiciosClietnes.Controllers
{
    public class HomeController : Controller
    {
        [Autorizacion]
        public ActionResult Index()
        {
            return View();
        }
    }
}