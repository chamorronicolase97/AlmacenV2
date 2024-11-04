using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetallePedido
    {
        private Pedido pedido;
        private Producto producto;
        private int _cantidad;
        private decimal _costoUnitario;

        #region Constantes
        const string Tabla = "dbo.DetallesPedidos";
        public const string NombreClase = "DetallePedido";
        #endregion

        #region Propiedades
        [Key]
        public int PedidoID { get; set; }
        [Key]
        public int ProductoID { get; set; }

        public Pedido Pedido { get { return pedido; } set { pedido = value; } }
        public Producto Producto { get { return producto; } set { producto = value; } }
        public int Cantidad { get { return _cantidad; } set { _cantidad = value; } }
        public decimal CostoUnitario { get { return _costoUnitario; } set { _costoUnitario = value; } }
        #endregion

        public DetallePedido() { }
    }
}
