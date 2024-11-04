using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleRecepcion
    {
        private Recepcion _recepcion;
        private Producto producto;
        private int _cantidad;
        private decimal _costoUnitario;
        public DateTime _fechaRecepcion;

        #region Constantes
        const string Tabla = "dbo.DetallesRecepciones";
        public const string NombreClase = "DetalleRecepcion";
        #endregion

        #region Propiedades
        [Key]
        public int RecepcionID { get; set; }
        [Key]
        public int ProductoID { get; set; }
        public Recepcion Recepcion { get { return _recepcion; } set { _recepcion = value; } }
        public Producto Producto { get { return producto; } set { producto = value; } }
        public int Cantidad { get { return _cantidad; } set { _cantidad = value; } }
        public decimal CostoUnitario { get { return _costoUnitario; } set { _costoUnitario = value; } }
        public DateTime FechaRecepcion { get { return _fechaRecepcion; } set { _fechaRecepcion = value; } }
        #endregion

        public DetalleRecepcion() { }
    }
}
