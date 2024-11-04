using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasePersistente = Entidades.Recepcion;

namespace Datos
{
    public class Recepcion : AlmacenContext
    {
        const string Tabla = "dbo.Recepcion";
        public Recepcion() : base() { }

        public void Insertar(ClasePersistente clase)
        {
            try
            {
                base.Pedidos.Attach(clase.Pedido);
                base.PedidosEstados.Attach(clase.Estado);
                base.Recepciones.Add(clase);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la recepcion: " + ex.Message);
            }
        }

        public void Modificar(ClasePersistente clase)
        {
            base.Recepciones.Update(clase);
            base.SaveChanges();
        }

        public void Eliminar(ClasePersistente clase)
        {
            base.Pedidos.Attach(clase.Pedido);
            base.PedidosEstados.Attach(clase.Estado);
            base.Recepciones.Remove(clase);
            base.SaveChanges();
        }

        public List<ClasePersistente> ListarRecepciones()
        {
            try
            {
                return base.Recepciones.Include(u => u.Estado).Include(u => u.Pedido).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ClasePersistente Consultar(int ID)
        {
            return base.Recepciones.Include(u => u.Estado).Include(u => u.Pedido).FirstOrDefault(u => u.RecepcionID == ID);
        }
    }
}

