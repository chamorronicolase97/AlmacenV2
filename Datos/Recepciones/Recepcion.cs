﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasePersistente = Entidades.Recepcion;

namespace Datos
{
    public class Recepcion : AlmacenContext
    {
        const string Tabla = "dbo.Recepcion";
        public Recepcion() : base() { }

        public void Insertar(ClasePersistente clase)
        {
            try
            {
                base.Pedidos.Attach(clase.Pedido);
                base.PedidosEstados.Attach(clase.Estado);
                base.Recepciones.Add(clase);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la recepcion: " + ex.Message);
            }
        }

        public void Modificar(ClasePersistente clase)
        {
            // Asegúrate de que las entidades que ya existen se asignen directamente sin usar Attach.
            var pedidoExistente = base.Pedidos.Find(clase.Pedido.PedidoID); // Si ya existe, se recupera
            if (pedidoExistente != null)
            {
                clase.Pedido = pedidoExistente; // Se asigna la instancia existente al objeto
            }

            var estadoExistente = base.PedidosEstados.Find(clase.Estado.PedidoEstadoID); // Si ya existe, se recupera
            if (estadoExistente != null)
            {
                clase.Estado = estadoExistente; // Se asigna la instancia existente al objeto
            }

            base.Recepciones.Update(clase);
            base.SaveChanges();
        }


        public void Eliminar(ClasePersistente clase)
        {
            base.Pedidos.Attach(clase.Pedido);
            base.PedidosEstados.Attach(clase.Estado);
            base.Recepciones.Remove(clase);
            base.SaveChanges();
        }

        public List<ClasePersistente> ListarRecepciones()
        {
            try
            {
                return base.Recepciones.Include(u => u.Estado).Include(u => u.Pedido).ThenInclude(p => p.Proveedor).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ClasePersistente Consultar(int ID)
        {
            return base.Recepciones.Include(u => u.Estado).Include(u => u.Pedido).ThenInclude(p => p.Proveedor).FirstOrDefault(u => u.RecepcionID == ID);
        }

        public ClasePersistente ConsultarPorPedido(int PedidoID)
        {
            return  base.Recepciones.Include(u => u.Estado).Include(u => u.Pedido).ThenInclude(p => p.Proveedor).FirstOrDefault(u => u.PedidoID == PedidoID);          
        }
    }
}

