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
            var grupo = _producto.Consultar(ID);

            if (grupo == null) return NotFound();

            return grupo;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase proveedor)
        {
            _producto.Insertar(proveedor);
            return CreatedAtAction(nameof(GetbyID), null);
        }

        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase proveedor)
        {
            if (ID != proveedor.ProductoID) return BadRequest();

            _producto.Modificar(proveedor);

            return NoContent();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Clase> Delete(int ID)
        {
            var grupo = _producto.Consultar(ID);

            if (grupo == null) return NotFound();

            _producto.Eliminar(grupo);

            return grupo;
        }

    }
}
