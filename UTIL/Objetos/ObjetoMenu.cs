using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoMenu
    {
        private int _idmenu;
        private string _clase;
        private string _pieMenu;
        private string _titulo;
        private string _action;
        private string _controller;
        private string _tipoUsuario;
        private int _activo;
        private int _orden;

        public int Idmenu { get => _idmenu; set => _idmenu = value; }
        public string Clase { get => _clase; set => _clase = value; }
        public string PieMenu { get => _pieMenu; set => _pieMenu = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Action { get => _action; set => _action = value; }
        public string Controller { get => _controller; set => _controller = value; }
        public string TipoUsuario { get => _tipoUsuario; set => _tipoUsuario = value; }
        public int Activo { get => _activo; set => _activo = value; }
        public int Orden { get => _orden; set => _orden = value; }
    }
}
