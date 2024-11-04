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
        static ClasePersistente EnEdicion => new Datos.PedidoEstado().Consultar(1);
        static ClasePersistente Confirmado => new Datos.PedidoEstado().Consultar(2);
        static ClasePersistente Cancelado => new Datos.PedidoEstado().Consultar(3);

    }
}
