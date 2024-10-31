using Datos;
using Microsoft.AspNetCore.Mvc;
using Clase = Entidades.Grupo;

namespace Web
{
    [ApiController]
    [Route("api/[Controller]")]
    public class GrupoController : Controller
    {
        private readonly AlmacenContext _context;

        public GrupoController()

        {
            _context = new AlmacenContext();
        }

        [HttpGet(Name = "ListarGrupos")]
        public ActionResult<IEnumerable<Clase>> GetAll()
        {
            return _context.Grupos.ToList();
        }

        [HttpGet("{ID}")]
        public ActionResult<Clase> GetbyID(int ID)
        {
            var grupo = _context.Grupos.Find(ID);

            if (grupo == null) return NotFound();

            return grupo;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase grupo)
        {
            _context.Grupos.Add(grupo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetbyID), null);
        }

        [HttpPut("ID")]
        public ActionResult Update(int ID, Clase grupo)
        {
            if(ID != grupo.GrupoID) return BadRequest();
            

            _context.Entry(grupo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();            
            return NoContent();
        }

        [HttpDelete("DNI")]
        public ActionResult<Clase> Delete(int ID) 
        {
            var grupo = _context.Grupos.Find(ID);

            if(grupo == null) return NotFound();    

            _context.Grupos.Remove(grupo);
            _context.SaveChanges();

            return grupo;
        }

    }
}
