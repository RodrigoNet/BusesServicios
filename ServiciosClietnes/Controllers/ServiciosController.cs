using BLL;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UTIL.Objetos;

namespace ServiciosClietnes.Controllers
{
    public class ServiciosController : Controller
    {
        Control Acceso = new Control();
        // GET: Servicios
        public ActionResult Servicios()
        {
            return View();
        }

        public JsonResult getServicios(string _cliente, string _fechaIni, string _fechaFin)
        {
            List<ObjetoServicios> servicios = Acceso.GetServicios(_cliente, _fechaIni, _fechaFin);
            return Json(new { list = servicios }, JsonRequestBehavior.AllowGet);
        }
    }
}