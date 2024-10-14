using Entidades;
using Sistema;
using System.Data.SqlClient;
using System.Data;
using ClasePersistente = Entidades.Categoria;

namespace Datos
{
    public class Categoria: AlmacenContext 
    {
        const string Tabla = "dbo.Categorias";
        public Categoria():base() { }


        public void Insertar(ClasePersistente clase)
        {                 
                base.Categorias.Add(clase);
                base.SaveChanges();            
        }

        public void Modificar(ClasePersistente clase)
        {
            base.Categorias.Update(clase);
            base.SaveChanges();            
        }

        public void Eliminar(ClasePersistente clase)
        {
           base.Categorias.Remove(clase);
           base.SaveChanges();
        }

        public List<ClasePersistente> ListarCategorias()
        {
           return base.Categorias.ToList();
        }

        public bool EsVacia()
        {
           return !base.Categorias.ToList().Any();
        }

        public ClasePersistente Consultar(int ID)
        {
            return base.Categorias.Find(ID);
        }

    }
}