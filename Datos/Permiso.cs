using Entidades;
using Sistema;
using System.Data.SqlClient;
using System.Data;
using ClasePersistente = Entidades.Permiso;

namespace Datos
{
    public class Permiso: AlmacenContext 
    {
        const string Tabla = "dbo.Permisos";
        public Permiso():base() { }


        public void Insertar(ClasePersistente clase)
        {                 
                base.Permisos.Add(clase);
                base.SaveChanges();            
        }

        public void Modificar(ClasePersistente clase)
        {
            base.Permisos.Update(clase);
            base.SaveChanges();            
        }

        public void Eliminar(ClasePersistente clase)
        {
           base.Permisos.Remove(clase);
           base.SaveChanges();
        }

        public List<ClasePersistente> ListarPermisos()
        {
           return base.Permisos.ToList();
        }

        public bool EsVacio()
        {
           return !base.Permisos.ToList().Any();
        }

        public ClasePersistente Consultar(int ID)
        {
            return base.Permisos.Find(ID);
        }

    }
}