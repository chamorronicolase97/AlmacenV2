using Azure.Core;
using Entidades;
using Newtonsoft.Json;
using System.Net.Http.Json;
using ClasePersistente = Entidades.Usuario;
namespace Negocio
{
    public class Usuario
    {

        public async static Task<bool> Agregar(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync("https://localhost:7173/api/Usuario", clase);
            return response.IsSuccessStatusCode;
        }

        public async static void Modificar(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.PutAsJsonAsync<ClasePersistente>($"https://localhost:7173/api/Usuario/{clase.UsuarioID}", clase);
        }

        public async static void Eliminar(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"https://localhost:7173/api/Usuario/{clase.UsuarioID}");

        }


        public async static Task<IEnumerable<ClasePersistente>> ListarTodos()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync("https://localhost:7173/api/Usuario");
            var data = JsonConvert.DeserializeObject<List<ClasePersistente>>(response);
            return data;
        }

        public async static Task<ClasePersistente> Get(int ID)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"https://localhost:7173/api/Usuario/{ID}");
            var data = JsonConvert.DeserializeObject<ClasePersistente>(response);
            return data;

        }

        public async static Task<ClasePersistente> Ingresar(iLogin login)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync($"https://localhost:7173/Ingresar", login);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            // Usa ReadAsStringAsync() para obtener el contenido JSON
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ClasePersistente>(content);
            return data;

        }

        public async static Task<bool> ExisteUsuario(string CodUsuario)
        {
            var response = Conexion.Instancia.Cliente.GetAsync($"https://localhost:7173/api/BuscarPorUsuario/{CodUsuario}");

            if (response.Result.StatusCode == System.Net.HttpStatusCode.NotFound) return true;

            return false;
           
        }

        public static bool EsVacio(int ID)
        {
            return new Datos.Usuario().EsVacio();
        }
    }
}