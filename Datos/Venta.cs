using Microsoft.EntityFrameworkCore;
using Sistema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasePersistente = Entidades.Venta;

namespace Datos
{
    public class Venta:AlmacenContext
    {
        const string Tabla = "dbo.Ventas";
        public Venta():base() { }

        public void Insertar(ClasePersistente clase)
        {
            try
            {
                base.Clientes.Attach(clase.Cliente);
                base.Productos.Attach(clase.Producto);
                base.Ventas.Add(clase);            
                base.SaveChanges();
            }
            catch(Exception ex) 
            {
                throw new Exception("Error al insertar el Venta: " + ex.Message);
            }
        }

        public void Modificar(ClasePersistente clase)
        {
            base.Ventas.Update(clase);
            base.SaveChanges();
        }

        public void Eliminar(ClasePersistente clase)
        {
            base.Clientes.Attach(clase.Cliente);
            base.Productos.Attach(clase.Producto);
            base.Ventas.Remove(clase);
            base.SaveChanges();
        }

        public List<ClasePersistente> ListarVentas()
        {
            return base.Ventas.Include(u => u.Cliente).Include(u => u.Producto).ToList();
        }

        public ClasePersistente Consultar(int ID)
        {
            return base.Ventas.Include(u => u.Cliente).Include(u => u.Producto).FirstOrDefault(u => u.VentaID == ID);
        }



    }
}
