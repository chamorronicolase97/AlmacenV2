using Sistema;
using System.Data.SqlClient;
using System.Data;
using ClasePersistente = Entidades.Categoria;

namespace Datos
{
    public class Categoria : AlmacenContext
    {
        const string Tabla = "dbo.Categorias";
        public Categoria() : base() { }


        public void Insertar(ClasePersistente clase)
        {
            Categorias.Add(clase);
            base.SaveChanges();
        }

        public void Modificar(ClasePersistente clase)
        {
            Categorias.Update(clase);
            base.SaveChanges();
        }

        public void Eliminar(ClasePersistente clase)
        {
            Categorias.Remove(clase);
            base.SaveChanges();
        }

        public List<ClasePersistente> ListarCategorias()
        {
            return Categorias.ToList();
        }

        public bool EsVacio(int ID)
        {
            Base cn = new Base();
            string q = $@"SELECT TOP 1 * FROM dbo.Productos WHERE Categoria = @ID";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            DataTable dt = cn.Consultar(cmd);

            if (dt.Rows.Count > 0) { return false; }
            else { return true; }
        }

        public ClasePersistente Consultar(int ID)
        {
            return Categorias.Find(ID);
        }

    }
}