using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoUsuario
    {
        private string _nombre;
        private string _rut;
        private string _empresa;
        private string _contresena;
        private int _idUsuario;
        private int _perfil;
        private bool _Verificador;
        private string _Usuario;
        private string _email;
        private int _idempresa;
        private string _clave;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Rut { get => _rut; set => _rut = value; }
        public string Empresa { get => _empresa; set => _empresa = value; }
        public string Contresena { get => _contresena; set => _contresena = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int Perfil { get => _perfil; set => _perfil = value; }
        public bool Verificador { get => _Verificador; set => _Verificador = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Email { get => _email; set => _email = value; }
        public int IdEmpresa { get => _idempresa; set => _idempresa = value; }
        public string Clave { get => _clave; set => _clave = value; }
    }
}
