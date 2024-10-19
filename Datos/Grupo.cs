using Entidades;
using Sistema;
using System.Data.SqlClient;
using System.Data;
using ClasePersistente = Entidades.Grupo;

namespace Datos
{
    public class Grupo: AlmacenContext 
    {
        const string Tabla = "dbo.grupos";
        public Grupo():base() { }


        public void Insertar(ClasePersistente clase)
        {                 
                base.Grupos.Add(clase);
                base.SaveChanges();            
        }

        public void Modificar(ClasePersistente clase)
        {
            base.Grupos.Update(clase);
            base.SaveChanges();            
        }

        public void Eliminar(ClasePersistente clase)
        {
           base.Grupos.Remove(clase);
           base.SaveChanges();
        }

        public List<ClasePersistente> Listargrupos()
        {
           return base.Grupos.ToList();
        }

        public bool EsVacio()
        {
           return !base.Grupos.ToList().Any();
        }

        public ClasePersistente Consultar(int ID)
        {
            return base.Grupos.Find(ID);
        }

    }
}