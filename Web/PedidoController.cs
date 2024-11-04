using Datos;
using Microsoft.AspNetCore.Mvc;
using Clase = Entidades.Pedido;

namespace Web
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PedidoController : Controller
    {
        private readonly Datos.Pedido _pedido;

        public PedidoController()

        {
            _pedido = new Pedido();
        }

        [HttpGet(Name = "ListarPedidos")]
        public ActionResult<IEnumerable<Clase>> GetAll()
        {
            return _pedido.ListarPedidos();
        }

        [HttpGet("{ID}")]
        public ActionResult<Clase> GetbyID(int ID)
        {
            var pedido = _pedido.Consultar(ID);

            if (pedido == null) return NotFound();

            return pedido;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase pedido)
        {
            _pedido.Insertar(pedido);
            return CreatedAtAction(nameof(GetbyID), new { id = pedido.PedidoID }, pedido);
        }

        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase pedido)
        {
            if (ID != pedido.PedidoID) return BadRequest();

            _pedido.Modificar(pedido);

            return NoContent();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Clase> Delete(int ID)
        {
            var pedido = _pedido.Consultar(ID);

            if (pedido == null) return NotFound();

            _pedido.Eliminar(pedido);

            return pedido;
        }

    }
}
