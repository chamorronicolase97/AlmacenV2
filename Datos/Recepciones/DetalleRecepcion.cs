using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasePersistente = Entidades.DetalleRecepcion;

namespace Datos
{
    public class DetalleRecepcion : AlmacenContext
    {
        const string Tabla = "dbo.DetallesRecepciones";
        public DetalleRecepcion() : base() { }

        public void Insertar(ClasePersistente clase)
        {
            try
            {
                // Adjunta solo si no está siendo rastreado ya en el contexto
                if (!base.Pedidos.Local.Any(p => p.PedidoID == clase.Recepcion.PedidoID))
                {
                    base.Pedidos.Attach(clase.Recepcion.Pedido);
                }

                if (!base.Proveedores.Local.Any(p => p.ProveedorID == clase.Producto.ProveedorID))
                {
                    base.Proveedores.Attach(clase.Producto.Proveedor);
                }

                if (!base.Recepciones.Local.Any(p => p.RecepcionID == clase.Recepcion.RecepcionID))
                {
                    base.Recepciones.Attach(clase.Recepcion);
                }
                var productoExistente = base.Productos.Find(clase.Producto.ProductoID);
                if (productoExistente != null)
                {
                    clase.Producto = productoExistente;
                }
                else
                {
                    base.Productos.Attach(clase.Producto);
                }


                // Agregar la entidad principal (DetalleRecepcion)
                base.DetallesRecepciones.Add(clase);
                base.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el DetalleRecepcion: " + ex.Message);
            }
        }

        public void Modificar(ClasePersistente clase)
        {
            base.DetallesRecepciones.Update(clase);
            base.SaveChanges();
        }

        public void Eliminar(ClasePersistente clase)
        {
            base.Recepciones.Attach(clase.Recepcion);
            base.Productos.Attach(clase.Producto);
            base.DetallesRecepciones.Remove(clase);
            base.SaveChanges();
        }

        public List<ClasePersistente> ListarDetallePorRecepcion(int RecepcionID)
        {
            return base.DetallesRecepciones.Include(u => u.Recepcion).Include(u => u.Producto).Where(u => u.RecepcionID == RecepcionID).ToList();
        }

        public ClasePersistente Consultar(int RecepcionID, int ProductoID)
        {
            return base.DetallesRecepciones.Include(u => u.Recepcion).Include(u => u.Producto).FirstOrDefault(u => u.RecepcionID == RecepcionID && u.ProductoID == u.ProductoID);
        }
    }
}

