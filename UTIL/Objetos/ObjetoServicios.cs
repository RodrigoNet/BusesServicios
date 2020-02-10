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
        private string _hora;
        private string _conductor;

        public int Id { get => _id; set => _id = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        

        //
        //se usa para que js tome bien la fecha
        public string fechaString { get { return this.Fecha == null ? "" : Fecha.ToString("dd/MM/yyyy"); } }
        //
        public string Cliente { get => _cliente; set => _cliente = value; }
        public string Ruta { get => _ruta; set => _ruta = value; }
        public string Vehiculo { get => _vehiculo; set => _vehiculo = value; }
        public string Hora { get => _hora; set => _hora = value; }
        public string Conductor { get => _conductor; set => _conductor = value; }
    }
}
