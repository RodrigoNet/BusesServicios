using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoServicios
    {
        private int _id;
        private DateTime _fecha;
        private string _cliente;
        private string _ruta;
        private string _vehiculo;

        public int Id { get => _id; set => _id = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Cliente { get => _cliente; set => _cliente = value; }
        public string Ruta { get => _ruta; set => _ruta = value; }
        public string Vehiculo { get => _vehiculo; set => _vehiculo = value; }
    }
}
