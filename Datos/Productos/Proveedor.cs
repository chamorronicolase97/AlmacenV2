using Sistema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasePersistente = Entidades.Proveedor;

namespace Datos
{
    public class Proveedor: AlmacenContext
    {
        const string Tabla = "dbo.Proveedores";

        public Proveedor():base() { }

        public void Insertar(ClasePersistente clase)
        {
            base.Proveedores.Add(clase);
            base.SaveChanges();
        }

        public void Modificar(ClasePersistente clase)
        {
            base.Proveedores.Update(clase);
            base.SaveChanges();
        }

        public void Eliminar(ClasePersistente clase)
        {
            base.Proveedores.Remove(clase);
            base.SaveChanges();
        }

        public List<ClasePersistente> ListarProveedores()
        {
            return base.Proveedores.ToList();
        }

        public bool EsVacio(int ID)
        {
            Base cn = new Base();
            string q = $@"SELECT TOP 1 * FROM dbo.Usuarios WHERE ProveedorID = @ID";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            DataTable dt = cn.Consultar(cmd);

            if (dt.Rows.Count > 0) { return false; }
            else { return true; }
        }

        public ClasePersistente Consultar(int ID)
        {
            return base.Proveedores.Find(ID);
        }


    }
}
