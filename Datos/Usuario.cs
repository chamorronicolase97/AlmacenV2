using Entidades;
using Sistema;
using System.Data.SqlClient;
using System.Data;
using ClasePersistente = Entidades.Usuario;

namespace Datos
{
    public class Usuario: AlmacenContext 
    {
        const string Tabla = "dbo.Usuarios";
        public Usuario():base() { }


        public void Insertar(ClasePersistente clase)
        {                 
                base.Usuarios.Add(clase);
                base.SaveChanges();            
        }

        public void Modificar(ClasePersistente clase)
        {
            base.Usuarios.Update(clase);
            base.SaveChanges();            
        }

        public void Eliminar(ClasePersistente clase)
        {
           base.Usuarios.Remove(clase);
           base.SaveChanges();
        }

        public List<ClasePersistente> ListarUsuarios()
        {
           return base.Usuarios.ToList();
        }

        public bool EsVacio()
        {
           return !base.Usuarios.ToList().Any();
        }

        public ClasePersistente Consultar(int ID)
        {
            return base.Usuarios.Find(ID);
        }

    }
}