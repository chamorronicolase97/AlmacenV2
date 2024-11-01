using Datos;
using Microsoft.AspNetCore.Mvc;
using Clase = Entidades.Grupo;

namespace Web
{
    [ApiController]
    [Route("api/[Controller]")]
    public class GrupoController : Controller
    {
        private readonly Datos.Grupo _grupo;

        public GrupoController()

        {
            _grupo = new Grupo();
        }

        [HttpGet(Name = "ListarGrupos")]
        public ActionResult<IEnumerable<Clase>> GetAll()
        {
            return _grupo.ListarGrupos();
        }

        [HttpGet("{ID}")]
        public ActionResult<Clase> GetbyID(int ID)
        {
            var grupo = _grupo.Consultar(ID);

            if (grupo == null) return NotFound();

            return grupo;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase grupo)
        {
            _grupo.Insertar(grupo);
            return CreatedAtAction(nameof(GetbyID), null);
        }

        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase grupo)
        {
            if (ID != grupo.GrupoID) return BadRequest();

            _grupo.Modificar(grupo);

            return NoContent();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Clase> Delete(int ID)
        {
            var grupo = _grupo.Consultar(ID);

            if (grupo == null) return NotFound();

            _grupo.Eliminar(grupo);

            return grupo;
        }

    }
}
