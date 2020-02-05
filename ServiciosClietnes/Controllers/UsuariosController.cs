using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using ServiciosClietnes.UTIL;
using UTIL;
using UTIL.Objetos;


namespace ServiciosClietnes.Controllers
{
    public class UsuariosController : Controller
    {
        Control Acceso = new Control();
        [HttpGet]
        [Autorizacion]
        public ActionResult Usuarios()
        {
            //datos de las tablas JQUERY
            IEnumerable<ObjetoUsuario> ListaUsuario = Acceso.ListadoUsuarios();
            ViewBag.ListaUsuarios = ListaUsuario;

            //datos para select HTML
            IEnumerable<SelectListItem> ListaClientes = Acceso.ListadoClientes().Select(c => new SelectListItem()
            {
                Text = c.Cliente,
                Value = c.Id.ToString()
            }).ToList();
            ViewBag.Clientes = ListaClientes;

            return View();
        }

        [HttpPost]
        public JsonResult AgregarUsuario(string _Usuario, string _Email, int _Cliente)
        {
            ObjetoUsuario usuario = new ObjetoUsuario();
            if (!string.IsNullOrEmpty(_Usuario))
            {
                usuario.Usuario = _Usuario;
                usuario.Email = _Email;  
                usuario.IdEmpresa = _Cliente;

                var resultado = Acceso.AgregarUsuario(usuario);
                if (resultado > 0)
                {
                    var val = 1;
                    return Json(val);
                    //return Json(new RespuestaModel() { Verificador = true, Mensaje = "Usuario creado correctamente", NumInt = resultado });
                }
                else
                {
                    return Json(new RespuestaModel() { Verificador = false, Mensaje = "Error" });
                }
            }
            else
            {
                return Json(new RespuestaModel() { Verificador = false, Mensaje = "Debe ingresar campos obligatorios" });
            }

        }


        public JsonResult ModificarUsuario(int _IdUsuario,string _Usuario, string _Cliente,string _Email)
        {
            if (SessionVariables.Session_Datos_Usuarios == null)
            {
                RedirectToAction("SessionExpirada", "Error");
            }

            var validador = 0;
            if (_IdUsuario > 0)
            {
                ObjetoUsuario usuario = new ObjetoUsuario();
                usuario.IdUsuario = _IdUsuario;
                usuario.Usuario = _Usuario;
                usuario.IdEmpresa =int.Parse(_Cliente);
                usuario.Email = _Email;

                RespuestaModel resultado = Acceso.ModificarUsuario(usuario);
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

        [HttpGet]
        public JsonResult GetUsuario(int _IdUsuario)
        {
            if (_IdUsuario != 0)
            {   
                List<ObjetoUsuario> lUsuario = Acceso.GetUsuario(_IdUsuario);
                return Json(new { list = lUsuario }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var validador = 0;
                return Json(validador);
            }
        }

        public JsonResult EliminarUsuario(int _IdUsuario)
        {
            ObjetoUsuario usuario = new ObjetoUsuario();
            if (_IdUsuario != 0)
            {
                usuario.IdUsuario = _IdUsuario;
                RespuestaModel result = Acceso.EliminarUsuario(usuario);
                return (Json(result));
            }
            else
            {
                var validador = 0;
                return Json(validador);
            }
        }

    }
}