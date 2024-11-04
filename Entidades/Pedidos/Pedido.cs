using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido
    {
        private int _pedidoId;
        private DateTime _fechaEntrega;
        private Proveedor _proveedor;
        private PedidoEstado _pedidoEstado;

        #region Constantes
        public const string NombreClase = "Pedido";
        #endregion

        #region Propiedades
        public int PedidoID { get { return _pedidoId; } set { _pedidoId = value; } }
        public DateTime FechaEntrega { get { return _fechaEntrega; } set { _fechaEntrega = value; } }
        public int ProveedorID { get; set; }
        public Proveedor Proveedor { get { return _proveedor; } set { _proveedor = value; } }
        public int PedidoEstadoID { get; set; }
        public PedidoEstado PedidoEstado { get { return _pedidoEstado; } set { _pedidoEstado = value; } }
        #endregion

        public Pedido() { }
    }
}
