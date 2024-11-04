using Datos;
using Microsoft.AspNetCore.Mvc;
using Clase = Entidades.Usuario;

namespace Web
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsuarioController : Controller
    {
        private readonly Datos.Usuario _Usuario;

        public UsuarioController()

        {
            _Usuario = new Usuario();
        }

        [HttpGet(Name = "ListarUsuarios")]
        public ActionResult<IEnumerable<Clase>> GetAll()
        {
            return _Usuario.ListarUsuarios();
        }

        [HttpGet("{ID}")]
        public ActionResult<Clase> GetbyID(int ID)
        {
            var grupo = _Usuario.Consultar(ID);

            if (grupo == null) return NotFound();

            return grupo;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase proveedor)
        {
            _Usuario.Insertar(proveedor);
            return CreatedAtAction(nameof(GetbyID), null);
        }

        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase proveedor)
        {
            if (ID != proveedor.UsuarioID) return BadRequest();

            _Usuario.Modificar(proveedor);

            return NoContent();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Clase> Delete(int ID)
        {
            var grupo = _Usuario.Consultar(ID);

            if (grupo == null) return NotFound();

            _Usuario.Eliminar(grupo);

            return grupo;
        }

    }
}
