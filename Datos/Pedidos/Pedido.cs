using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasePersistente = Entidades.Pedido;

namespace Datos
{
    public class Pedido : AlmacenContext
    {
        const string Tabla = "dbo.Pedidos";
        public Pedido() : base() { }

        public void Insertar(ClasePersistente clase)
        {
            try
            {
                base.PedidosEstados.Attach(clase.PedidoEstado);
                base.Proveedores.Attach(clase.Proveedor);
                base.Pedidos.Add(clase);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el producto: " + ex.Message);
            }
        }

        public void Modificar(ClasePersistente clase)
        {
            base.Pedidos.Update(clase);
            base.SaveChanges();
        }

        public void Eliminar(ClasePersistente clase)
        {
            base.PedidosEstados.Attach(clase.PedidoEstado);
            base.Proveedores.Attach(clase.Proveedor);
            base.Pedidos.Remove(clase);
            base.SaveChanges();
        }

        public List<ClasePersistente> ListarProductos()
        {
            return base.Pedidos.Include(u => u.PedidoEstado).Include(u => u.Proveedor).ToList();
        }

        public ClasePersistente Consultar(int ID)
        {
            return base.Pedidos.Include(u => u.PedidoEstado).Include(u => u.Proveedor).FirstOrDefault(u => u.ID == ID);
        }
    }
}

