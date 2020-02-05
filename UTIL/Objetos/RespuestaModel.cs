namespace UTIL.Objetos
{
    public class RespuestaModel
    {
        private bool _verificador;
        private string _mensaje;
        private int _numInt;

        public bool Verificador { get => _verificador; set => _verificador = value; }
        public string Mensaje { get => _mensaje; set => _mensaje = value; }
        public int NumInt { get => _numInt; set => _numInt = value; }
    }
}
