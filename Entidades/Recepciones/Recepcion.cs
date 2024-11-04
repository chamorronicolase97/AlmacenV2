using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Recepcion
    {
        private int _recepcionId;
        private Pedido _pedido;
        private DateTime _fechaEntrega;
        private PedidoEstado? _estado;

        #region Constantes
        public const string NombreClase = "Recepcion";
        #endregion

        #region Propiedades
        public int RecepcionID { get { return _recepcionId; } set { _recepcionId = value; } }
        public int PedidoID { get; set; }
        public Pedido Pedido { get { return _pedido; } set { _pedido = value; } }
        public DateTime FechaEntrega { get { return _fechaEntrega; } set { _fechaEntrega = value; } }
        public int? EstadoID { get; set; }
        public PedidoEstado? Estado { get { return _estado; } set { _estado = value; } }
        #endregion

        public Recepcion() { }
    }
}
