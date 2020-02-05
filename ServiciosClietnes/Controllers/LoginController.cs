using BLL;
using System.Web.Mvc;
using UTIL;
using UTIL.Objetos;
using UTIL.Validaciones;


namespace ServiciosClietnes.Controllers
{
    public class LoginController : Controller
    {
        Control Acceso = new Control();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string _nombre, string _contrasena)
        {
            var datoUsuario = new ObjetoUsuario();
            SessionVariables.Session_Datos_Usuarios = null;
            var validador = 0;
            datoUsuario.Nombre = _nombre;
            datoUsuario.Contresena = HashMd5.GetMD5(_contrasena);

            var resultado = Acceso.LoginUsuario(datoUsuario);
            SessionVariables.Session_Datos_Usuarios = resultado;

            if (resultado.Verificador != false)
            {
                validador = 2;
                return Json(validador);
            }
            else
            {
                return Json(new RespuestaModel() { Verificador = false, Mensaje = "Error de usuario y/o contraseña" });
            }
        }

        public ActionResult LogOut()
        {
            SessionVariables.Session_Datos_Usuarios = null;
            return RedirectToAction("Login", "Login");
        }

    }
}
