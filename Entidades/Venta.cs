using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class Venta
    {
        private int _ventaID;
        private Cliente _cliente;
        private Producto _producto;
        private DateTime _fecha;
        private int _cantidad;
        private decimal? _importe;

        #region Constantes
        public const string NombreClase = "Venta";
        #endregion

        #region Propiedades
        public int VentaID { get { return _ventaID; } set { _ventaID = value; } }
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
        public int Cantidad { get { return _cantidad; } set { _cantidad = value; } }
        public decimal? Importe { get { return _importe; } set { _importe = value; } }

        public int ClienteID { get; set; }
        public Cliente Cliente { get { return _cliente; } set { _cliente = value; } }

        public int ProductoID { get; set; }
        public Producto Producto { get { return _producto; } set { _producto = value; } }
        #endregion

        public Venta()
        {

        }
    }
}
