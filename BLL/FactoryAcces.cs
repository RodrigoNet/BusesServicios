using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using UTIL.Objetos;

namespace BLL
{
    public class FactoryAcces
    {
        #region Usuario
        
        public ObjetoUsuario LoginUsuario(ObjetoUsuario datosUsuario)
        {
            var DatosLogin = new ObjetoUsuario();
            var data = new Conector().EjecutarSP("Web_GetLogin", new System.Collections.Hashtable()
            {
                {"Usuario", datosUsuario.Nombre },
                {"Contrasena", datosUsuario.Contresena }
            });
            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    // retorna UTIL.;Apper.BindData<ObjetoUsuario>(data);
                    var validador = new object();

                    validador = data.Rows[i].Field<object>("Id");
                    datosUsuario.IdUsuario = validador != null ? data.Rows[i].Field<int>("Id") : 0;

                    validador = data.Rows[i].Field<object>("Usuario");
                    datosUsuario.Nombre = validador != null ? data.Rows[i].Field<string>("Usuario") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Perfil");
                    datosUsuario.Perfil = validador != null ? data.Rows[i].Field<int>("Perfil") : 0;

                    validador = data.Rows[i].Field<object>("Verificador");
                    datosUsuario.Verificador = validador != null ? data.Rows[i].Field<bool>("Verificador") : false;
                }
            }
            else
            {
                datosUsuario = null;
            }
            return datosUsuario;
        }

        public List<ObjetoMenu> MenuUsuario(int Perfil)
        {
            var listadoMenu = new List<ObjetoMenu>();
            var data = new Conector().EjecutarSP("Web_GetMenu", new System.Collections.Hashtable()
            {
                {"Perfil", Perfil}
            });
            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; ++i)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoMenu();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.Idmenu = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Clase");
                    resultadoListado.Clase = validador != null ? data.Rows[i].Field<string>("Clase") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("PieMenu");
                    resultadoListado.PieMenu = validador != null ? data.Rows[i].Field<string>("PieMenu") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Titulo");
                    resultadoListado.Titulo = validador != null ? data.Rows[i].Field<string>("Titulo") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Action");
                    resultadoListado.Action = validador != null ? data.Rows[i].Field<string>("Action") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Controller");
                    resultadoListado.Controller = validador != null ? data.Rows[i].Field<string>("Controller") : "NO ASIGNADO";

                    listadoMenu.Add(resultadoListado);
                }
            }
            return listadoMenu;
        }

        public List<ObjetoUsuario> ListadoUsuarios()
        {
            var Listado = new List<ObjetoUsuario>();
            var data = new Conector().EjecutarSP("Web_GetUsuarios", new System.Collections.Hashtable());
            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var rsListdado = new ObjetoUsuario();

                    validador = data.Rows[i].Field<object>("Id");
                    rsListdado.IdUsuario = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Usuario");
                    rsListdado.Usuario = validador != null ? data.Rows[i].Field<string>("Usuario") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Email");
                    rsListdado.Email = validador != null ? data.Rows[i].Field<string>("Email") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Perfil");
                    rsListdado.Perfil = validador != null ? data.Rows[i].Field<int>("Perfil") : 0;

                    validador = data.Rows[i].Field<object>("Nombre");
                    rsListdado.Nombre = validador != null ? data.Rows[i].Field<string>("Nombre") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Rut");
                    rsListdado.Rut = validador != null ? data.Rows[i].Field<string>("Rut") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Empresa");
                    rsListdado.Empresa = validador != null ? data.Rows[i].Field<string>("Empresa") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("IdEmpresa");
                    rsListdado.IdEmpresa = validador != null ? data.Rows[i].Field<int>("IdEmpresa") : 0;

                    Listado.Add(rsListdado);
                }
            }
            return Listado;
        }

        public List<ObjetoClientes> ListadoClientes()
        {
            var Listado = new List<ObjetoClientes>();
            var data = new Conector().EjecutarSP("Web_GetClientes", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var rsListado = new ObjetoClientes();

                    validador = data.Rows[i].Field<object>("Id");
                    rsListado.Id = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Cliente");
                    rsListado.Cliente = validador != null ? data.Rows[i].Field<string>("Cliente") : "NO ASIGNADO";

                    Listado.Add(rsListado);
                }
            }
            return Listado;
        }

        public List<ObjetoUsuario> GetUsuario(int IdUsuario)
        {
            var Listado = new List<ObjetoUsuario>();
            var data = new Conector().EjecutarSP("Web_GetUsuario", new System.Collections.Hashtable()
            {
                { "IdUsuario",IdUsuario}
            });

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var rsListado = new ObjetoUsuario();

                    validador = data.Rows[i].Field<object>("Id");
                    rsListado.IdUsuario = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Usuario");
                    rsListado.Usuario = validador != null ? data.Rows[i].Field<string>("Usuario") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Email");
                    rsListado.Email = validador != null ? data.Rows[i].Field<string>("Email") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Perfil");
                    rsListado.Perfil = validador != null ? data.Rows[i].Field<int>("Perfil") : 0;

                    validador = data.Rows[i].Field<object>("Nombre");
                    rsListado.Nombre = validador != null ? data.Rows[i].Field<string>("Nombre") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Rut");
                    rsListado.Rut = validador != null ? data.Rows[i].Field<string>("Rut") : "NO ASIGNADO";

                    //validador = data.Rows[i].Field<object>("Empresa");
                    //rsListado.Empresa = validador != null ? data.Rows[i].Field<string>("Empresa") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Empresa");
                    rsListado.IdEmpresa = validador != null ? data.Rows[i].Field<int>("Empresa") : 0;

                    Listado.Add(rsListado);
                }
            }
            return Listado;
        }

        public int AgregarUsuario(ObjetoUsuario usuario)
        {
            int respuesta = 0;
            try
            {
                var data = new Conector().EjecutarSP("Web_CrearUsuario", new System.Collections.Hashtable()
                {
                    {"Usuario",usuario.Usuario },
                    {"Cliente",usuario.IdEmpresa },
                    {"Email",usuario.Email }
                });
                if (data.Rows.Count > 0)
                {
                    respuesta = int.Parse(data.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }

        public RespuestaModel ModificarUsuario(ObjetoUsuario usuario)
        {
            RespuestaModel resp = new RespuestaModel();
            try
            {
                var data = new Conector().EjecutarSP("Web_ModificaUsuario", new System.Collections.Hashtable()
                {
                    {"IdUsuario", usuario.IdUsuario},
                    {"Usuario", usuario.Usuario},
                    {"Cliente", usuario.IdEmpresa}
                });
                if (data.Rows.Count > 0)
                {
                    for (var i = 0; i < data.Rows.Count; i++)
                    {
                        var validador = new object();

                        validador = data.Rows[i].Field<object>("Verificador");
                        resp.Verificador = validador != null ? data.Rows[i].Field<bool>("Verificador") : false;

                        validador = data.Rows[i].Field<object>("Mensaje");
                        resp.Mensaje = validador != null ? data.Rows[i].Field<string>("Mensaje") : "NO ASIGNADO";
                    }
                }
                else
                {
                    resp = null;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return resp;
        }

        public RespuestaModel EliminarUsuario(ObjetoUsuario usuario)
        {
            RespuestaModel resp = new RespuestaModel();
            try
            {
                var data = new Conector().EjecutarSP("Web_EliminaUsuario", new System.Collections.Hashtable()
                {
                    {"IdUsuario", usuario.IdUsuario },
                });

                if (data.Rows.Count > 0)
                {
                    for (var i = 0; i < data.Rows.Count; i++)
                    {
                        var validador = new object();
                        validador = data.Rows[i].Field<object>("Verificador");
                        resp.Verificador = validador != null ? data.Rows[i].Field<bool>("Verificador") : false;

                        validador = data.Rows[i].Field<object>("Mensaje");
                        resp.Mensaje = validador != null ? data.Rows[i].Field<string>("Mensaje") : "NO ASIGNADO";
                    }
                }
                else
                {
                    resp = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }

        #endregion

        #region Servicios
        public List<ObjetoServicios> GetServicios(string cliente, string FechaIni, string FechaFin)
        {
            var Listado = new List<ObjetoServicios>();
            var data = new Conector().EjecutarSP("Web_GetServicios", new System.Collections.Hashtable()
            {
                {"Cliente", cliente },
                {"FechaIni", String.Format(FechaIni,"yyyy-MM-dd") },
                {"FechaFin", String.Format(FechaFin,"yyyy-MM-dd") }
            });
            if (data.Rows.Count > 0)
            {
                for (var i=0;i<data.Rows.Count;i++)
                {
                    var validador = new object();
                    var dtLista = new ObjetoServicios();

                    validador = data.Rows[i].Field<object>("Id");
                    dtLista.Id = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Cliente");
                    dtLista.Cliente = validador != null ? data.Rows[i].Field<string>("Cliente") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Ruta");
                    dtLista.Ruta = validador != null ? data.Rows[i].Field<string>("Ruta") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Vehiculo");
                    dtLista.Vehiculo = validador != null ? data.Rows[i].Field<string>("Vehiculo") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Fecha");
                    dtLista.Fecha = validador != null ? data.Rows[i].Field<DateTime>("Fecha") : DateTime.Now;

                    Listado.Add(dtLista);
                }
            }
            return Listado;
        }
        #endregion
    }
}
