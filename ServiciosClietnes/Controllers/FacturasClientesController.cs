using BLL;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using UTIL;
using UTIL.Objetos;

namespace ServiciosClietnes.Controllers
{
    public class FacturasClientesController : Controller
    {
        Control Acceso = new Control();
        // GET: FacturasCliente
        public ActionResult FacturasCliente()
        {
            return View();
        }

        public JsonResult GetFacturas( string _fechaIni, string _fechaFin)
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SessionExpirada", "Error");
            }

            if (!string.IsNullOrEmpty(_fechaIni) && !string.IsNullOrEmpty(_fechaFin))
            {
                var cliente = SessionVariables.Session_Datos_Usuarios.IdEmpresa;
                var ListadoFacturas = Acceso.GetFacturas(cliente, _fechaIni, _fechaFin);
                if (ListadoFacturas.Count > 0)
                {
                    return Json(new { list = ListadoFacturas }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ViewBag.mensaje = 0;
                    //return Json(new { mensaje = ViewBag.mensaje }, JsonRequestBehavior.AllowGet);
                    return Json(new {list= ListadoFacturas}, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return null;
            }
        }
    }
}