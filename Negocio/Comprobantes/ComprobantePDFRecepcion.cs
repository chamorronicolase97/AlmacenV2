using System;
using System.Collections.Generic;
using System.Text;
using Clase = Entidades.Recepcion;
using Entidades;

namespace Negocio
{
    public class ComprobantePDFRecepcion : PDFGenerator
    {
        Clase _clase;
        List<Entidades.DetalleRecepcion> _detalles;

        public byte[] Bytes { get; private set; }

        public ComprobantePDFRecepcion(Clase clase, List<Entidades.DetalleRecepcion> detalles): base()
        {
            _clase = clase;
            _detalles = detalles;

            string content = GetHTML();
           Bytes = ConvertHtmlToPdf(content);
        }

        private string GetHTML()
        {
            // Calcular totales
            int totalCantidad = 0;
            decimal totalImporte = 0m;

            foreach (var detalle in _detalles)
            {
                totalCantidad += detalle.Cantidad;
                totalImporte += detalle.Cantidad * detalle.CostoUnitario;
            }

            // Generar filas de la tabla para cada detalle
            StringBuilder detallesHtml = new StringBuilder();
            foreach (var detalle in _detalles)
            {
                detallesHtml.AppendLine($@"
                    <tr>
                        <td>{detalle.Producto.ProductoID}</td>
                        <td>{detalle.Producto.Descripcion}</td>
                        <td>{detalle.Producto.CodigoDeBarra}</td>
                        <td>{detalle.Cantidad}</td>
                        <td>{detalle.CostoUnitario}</td>
                        <td>{detalle.Cantidad * detalle.CostoUnitario}</td>
                    </tr>");
            }

            // Plantilla HTML con reemplazo de variables
            string content = $@"
<!DOCTYPE html>
<html lang=""es"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Comprobante de Recepción</title>
    <style>
        body {{ font-family: Arial, sans-serif; margin: 0; padding: 20px; }}
        .container {{ max-width: 800px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; }}
        .header {{ text-align: center; }}
        h1 {{ font-size: 24px; margin-bottom: 10px; }}
        .info {{ margin-bottom: 20px; }}
        .info p {{ margin: 5px 0; }}
        table {{ width: 100%; border-collapse: collapse; margin-top: 20px; }}
        table, th, td {{ border: 1px solid #ddd; padding: 8px; text-align: center; }}
        th {{ background-color: #f2f2f2; }}
    </style>
</head>
<body>

<div class=""container"">
    <div class=""header"">
        <h1>Comprobante de Recepción</h1>
        <p>Fecha de Entrega: {_clase.FechaEntrega:dd/MM/yyyy}</p>
    </div>

    <div class=""info"">
        <p><strong>ID de Recepción:</strong> {_clase.RecepcionID}</p>
        <p><strong>ID de Pedido:</strong> {_clase.PedidoID}</p>
        <p><strong>ID de Pedido:</strong> {_clase.Pedido.Proveedor.RazonSocial}</p>
        <p><strong>Estado de la Recepción:</strong> {_clase.Estado?.Descripcion.ToString() ?? "N/A"}</p>
    </div>

    <h2>Detalles de la Recepción</h2>
    <table>
        <thead>
            <tr>
                <th>ID Producto</th>
                <th>Descripción</th>
                <th>Código de Barra</th>
                <th>Cantidad</th>
                <th>Costo Unitario</th>
                <th>Subtotal</th>
            </tr>
        </thead>
        <tbody>
            {detallesHtml}
        </tbody>
    </table>

    <div class=""footer"" style=""margin-top: 20px;"">
        <p><strong>Total de Productos Recibidos:</strong> {totalCantidad}</p>
        <p><strong>Importe Total:</strong> {totalImporte}</p>
    </div>
</div>

</body>
</html>";

            return content;
        }
    }
}
