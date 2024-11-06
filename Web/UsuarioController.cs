using Datos;
using Entidades;
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
            _Usuario = new Datos.Usuario();
        }

        [HttpGet(Name = "ListarUsuarios")]
        public ActionResult<IEnumerable<Clase>> GetAll()
        {
            return _Usuario.ListarUsuarios();
        }

        [HttpGet("{ID}")]
        public ActionResult<Clase> GetbyID(int ID)
        {
            var usuario = _Usuario.Consultar(ID);

            if (usuario == null) return NotFound();

            return usuario;
        }

        [HttpPost("/Ingresar")]
        public ActionResult<Clase> Ingresar(iLogin login)
        {
            var usuario = _Usuario.Ingresar(login.user, login.password);

            if (usuario == null) return NotFound();

            return usuario;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase usuario)
        {
            _Usuario.Insertar(usuario);
            return CreatedAtAction(nameof(GetbyID), null);
        }

        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase usuario)
        {
            if (ID != usuario.UsuarioID) return BadRequest();

            _Usuario.Modificar(usuario);

            return NoContent();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Clase> Delete(int ID)
        {
            var usuario = _Usuario.Consultar(ID);

            if (usuario == null) return NotFound();

            _Usuario.Eliminar(usuario);

            return usuario;
        }

        [HttpGet("BuscarPorUsuario/{CodUsuario}")]
        public ActionResult<Clase> GetByUsuario(string CodUsuario)
        {
            var usuario = _Usuario.Consultar(CodUsuario);

            if (usuario == null) return NotFound();

            return usuario;
        }

    }
}
