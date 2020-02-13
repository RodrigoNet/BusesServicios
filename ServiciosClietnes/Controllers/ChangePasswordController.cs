using BLL;
using System.Collections.Generic;
using System.Web.Mvc;
using UTIL;
using UTIL.Objetos;
using UTIL.Validaciones;

namespace ServiciosClietnes.Controllers
{
    public class ChangePasswordController : Controller
    {
        Control Acceso = new Control();
        // GET: ChangePassword
        public ActionResult CambioPassword()
        {
            //datos de las tablas JQUERY
            IEnumerable<ObjetoUsuario> ListaUsuario = Acceso.ListadoUsuarios();
            ViewBag.ListaUsuarios = ListaUsuario;

            return View();
        }

        public JsonResult ModificarClave(int _Id, string newclave)
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SessionExpirada", "Error");
            }

            var validador = 0;
            if (_Id > 0)
            {
                ObjetoUsuario usuario = new ObjetoUsuario();
                usuario.IdUsuario = _Id;
                usuario.Contresena = HashMd5.GetMD5(newclave);              

                RespuestaModel resultado = Acceso.ModificarClave(usuario);
                if (resultado.Verificador == true)
                {
                    validador = 1;
                    return Json(validador);
                }
                else
                {
                    validador = 2;
                    return Json(validador);
                }
            }
            else
            {
                return Json(validador);
            }
        }
    }
}