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
    public class ExportExcelController : Controller
    {
        Control Acceso = new Control();
        //// GET: ExportExcel
        //public ActionResult Index()
        //{
        //    return View();
        //}
        
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
                        worsheet.Cells[i, 2].Value = obj.fechaString;
                        worsheet.Cells[i, 2].Value = obj.Hora;
                        worsheet.Cells[i, 2].Value = obj.Cliente;
                        worsheet.Cells[i, 2].Value = obj.Conductor;
                        worsheet.Cells[i, 2].Value = obj.Ruta;
                        worsheet.Cells[i, 2].Value = obj.Vehiculo;
                        i++;
                    }
                    data = excelPackage.GetAsByteArray();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return File(data, "application/octet-stream/Servicios.xlsx");
        }
    }
}