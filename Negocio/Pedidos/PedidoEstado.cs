using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasePersistente = Entidades.PedidoEstado;

namespace Negocio
{
    public class PedidoEstado
    {
        public static ClasePersistente EnEdicion => new Datos.PedidoEstado().Consultar(1);
        public static ClasePersistente Confirmado => new Datos.PedidoEstado().Consultar(2);
        public static ClasePersistente Cancelado => new Datos.PedidoEstado().Consultar(3);

    }
}
