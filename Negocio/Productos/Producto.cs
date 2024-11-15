﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ClasePersistente = Entidades.Producto;

namespace Negocio
{
    public class Producto
    {
        public async static Task<bool> Agregar(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync("https://localhost:7173/api/Producto", clase);
            return response.IsSuccessStatusCode;
        }

        public async static void Modificar(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.PutAsJsonAsync<ClasePersistente>($"https://localhost:7173/api/Producto/{clase.ProductoID}", clase);
        }

        public async static void Eliminar(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"https://localhost:7173/api/Producto/{clase.ProductoID}");
        }


        public async static Task<IEnumerable<ClasePersistente>> ListarTodos()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync("https://localhost:7173/api/Producto");
            var data = JsonConvert.DeserializeObject<List<ClasePersistente>>(response);
            return data;
        }

        public async static Task<ClasePersistente> Get(int ID)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"https://localhost:7173/api/Producto/{ID}");
            var data = JsonConvert.DeserializeObject<ClasePersistente>(response);
            return data;
        }

        public async static Task<List<iProductoCosto>> ListarControlCosto(DateTime Fecha)
        {
            var response = await Conexion.Instancia.Cliente.GetAsync($"https://localhost:7173/api/Producto/ControlCostos/{Fecha.ToString("yyyy-MM-dd")}");
            if(!response.IsSuccessStatusCode) return new List<iProductoCosto>();

            string jsonData = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<iProductoCosto>>(jsonData);

            return data;
        }

        public async static Task<bool> ActualizarCostos(DateTime Fecha)
        {
            var response = await Conexion.Instancia.Cliente.PutAsync($"https://localhost:7173/api/Producto/ActualizarCosto/{Fecha.ToString("yyyy-MM-dd")}", null);

            return response.IsSuccessStatusCode;
        }

    }
}
