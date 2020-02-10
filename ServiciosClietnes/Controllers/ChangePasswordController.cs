using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiciosClietnes.Controllers
{
    public class ChangePasswordController : Controller
    {
        // GET: ChangePassword
        public ActionResult CambioPassword()
        {
            return View();
        }

    }
}