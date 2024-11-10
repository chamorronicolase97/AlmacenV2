using Datos;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Clase = Entidades.Venta;

namespace Web
{
    [ApiController]
    [Route("api/[Controller]")]
    public class VentaController : Controller
    {
        private readonly Datos.Venta _Venta;

        public VentaController()

        {
            _Venta = new Venta();
        }

        [HttpGet(Name = "ListarVentas")]
        public ActionResult<IEnumerable<Clase>> GetAll()
        {
            return _Venta.ListarVentas();
        }

        [HttpGet("{ID}")]
        public ActionResult<Clase> GetbyID(int ID)
        {
            var Venta = _Venta.Consultar(ID);

            if (Venta == null) return NotFound();

            return Venta;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase Venta)
        {
            _Venta.Insertar(Venta);
            return CreatedAtAction(nameof(GetbyID), new { ID = Venta.VentaID }, Venta);
        }


        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase Venta)
        {
            if (ID != Venta.VentaID) return BadRequest();

            _Venta.Modificar(Venta);

            return NoContent();
        }


        [HttpDelete("{ID}")]
        public ActionResult<Clase> Delete(int ID)
        {
            var Venta = _Venta.Consultar(ID);

            if (Venta == null) return NotFound();

            _Venta.Eliminar(Venta);

            return Venta;
        }
       
    }
}
