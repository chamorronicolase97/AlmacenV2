using Datos;
using Microsoft.AspNetCore.Mvc;
using Clase = Entidades.DetallePedido;

namespace Web
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DetallePedidoController : Controller
    {
        private readonly Datos.DetallePedido _detallePedido;

        public DetallePedidoController()

        {
            _detallePedido = new DetallePedido();
        }

        [HttpGet("Listar/{PedidoID}")]
        public ActionResult<IEnumerable<Clase>> GetAll(int PedidoID)
        {
            return _detallePedido.ListarDetallePorPedido(PedidoID);
        }

        [HttpGet("{PedidoID}/{ProductoID}")]
        public ActionResult<Clase> GetbyID(int PedidoID, int ProductoID)
        {
            var pedido = _detallePedido.Consultar(PedidoID, ProductoID);

            if (pedido == null) return NotFound();

            return pedido;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase detallePedido)
        {
            _detallePedido.Insertar(detallePedido);
            return CreatedAtAction(nameof(GetbyID), null);
        }

        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase detallePedido)
        {
            if (ID != detallePedido.PedidoID) return BadRequest();

            _detallePedido.Modificar(detallePedido);

            return NoContent();
        }

        [HttpDelete("{PedidoID}/ProductoID")]
        public ActionResult<Clase> Delete(int PedidoID, int ProductoID)
        {
            var pedido = _detallePedido.Consultar( PedidoID, ProductoID);

            if (pedido == null) return NotFound();

            _detallePedido.Eliminar(pedido);

            return pedido;
        }

    }
}
