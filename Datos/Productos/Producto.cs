using Microsoft.EntityFrameworkCore;
using Sistema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            try
            {
                base.Categorias.Attach(clase.Categoria);
                base.Proveedores.Attach(clase.Proveedor);
                base.Productos.Add(clase);            
                base.SaveChanges();
            }
            catch(Exception ex) 
            {
                throw new Exception("Error al insertar el producto: " + ex.Message);
            }
        }

        public void Modificar(ClasePersistente clase)
        {
            base.Productos.Update(clase);
            base.SaveChanges();
        }

        public void Eliminar(ClasePersistente clase)
        {
            base.Categorias.Attach(clase.Categoria);
            base.Proveedores.Attach(clase.Proveedor);
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
        
        public DataTable ListarCostosProductos(DateTime Fecha)
        {
            string q = $@"select p.ProductoID, p.Descripcion, drec.RecepcionID, drec.FechaRecepcion 'FechaRecepcion', 
            p.Costo 'CostoActual', p.Costo + (p.Costo * Utilidad)/100 'Precio Venta Actual',
            drec.CostoUnitario 'NuevoCosto', drec.CostoUnitario + (drec.CostoUnitario * Utilidad)/100 'NuevoPrecioVenta',
            c.Descripcion 'Categoria', prov.RazonSocial 'Proveedor'   from DetallesRecepciones drec 
            inner join Productos p on drec.ProductoID = p.ProductoID 
            inner join Categorias c on c.CategoriaID = p.CategoriaID
            inner join Proveedores prov on prov.ProveedorID = p.ProveedorID
			inner join Recepciones r on r.RecepcionID = drec.RecepcionID
            where CONVERT(DATE, drec.FechaRecepcion) = CONVERT(DATE, '{Fecha.ToString("yyyyMMdd")}')
			and r.EstadoID = 4;";

            SqlCommand cmd = new SqlCommand(q);
            Base cn = new Base();
            return cn.Consultar(cmd);
        }

        public void ActualizarCostos(DateTime Fecha)
        {
            Base cn = new Base();

            string q = $@"SELECT distinct p.ProductoID from DetallesRecepciones dr
			inner join Productos p on dr.ProductoID = p.ProductoID
			inner join Recepciones r on r.RecepcionID = dr.RecepcionID
			inner join Pedidos pe on pe.PedidoID = r.PedidoID 
			WHERE  CONVERT(DATE, dr.FechaRecepcion) = CONVERT(DATE, '{Fecha.ToString("yyyyMMdd")}')
						and r.EstadoID = 4";

            SqlCommand cmd = new SqlCommand(q);

            DataTable dt = cn.Consultar(cmd);

            if (dt.Rows.Count == 0) return;

            foreach(DataRow dr in dt.Rows)
            {
                int ID = Convert.ToInt32(dr["ProductoID"]);

                q += $@"UPDATE Productos 
                        set Costo = (
            SELECT dr.CostoUnitario from DetallesRecepciones dr
			inner join Productos p on dr.ProductoID = p.ProductoID
			inner join Recepciones r on r.RecepcionID = dr.RecepcionID
			inner join Pedidos pe on pe.PedidoID = r.PedidoID 
                        WHERE  CONVERT(DATE, dr.FechaRecepcion) = CONVERT(DATE, '{Fecha.ToString("yyyyMMdd")}')
						and p.ProductoID = {ID} and r.EstadoID = 4 ) --Estado Recibido. 
						WHERE ProductoID = {ID}";
            }

           
            q += $@"--Actualizar Estados recepciones.
            UPDATE Recepciones 
            SET EstadoID = 5 --Estado Controlado
            where 
            RecepcionID in (SELECT r.recepcionID from DetallesRecepciones dr
			            inner join Productos p on dr.ProductoID = p.ProductoID
			            inner join Recepciones r on r.RecepcionID = dr.RecepcionID
			            inner join Pedidos pe on pe.PedidoID = r.PedidoID 
                                    WHERE  CONVERT(DATE, dr.FechaRecepcion) = CONVERT(DATE, '{Fecha.ToString("yyyyMMdd")}')
						            and r.EstadoID = 4 );--Estado Recibido.

            --Actualizar Estados pedidos.
            UPDATE Pedidos 
            SET PedidoEstadoID = 5 --Estado Controlado
            where PedidoID in (SELECT pe.PedidoID from DetallesRecepciones dr
			inner join Productos p on dr.ProductoID = p.ProductoID
			inner join Recepciones r on r.RecepcionID = dr.RecepcionID
			inner join Pedidos pe on pe.PedidoID = r.PedidoID 
                        WHERE  CONVERT(DATE, dr.FechaRecepcion) = CONVERT(DATE, '{Fecha.ToString("yyyyMMdd")}')
						and pe.PedidoEstadoID = 4); --Estado Recibido.";

            cmd = new SqlCommand(q);
            try
            {                
              cn.Ejecutar(cmd);               
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex.InnerException); }

            
        }
    }
}
