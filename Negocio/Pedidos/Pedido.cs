﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ClasePersistente = Entidades.Pedido;

namespace Negocio
{
    public class Pedido
    {
        public async static Task<bool> Agregar(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync("https://localhost:7173/api/Pedido", clase);
            return response.IsSuccessStatusCode;
        }

        public async static void Modificar(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.PutAsJsonAsync<ClasePersistente>($"https://localhost:7173/api/Pedido/{clase.PedidoID}", clase);
        }

        public async static void Eliminar(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"https://localhost:7173/api/Pedido/{clase.PedidoID}");

        }


        public async static Task<IEnumerable<ClasePersistente>> ListarTodos()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync("https://localhost:7173/api/Pedido");
            var data = JsonConvert.DeserializeObject<List<ClasePersistente>>(response);
            return data;
        }

        public async static Task<ClasePersistente> Get(int ID)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"https://localhost:7173/api/Pedido/{ID}");
            var data = JsonConvert.DeserializeObject<ClasePersistente>(response);
            return data;

        }

        public static bool TieneRecepcion(ClasePersistente clase)
        {
            //continuar
            return true;
        }
    }
}
