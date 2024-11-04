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
        const string Tabla = "dbo.Recepciones";
        public DetalleRecepcion() : base() { }

        public void Insertar(ClasePersistente clase)
        {
            try
            {
                base.Recepciones.Attach(clase.Recepcion);
                base.Productos.Attach(clase.Producto);
                base.DetallesRecepciones.Add(clase);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el pedido: " + ex.Message);
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

