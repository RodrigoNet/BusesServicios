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
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SessionExpirada", "Error");
            }

            if (!string.IsNullOrEmpty(_fechaIni) && !string.IsNullOrEmpty(_fechaFin))
            {
                var cliente = SessionVariables.Session_Datos_Usuarios.IdEmpresa;
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
        }

        [HttpGet]
        public ActionResult descargaExcel(string fechaIni, string fechaFin)
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SessionExpirada", "Error");
            }
            var cliente = SessionVariables.Session_Datos_Usuarios.IdEmpresa;
            byte[] data;
            try
            {
                var memoryStream = new MemoryStream();
                using (var excelPackage = new ExcelPackage(memoryStream))
                {
                    var worsheet = excelPackage.Workbook.Worksheets.Add("Servicios");
                    string cabecera = "NroServicio; Fecha; Hora; Cliente; Conductor; Ruta; Vehiculo";
                    string[] cab = cabecera.Split(';');
                    int i = 1;
                    foreach (var c in cab)
                    {
                        worsheet.Cells[1, i].Value = c;
                        i++;
                    }
                    ObjetoServicios servicio = new ObjetoServicios();
                    var listadoServicios = new List<ObjetoServicios>();

                    listadoServicios = Acceso.GetServicios(cliente, fechaIni, fechaFin);

                    i = 2;
                    foreach (ObjetoServicios obj in listadoServicios)
                    {
                        worsheet.Cells[i, 1].Value = obj.Id;
                        worsheet.Cells[i, 2].Value = obj.Fecha;
                        worsheet.Cells[i, 3].Value = obj.Hora;
                        worsheet.Cells[i, 4].Value = obj.Cliente;
                        worsheet.Cells[i, 5].Value = obj.Conductor;
                        worsheet.Cells[i, 6].Value = obj.Ruta;
                        worsheet.Cells[i, 7].Value = obj.Vehiculo;
                        i++;
                    }
                    data = excelPackage.GetAsByteArray();
                }
            }
            
            catch (Exception ex)
            {
                throw;
            }
            var filename = "Servicios.xlsx";
            return File(data, "application/octet-stream/", filename);
        }
    }
}

