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
            clase.Contraseña = Encrypt.HashString(clase.Contraseña);
            base.Clientes.Add(clase);
            base.SaveChanges();
        }

        public void Modificar(ClasePersistente clase)
        {
            clase.Contraseña = Encrypt.HashString(clase.Contraseña);
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

        public ClasePersistente Ingresar(string User, string Password)
        {

            Base cn = new Base();
            string q = @$"Select * from {Tabla} where Usuario = @User
                        and Contraseña = @Password";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = User;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Encrypt.HashString(Password);

            DataTable dt = new DataTable();


            try
            {
                dt = cn.Consultar(cmd);

            }
            catch (Exception ex)
            {
                throw new Exception($"Cliente no Encontrado", ex);
            }
            if (dt.Rows.Count > 0)
            {
                int ID = (Convert.ToInt32(dt.Rows[0]["ClienteID"]));

                return Consultar(ID);
            }
            else
            {
                return null;
            }


        }
    }
}
