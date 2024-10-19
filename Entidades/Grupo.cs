namespace Entidades
{
    public class Grupo
    {
        private int _grupoID;
        private string _descripcion;
        private decimal _utilidad;

        #region Propiedades
        public int GrupoID { get { return _grupoID; } set { _grupoID = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        #endregion
        public const string NombreClase = "Grupo";

        public Grupo() { }


    }
}