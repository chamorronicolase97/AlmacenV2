﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ClasePersistente = Entidades.Recepcion;

namespace Negocio
{
    public class Recepcion
    {
        public async static Task<ClasePersistente> Agregar(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync("https://localhost:7173/api/Recepcion", clase);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al agregar el pedido: {response.ReasonPhrase}");
            }

            // Usa ReadAsStringAsync() para obtener el contenido JSON
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ClasePersistente>(content);
            return data;
        }

        public async static void Modificar(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.PutAsJsonAsync<ClasePersistente>($"https://localhost:7173/api/Recepcion/{clase.RecepcionID}", clase);
        }

        public async static void Eliminar(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"https://localhost:7173/api/Recepcion/{clase.RecepcionID}");

        }


        public async static Task<IEnumerable<ClasePersistente>> ListarTodos()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync("https://localhost:7173/api/Recepcion");
            var data = JsonConvert.DeserializeObject<List<ClasePersistente>>(response);
            return data;
        }

        public async static Task<ClasePersistente> Get(int ID)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"https://localhost:7173/api/Recepcion/{ID}");
            var data = JsonConvert.DeserializeObject<ClasePersistente>(response);
            return data;

        }

        public async static Task<bool> TieneRecepcion(ClasePersistente clase)
        {
            var response = await Conexion.Instancia.Cliente.GetAsync($"https://localhost:7173//api/Recepcion/GetByPedidoID/{clase.PedidoID}");

            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
            else
            {

            return false;
            }
        }

        public static async Task CrearComprobanteAsync(ClasePersistente clase)
        {
            IEnumerable<Entidades.DetalleRecepcion> listado = await Negocio.DetalleRecepcion.ListarTodos(clase.RecepcionID);

            var PDF = new ComprobantePDFRecepcion(clase, listado.ToList());

            Utilidades.VerPDFTemporal($"Recepcion_{clase.RecepcionID}", PDF.Bytes);
        }

    }
}


