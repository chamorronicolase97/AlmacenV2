using Azure.Core;
using Newtonsoft.Json;
using System.Net.Http.Json;
using ClasePersistente = Entidades.Grupo;
namespace Negocio
{
    public class Grupo
    {

        public async static Task<bool> Agregar(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync("https://localhost:7173/api/Grupo", clase);
            return response.IsSuccessStatusCode;
        }

        public async static void Modificar(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.PutAsJsonAsync<ClasePersistente>($"https://localhost:7173/api/Grupo/{clase.GrupoID}", clase);            
        }

        public async static void Eliminar(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"https://localhost:7173/api/Grupo/{clase.GrupoID}");            

        }


        public async static Task<IEnumerable<ClasePersistente>> ListarTodos()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync("https://localhost:7173/api/Grupo");
            var data = JsonConvert.DeserializeObject<List<ClasePersistente>>(response);
            return data;
        }

        public async static Task<ClasePersistente> Get(int ID)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"https://localhost:7173/api/Grupo/{ID}");
            var data =  JsonConvert.DeserializeObject<ClasePersistente>(response);
            return data;

        }

        public  static bool EsVacio(int ID)
        {
           return new Datos.Grupo().EsVacio(ID);
        }
    }
}