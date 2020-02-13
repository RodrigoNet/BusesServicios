using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTIL.Objetos;

namespace BLL
{
    public class Control
    {
        private FactoryAcces Acceso = new FactoryAcces();

        #region Login
        public ObjetoUsuario LoginUsuario(ObjetoUsuario usuario)
        {
            return Acceso.LoginUsuario(usuario);
        }

        public List<ObjetoMenu> MenuUsuario(int Perfil)
        {
            return Acceso.MenuUsuario(Perfil);
        }
        #endregion

        #region Usuarios
        public List<ObjetoUsuario> ListadoUsuarios()
        {
            return Acceso.ListadoUsuarios();
        }
        public List<ObjetoClientes> ListadoClientes()
        {
            return Acceso.ListadoClientes();
        }
        public List<ObjetoUsuario> GetUsuario(int IdUsuario)
        {
            return Acceso.GetUsuario(IdUsuario);
        }
        public int AgregarUsuario(ObjetoUsuario usuario)
        {
            return Acceso.AgregarUsuario(usuario);
        }
        public RespuestaModel ModificarUsuario(ObjetoUsuario usuario)
        {
            return Acceso.ModificarUsuario(usuario);
        }
        public RespuestaModel EliminarUsuario(ObjetoUsuario usuario)
        {
            return Acceso.EliminarUsuario(usuario);
        }

        public RespuestaModel ModificarClave(ObjetoUsuario usuario)
        {
            return Acceso.ModificarClave(usuario);
        }
        #endregion

        #region Servicios
        public List<ObjetoServicios> GetServicios(int cliente, string fechaIni, string fechaFin)
        {
            return Acceso.GetServicios(cliente, fechaIni, fechaFin);
        }
        #endregion

    }
}
