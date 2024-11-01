namespace Entidades
{
    public class Categoria
    {
        private int _categoriaID;
        private string _descripcion;
        private decimal _utilidad;

        #region Propiedades
        public int CategoriaID { get { return _categoriaID; } set { _categoriaID = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public decimal Utilidad { get { return _utilidad; } set { _utilidad = value; } }
        #endregion
        public const string NombreClase = "Categoria";

        public Categoria() { }


    }
}