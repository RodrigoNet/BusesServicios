using BLL;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UTIL;
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

        public JsonResult getServicios(string _fechaIni, string _fechaFin)
        {
            if (!string.IsNullOrEmpty(_fechaIni) && !string.IsNullOrEmpty(_fechaFin))
            {
                var cliente = SessionVariables.Session_Datos_Usuarios.IdUsuario;
                var listadoServicios = Acceso.GetServicios(cliente,_fechaIni, _fechaFin);
                if (listadoServicios != null)
                {
                    return Json(new { list = listadoServicios }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ViewBag.mensaje = 0;
                    return Json(new { mensaje = ViewBag.mensaje }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return null;
            }
            //List<ObjetoServicios> servicios = Acceso.GetServicios(_cliente, _fechaIni, _fechaFin);
            //return Json(new { list = servicios }, JsonRequestBehavior.AllowGet);
        }
    }
}