namespace Entidades
{
    public class Cliente
    {
        private int _id;
        private string _cuit;
        private string _denominacion;
        private string _domicilio;
        private string _email;
        private string _telefono;
        private bool _empleado;
        private bool _preferencial;

        #region Propiedades
        public int ID { get { return _id; } set { _id = value; } }
        public string Cuit { get { return _cuit; } set { _cuit = value; } }
        public string Denominacion { get { return _denominacion; } set { _denominacion = value; } }
        public string Direccion { get { return _domicilio; } set { _domicilio = value; } }
        public string Mail { get { return _email; } set { _email = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        public bool Empleado { get { return _empleado; } set { _empleado = value; } }
        public bool Preferencial { get { return _preferencial; } set { _preferencial = value; } }

        #endregion

        public const string NombreClase = "Cliente";

        public Cliente() { }
    }
}
