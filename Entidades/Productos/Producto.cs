using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{ 

    public class Producto
    {
        private int _productoID;
        private string _descripcion;
        private decimal? _costo;
        private string _codigoDeBarra;
        private Categoria _categoria;
        private Proveedor _proveedor;
        private int? _stock;

        #region Constantes
        public const string NombreClase = "Producto";
        #endregion

        #region Propiedades
        public int ProductoID { get { return _productoID; } set { _productoID = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public decimal? Costo { get { return _costo; } set { _costo = value; } }
        public string CodigoDeBarra { get { return _codigoDeBarra; } set { _codigoDeBarra = value; } }

        public int CategoriaID { get;set; }
        public Categoria Categoria { get { return _categoria; } set { _categoria = value; } }

        public int ProveedorID { get; set; }
        public Proveedor Proveedor { get { return _proveedor; } set { _proveedor = value; } }
        public int? Stock { get { return _stock; } set { _stock = value; } }
        //public ICollection<DetallePedido> DetallesPedido { get; set; }
        public decimal ValorVenta
        {
            get
            {
                if (Categoria != null)
                {
                    return Costo.GetValueOrDefault(0) + ((Costo.GetValueOrDefault(0) * Categoria.Utilidad) / 100);
                }
                else
                {
                    return Costo.GetValueOrDefault(0); // Retorna solo el Costo si Categoria es nula
                }
            }
        }


        public bool IsEditingCosto; //propiedad para modificar en web.
        #endregion

        public Producto()
        { 
            
        }
    }
}
