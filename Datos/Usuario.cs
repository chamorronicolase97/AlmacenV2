using Entidades;
using Sistema;
using System.Data.SqlClient;
using System.Data;
using ClasePersistente = Entidades.Usuario;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class Usuario: AlmacenContext 
    {
        const string Tabla = "dbo.Usuarios";
        public Usuario():base() { }


        public void Insertar(ClasePersistente clase)
        {
                clase.Contraseña = Encrypt.HashString(clase.Contraseña);
                base.Grupos.Attach(clase.Grupo);
                base.Usuarios.Add(clase);
                base.SaveChanges();            
        }

        public void Modificar(ClasePersistente clase)
        {
            clase.Contraseña = Encrypt.HashString(clase.Contraseña);
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
            return base.Usuarios.Include(u => u.Grupo).FirstOrDefault(x => x.UsuarioID == ID);
        }

        public ClasePersistente Consultar(string CodUusario)
        {
            return base.Usuarios.Include(u => u.Grupo).FirstOrDefault(x => x.CodUsuario == CodUusario);
        }

        public ClasePersistente Ingresar(string User, string Password)
        {
           
                Base cn = new Base();
                string q = @$"Select * from {Tabla} where CodUsuario = @User
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
                    throw new Exception($"Usuario no Encontrado", ex);
                }
                if (dt.Rows.Count > 0)
                {
                   int ID = (Convert.ToInt32(dt.Rows[0]["UsuarioID"]));

                    return Consultar(ID);
                }
                else
                {
                    return null;
                }

            
        }

    }
}