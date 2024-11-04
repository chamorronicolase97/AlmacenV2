using Entidades;
using Sistema;
using System.Data.SqlClient;
using System.Data;
using ClasePersistente = Entidades.Cliente;

namespace Datos
{
    public class Cliente : AlmacenContext
    {
        const string Tabla = "dbo.Clientes";
        public Cliente() : base() { }


        public void Insertar(ClasePersistente clase)
        {
            base.Clientes.Add(clase);
            base.SaveChanges();
        }

        public void Modificar(ClasePersistente clase)
        {
            base.Clientes.Update(clase);
            base.SaveChanges();
        }

        public void Eliminar(ClasePersistente clase)
        {
            base.Clientes.Remove(clase);
            base.SaveChanges();
        }

        public List<ClasePersistente> ListarClientes()
        {
            return base.Clientes.ToList();
        }

        public bool EsVacio()
        {
            return !base.Clientes.ToList().Any();
        }

        public ClasePersistente Consultar(int ID)
        {
            return base.Clientes.Find(ID);
        }
    }
}
