using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoClientes
    {
        private int _id;
        private string _cliente;

        public int Id { get => _id; set => _id = value; }
        public string Cliente { get => _cliente; set => _cliente = value; }
    }
}
