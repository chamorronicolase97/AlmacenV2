using Entidades;
using Sistema;
using System.Data.SqlClient;
using System.Data;
using ClasePersistente = Entidades.PedidoEstado;

namespace Datos
{
    public class PedidoEstado: AlmacenContext 
    {
        const string Tabla = "dbo.PedidosEstado";
        public PedidoEstado():base() { }


        public void Insertar(ClasePersistente clase)
        {                 
                base.PedidosEstados.Add(clase);
                base.SaveChanges();            
        }

        public void Modificar(ClasePersistente clase)
        {
            base.PedidosEstados.Update(clase);
            base.SaveChanges();            
        }

        public void Eliminar(ClasePersistente clase)
        {
           base.PedidosEstados.Remove(clase);
           base.SaveChanges();
        }

        public List<ClasePersistente> ListarPedidosEstado()
        {
           return base.PedidosEstados.ToList();
        }

        public bool EsVacio()
        {
           return !base.PedidosEstados.ToList().Any();
        }

        public ClasePersistente Consultar(int ID)
        {
            return base.PedidosEstados.Find(ID);
        }

    }
}