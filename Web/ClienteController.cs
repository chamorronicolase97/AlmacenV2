using Datos;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Clase = Entidades.Cliente;

namespace Web
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClienteController : Controller
    {
        private readonly Datos.Cliente _Cliente;

        public ClienteController()

        {
            _Cliente = new Datos.Cliente();
        }

        [HttpGet(Name = "ListarClientes")]
        public ActionResult<IEnumerable<Clase>> GetAll()
        {
            return _Cliente.ListarClientes();
        }

        [HttpGet("{ID}")]
        public ActionResult<Clase> GetbyID(int ID)
        {
            var Cliente = _Cliente.Consultar(ID);

            if (Cliente == null) return NotFound();

            return Cliente;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase Cliente)
        {
            _Cliente.Insertar(Cliente);
            return CreatedAtAction(nameof(GetbyID), null);
        }

        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase Cliente)
        {
            if (ID != Cliente.ClienteID) return BadRequest();

            _Cliente.Modificar(Cliente);

            return NoContent();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Clase> Delete(int ID)
        {
            var Cliente = _Cliente.Consultar(ID);

            if (Cliente == null) return NotFound();

            _Cliente.Eliminar(Cliente);

            return Cliente;
        }

        [HttpPost("/IngresarCliente")]
        public ActionResult<Clase> Ingresar(iLogin login)
        {
            var usuario = _Cliente.Ingresar(login.user, login.password);

            if (usuario == null) return NotFound();

            return usuario;
        }

    }
}
