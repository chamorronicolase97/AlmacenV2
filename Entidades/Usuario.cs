namespace Entidades
{
    public class Usuario
    {
        private int _usuarioID;
        private string _nombreApellido;
        private string _codUsuario;
        private string _contraseña;
        private Grupo _grupo;

        #region Propiedades
        public int UsuarioID { get { return _usuarioID; } set { _usuarioID = value; } }
        public string NombreApellido { get { return _nombreApellido; } set { _nombreApellido = value; } }
        public string CodUsuario { get { return _codUsuario; } set { _codUsuario = value; } }
        public string Contraseña { get { return _contraseña; } set { _contraseña = value; } }
        public Grupo Grupo { get { return _grupo; } set { _grupo = value; } }
        #endregion
        public const string NombreClase = "Usuario";

        public Usuario() { }


    }
}