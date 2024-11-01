using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasePersistente = Entidades.Producto;

namespace Datos
{
    public class Producto:AlmacenContext
    {
        const string Tabla = "dbo.Productos";
        public Producto():base() { }

        public void Insertar(ClasePersistente clase)
        {
            base.Productos.Add(clase);
            base.SaveChanges();
        }

        public void Modificar(ClasePersistente clase)
        {
            base.Productos.Update(clase);
            base.SaveChanges();
        }

        public void Eliminar(ClasePersistente clase)
        {
            base.Productos.Remove(clase);
            base.SaveChanges();
        }

        public List<ClasePersistente> ListarProductos()
        {
            return base.Productos.Include(u => u.Categoria).Include(u => u.Proveedor).ToList();
        }

        public ClasePersistente Consultar(int ID)
        {
            return base.Productos.Include(u => u.Categoria).Include(u => u.Proveedor).FirstOrDefault(u => u.ProductoID == ID);
        }       
    }
}
