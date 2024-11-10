using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Sistema
{
    public class Base
    {

        string connectionString = "Data Source=HWNOTE163490\\SQLEXPRESS;Initial Catalog=Almacen;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        string connectionString2 = "Data Source=DESKTOP-KHKJ2OC;Initial Catalog=Almacen;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public SqlConnection Conectarbd = new SqlConnection();

        public Base()
        {
            //try
            //{
            //    Conectarbd.ConnectionString = connectionString2;
            //}
            //catch { }

            try
            {
                Conectarbd.ConnectionString = connectionString;
            }
            catch { }
        }

        public void Abrir()
        {
            try
            {
                Conectarbd.Open();
                Console.WriteLine("Conexion Abierta");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Conectar con la BD", ex);
            }
        }

        public void Ejecutar(SqlCommand cmd)
        {
            try
            {
                Conectarbd.Open();
                cmd.Connection = Conectarbd;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally
            {
                Conectarbd.Close();
            }
        }

        public DataTable Consultar(SqlCommand cmd)
        {
            try
            {
                Conectarbd.Open();
                cmd.Connection = Conectarbd;
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                return data;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally
            {
                Conectarbd.Close();
            }
        }

        public DataTable Consultar(string consulta)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, Conectarbd);
                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);

                return data;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally
            {
                Conectarbd.Close();
            }
        }

        public void Cerrar()
        {
            Conectarbd.Close();
            Console.WriteLine("Conexion Cerrada");
        }
    }
}

