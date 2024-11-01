using Datos;
using Microsoft.AspNetCore.Mvc;
using Clase = Entidades.Proveedor;

namespace Web
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProveedorController : Controller
    {
        private readonly Datos.Proveedor _proveedor;

        public ProveedorController()

        {
            _proveedor = new Proveedor();
        }

        [HttpGet(Name = "ListarProveedores")]
        public ActionResult<IEnumerable<Clase>> GetAll()
        {
            return _proveedor.ListarProveedores();
        }

        [HttpGet("{ID}")]
        public ActionResult<Clase> GetbyID(int ID)
        {
            var grupo = _proveedor.Consultar(ID);

            if (grupo == null) return NotFound();

            return grupo;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase proveedor)
        {
            _proveedor.Insertar(proveedor);
            return CreatedAtAction(nameof(GetbyID), null);
        }

        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase proveedor)
        {
            if (ID != proveedor.ProveedorID) return BadRequest();

            _proveedor.Modificar(proveedor);

            return NoContent();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Clase> Delete(int ID)
        {
            var grupo = _proveedor.Consultar(ID);

            if (grupo == null) return NotFound();

            _proveedor.Eliminar(grupo);

            return grupo;
        }

    }
}
