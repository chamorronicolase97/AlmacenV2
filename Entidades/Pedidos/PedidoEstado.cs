namespace Entidades
{
    public class PedidoEstado
    {
        private int _pedidoEstadoID;
        private string _descripcion;

        #region Propiedades
        public int PedidoEstadoID { get { return _pedidoEstadoID; } set { _pedidoEstadoID = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        #endregion
        public const string NombreClase = "PedidoEstado";

        public PedidoEstado() { }      

    }
}