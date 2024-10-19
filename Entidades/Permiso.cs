namespace Entidades
{
    public class Permiso
    {
        private int _permisoID;
        private string _codPermiso;
        private string _descripcion;

        #region Propiedades
        public int PermisoID { get { return _permisoID; } set { _permisoID = value; } }
        public string CodPermiso { get { return _codPermiso; } set { _codPermiso = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        #endregion
        public const string NombreClase = "Permiso";

        public Permiso() { }


    }
}