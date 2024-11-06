using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasePersistente = Entidades.DetallePedido;

namespace Datos
{
    public class DetallePedido : AlmacenContext
    {
        const string Tabla = "dbo.DetallesPedidos";
        public DetallePedido() : base() { }

        public void Insertar(ClasePersistente clase)
        {
            try
            {
                // Adjunta solo si no está siendo rastreado ya en el contexto
                if (!base.Proveedores.Local.Any(p => p.ProveedorID == clase.Pedido.ProveedorID))
                {
                    base.Proveedores.Attach(clase.Pedido.Proveedor);
                }

                if (!base.Proveedores.Local.Any(p => p.ProveedorID == clase.Producto.ProveedorID))
                {
                    base.Proveedores.Attach(clase.Producto.Proveedor);
                }

                if (!base.Pedidos.Local.Any(p => p.PedidoID == clase.Pedido.PedidoID))
                {
                    base.Pedidos.Attach(clase.Pedido);
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


                // Agregar la entidad principal (DetallePedido)
                base.DetallesPedidos.Add(clase);
                base.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el DetallePedido: " + ex.Message);
            }
        }

        public void Modificar(ClasePersistente clase)
        {
            base.DetallesPedidos.Update(clase);
            base.SaveChanges();
        }

        public void Eliminar(ClasePersistente clase)
        {
            base.Pedidos.Attach(clase.Pedido);
            base.Productos.Attach(clase.Producto);
            base.DetallesPedidos.Remove(clase);
            base.SaveChanges();
        }

        public List<ClasePersistente> ListarDetallePorPedido(int PedidoID)
        {
            return base.DetallesPedidos.Include(u => u.Pedido).Include(u => u.Producto).Where(u => u.PedidoID == PedidoID).ToList();
        }

        public ClasePersistente Consultar(int PedidoID, int ProductoID)
        {
            return base.DetallesPedidos.Include(u => u.Pedido).Include(u => u.Producto).FirstOrDefault(u => u.PedidoID == PedidoID && u.ProductoID == u.ProductoID);
        }
    }
}

