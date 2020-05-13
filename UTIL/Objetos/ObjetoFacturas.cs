using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL.Objetos
{
    public class ObjetoFacturas
    {
        private int _id;
        private string _cliente;
        private DateTime _fecha;
        private int _total;
        private int _NroFactura;
        private string _Estado;

        public int Id { get => _id; set => _id = value; }
        public string Cliente { get => _cliente; set => _cliente = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        //
        //se usa para que js tome bien la fecha
        public string fechaString { get { return this.Fecha == null ? "" : Fecha.ToString("dd/MM/yyyy"); } }
        //
        public int Total { get => _total; set => _total = value; }
        public int NroFactura { get => _NroFactura; set => _NroFactura = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
    }
}
