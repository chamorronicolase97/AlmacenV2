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

        public List<ClasePersistente> ListarGrupos()
        {
           return base.Grupos.ToList();
        }

        public bool EsVacio(int ID)
        {
            Base cn = new Base();
            string q = $@"SELECT TOP 1 * FROM dbo.Usuarios WHERE GrupoID = @ID";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            DataTable dt = cn.Consultar(cmd);

            if (dt.Rows.Count > 0) { return false; }
            else { return true; }
        }

        public ClasePersistente Consultar(int ID)
        {
            return base.Grupos.Find(ID);
        }

    }
}