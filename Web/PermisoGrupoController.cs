using Datos;
using Microsoft.AspNetCore.Mvc;
using Clase = Entidades.PermisoGrupo;

namespace Web
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PermisoGrupoController : Controller
    {
        private readonly Datos.PermisoGrupo _PermisoGrupo;

        public PermisoGrupoController()

        {
            _PermisoGrupo = new PermisoGrupo();
        }

        [HttpGet(Name = "ListarPermisosGrupos")]
        public ActionResult<IEnumerable<Clase>> GetAll()
        {
            return _PermisoGrupo.ListarPermisosGrupos();
        }

        [HttpGet("{ID}")]
        public ActionResult<Clase> GetbyID(int ID)
        {
            var PermisoGrupo = _PermisoGrupo.Consultar(ID);

            if (PermisoGrupo == null) return NotFound();

            return PermisoGrupo;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase PermisoGrupo)
        {
            _PermisoGrupo.Insertar(PermisoGrupo);
            return CreatedAtAction(nameof(GetbyID), new { id = PermisoGrupo.PermisoGrupoID }, PermisoGrupo);
        }

        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase PermisoGrupo)
        {
            if (ID != PermisoGrupo.PermisoGrupoID) return BadRequest();

            _PermisoGrupo.Modificar(PermisoGrupo);

            return NoContent();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Clase> Delete(int ID)
        {
            var PermisoGrupo = _PermisoGrupo.Consultar(ID);

            if (PermisoGrupo == null) return NotFound();

            _PermisoGrupo.Eliminar(PermisoGrupo);

            return PermisoGrupo;
        }

    }
}
