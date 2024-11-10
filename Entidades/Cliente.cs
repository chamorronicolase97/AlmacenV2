namespace Entidades
{
    public class Cliente
    {
        private int _clienteId;
        private string _cuit;
        private string _denominacion;
        private string _domicilio;
        private string _email;
        private string _telefono;
        private bool _empleado;
        private bool _preferencial;
        private string _usuario;
        private string _contraseña;

        #region Propiedades
        public int ClienteID { get { return _clienteId; } set { _clienteId = value; } }
        public string Cuit { get { return _cuit; } set { _cuit = value; } }
        public string Denominacion { get { return _denominacion; } set { _denominacion = value; } }
        public string Domicilio { get { return _domicilio; } set { _domicilio = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        public bool Empleado { get { return _empleado; } set { _empleado = value; } }
        public bool Preferencial { get { return _preferencial; } set { _preferencial = value; } }
        public string Usuario { get { return _usuario; } set { _usuario = value; } }
        public string Contraseña { get { return _contraseña; } set { _contraseña = value; } }
        #endregion

        public const string NombreClase = "Cliente";

        public Cliente() { }
    }
}
