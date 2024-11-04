using Datos;
using Microsoft.AspNetCore.Mvc;
using Clase = Entidades.Producto;

namespace Web
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductoController : Controller
    {
        private readonly Datos.Producto _producto;

        public ProductoController()

        {
            _producto = new Producto();
        }

        [HttpGet(Name = "ListarProductos")]
        public ActionResult<IEnumerable<Clase>> GetAll()
        {
            return _producto.ListarProductos();
        }

        [HttpGet("{ID}")]
        public ActionResult<Clase> GetbyID(int ID)
        {
            var producto = _producto.Consultar(ID);

            if (producto == null) return NotFound();

            return producto;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase producto)
        {
            _producto.Insertar(producto);
            return CreatedAtAction(nameof(GetbyID), null);
        }

        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase producto)
        {
            if (ID != producto.ProductoID) return BadRequest();

            _producto.Modificar(producto);

            return NoContent();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Clase> Delete(int ID)
        {
            var producto = _producto.Consultar(ID);

            if (producto == null) return NotFound();

            _producto.Eliminar(producto);

            return producto;
        }
    }
}
