using Datos;
using Microsoft.AspNetCore.Mvc;
using Clase = Entidades.DetalleRecepcion;

namespace Web
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DetalleRecepcionController : Controller
    {
        private readonly Datos.DetalleRecepcion _detalleRecepcion;

        public DetalleRecepcionController()

        {
            _detalleRecepcion = new DetalleRecepcion();
        }

        [HttpGet("Listar/{RecepcionID}")]
        public ActionResult<IEnumerable<Clase>> GetAll(int RecepcionID)
        {
            return _detalleRecepcion.ListarDetallePorRecepcion(RecepcionID);
        }

        [HttpGet("{RecepcionID}/{ProductoID}")]
        public ActionResult<Clase> GetbyID(int RecepcionID, int ProductoID)
        {
            var pedido = _detalleRecepcion.Consultar(RecepcionID, ProductoID);

            if (pedido == null) return NotFound();

            return pedido;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase detalleRecepcion)
        {
            _detalleRecepcion.Insertar(detalleRecepcion);
            return CreatedAtAction(nameof(GetbyID), null);
        }

        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase detalleRecepcion)
        {
            if (ID != detalleRecepcion.RecepcionID) return BadRequest();

            _detalleRecepcion.Modificar(detalleRecepcion);

            return NoContent();
        }

        [HttpDelete("{PedidoID}/ProductoID")]
        public ActionResult<Clase> Delete(int RecepcionID, int ProductoID)
        {
            var pedido = _detalleRecepcion.Consultar(RecepcionID, ProductoID);

            if (pedido == null) return NotFound();

            _detalleRecepcion.Eliminar(pedido);

            return pedido;
        }

    }
}
