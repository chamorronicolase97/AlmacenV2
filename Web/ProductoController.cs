using Datos;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Clase = Entidades.Producto;

namespace Web
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductoController : Controller
    {
        private readonly Datos.Producto _producto;

        public ProductoController()

        {
            _producto = new Producto();
        }

        [HttpGet(Name = "ListarProductos")]
        public ActionResult<IEnumerable<Clase>> GetAll()
        {
            return _producto.ListarProductos();
        }

        [HttpGet("{ID}")]
        public ActionResult<Clase> GetbyID(int ID)
        {
            var producto = _producto.Consultar(ID);

            if (producto == null) return NotFound();

            return producto;
        }

        [HttpPost]
        public ActionResult<Clase> Create(Clase producto)
        {
            _producto.Insertar(producto);
            return CreatedAtAction(nameof(GetbyID), null);
        }

        [HttpPut("{ID}")]
        public ActionResult Update(int ID, Clase producto)
        {
            if (ID != producto.ProductoID) return BadRequest();

            _producto.Modificar(producto);

            return NoContent();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Clase> Delete(int ID)
        {
            var producto = _producto.Consultar(ID);

            if (producto == null) return NotFound();

            _producto.Eliminar(producto);

            return producto;
        }

        [HttpGet("ControlCostos/{Fecha}")]
        public ActionResult<IEnumerable<Dictionary<string, object>>> ControlCosto(DateTime Fecha)
        {
            DataTable dt = _producto.ListarCostosProductos(Fecha);

            if (dt.Rows.Count == 0) return NotFound();

            // Convertir cualquier valor `{}` en `null`
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    if (row[col] is string strValue && strValue == "{}")
                    {
                        row[col] = DBNull.Value;
                    }
                }
            }

            // Convertir el DataTable en un diccionario para el JSON
            var data = dt.AsEnumerable()
                         .Select(row => dt.Columns.Cast<DataColumn>()
                             .ToDictionary(col => col.ColumnName, col => row[col] == DBNull.Value ? null : row[col]));

            return Ok(data);
        }


        [HttpPut("ActualizarCosto/{Fecha}")]
        public ActionResult ActualizarCosto(DateTime Fecha)
        {

            _producto.ActualizarCostos(Fecha);

            return Ok();
        }

    }
}
