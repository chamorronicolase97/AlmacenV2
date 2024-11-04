using Datos;
using Microsoft.AspNetCore.Mvc;
using Clase = Entidades.Recepcion;

namespace Web
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RecepcionController : Controller
    {
        private readonly Datos.Recepcion _recepcion;

        public RecepcionController()

        {
            _recepcion = new Recepcion();
        }

        [HttpGet(Name = "ListarRecepciones")]
        public ActionResult<IEnumerable<Clase>> GetAll()
        {
            return _recepcion.ListarRecepciones();
        }

        [HttpGet("{ID}")]
        public ActionResult<Clase> GetbyID(int ID)
        {
            var pedido = _recepcion.Consultar(ID);

            if (pedido == null) return NotFound();

            return pedido;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase recepcion)
        {
            _recepcion.Insertar(recepcion);
            return CreatedAtAction(nameof(GetbyID), null);
        }

        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase recepcion)
        {
            if (ID != recepcion.RecepcionID) return BadRequest();

            _recepcion.Modificar(recepcion);

            return NoContent();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Clase> Delete(int ID)
        {
            var pedido = _recepcion.Consultar(ID);

            if (pedido == null) return NotFound();

            _recepcion.Eliminar(pedido);

            return pedido;
        }

    }
}
