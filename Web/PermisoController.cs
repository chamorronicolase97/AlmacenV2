using Datos;
using Microsoft.AspNetCore.Mvc;
using Clase = Entidades.Permiso;

namespace Web
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PermisoController : Controller
    {
        private readonly Datos.Permiso _Permiso;

        public PermisoController()

        {
            _Permiso = new Permiso();
        }

        [HttpGet(Name = "ListarPermisos")]
        public ActionResult<IEnumerable<Clase>> GetAll()
        {
            return _Permiso.ListarPermisos();
        }

        [HttpGet("{ID}")]
        public ActionResult<Clase> GetbyID(int ID)
        {
            var grupo = _Permiso.Consultar(ID);

            if (grupo == null) return NotFound();

            return grupo;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase proveedor)
        {
            _Permiso.Insertar(proveedor);
            return CreatedAtAction(nameof(GetbyID), null);
        }

        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase proveedor)
        {
            if (ID != proveedor.PermisoID) return BadRequest();

            _Permiso.Modificar(proveedor);

            return NoContent();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Clase> Delete(int ID)
        {
            var grupo = _Permiso.Consultar(ID);

            if (grupo == null) return NotFound();

            _Permiso.Eliminar(grupo);

            return grupo;
        }

    }
}
