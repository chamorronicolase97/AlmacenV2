using Datos;
using Microsoft.AspNetCore.Mvc;
using Clase = Entidades.Categoria;

namespace Web
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoriaController : Controller
    {
        private readonly Datos.Categoria _categoria;

        public CategoriaController()

        {
            _categoria = new Categoria();
        }

        [HttpGet(Name = "ListarCategorias")]
        public ActionResult<IEnumerable<Clase>> GetAll()
        {
            return _categoria.ListarCategorias();
        }

        [HttpGet("{ID}")]
        public ActionResult<Clase> GetbyID(int ID)
        {
            var grupo = _categoria.Consultar(ID);

            if (grupo == null) return NotFound();

            return grupo;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase proveedor)
        {
            _categoria.Insertar(proveedor);
            return CreatedAtAction(nameof(GetbyID), null);
        }

        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase proveedor)
        {
            if (ID != proveedor.CategoriaID) return BadRequest();

            _categoria.Modificar(proveedor);

            return NoContent();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Clase> Delete(int ID)
        {
            var grupo = _categoria.Consultar(ID);

            if (grupo == null) return NotFound();

            _categoria.Eliminar(grupo);

            return grupo;
        }

    }
}
