using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Negocio
{
    public class ComprobantePDFPedido : PDFGenerator
    {
        private Entidades.Pedido _pedido;
        private List<Entidades.DetallePedido> _detalles;

        public byte[] Bytes { get; private set; }
        public ComprobantePDFPedido(Entidades.Pedido pedido, List<Entidades.DetallePedido> detalles): base()
        {
            _pedido = pedido;
            _detalles = detalles;

            string content = GetHTML();

            Bytes = ConvertirHtmlAPdf(content); 
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
                        <td>$ {detalle.CostoUnitario:N0}</td>
                        <td>$ {detalle.Cantidad * detalle.CostoUnitario:N0}</td>
                    </tr>");
            }

            // Plantilla HTML con reemplazo de variables
            string content = $@"
<!DOCTYPE html>
<html lang=""es"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Comprobante de Pedido</title>
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
        <h1>Comprobante de Pedido</h1>
        <p>Fecha de Entrega: {_pedido.FechaEntrega:dd/MM/yyyy}</p>
    </div>

    <div class=""info"">
        <p><strong>ID de Pedido:</strong> {_pedido.PedidoID}</p>
        <p><strong>Proveedor:</strong> {_pedido.Proveedor.RazonSocial}</p>
        <p><strong>Estado del Pedido:</strong> {_pedido.PedidoEstado?.Descripcion.ToString() ?? "N/A"}</p>
    </div>

    <h2>Detalles del Pedido</h2>
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
        <p><strong>Total de Productos Solicitados:</strong> {totalCantidad}</p>
        <p><strong>Importe Total:</strong>$ {totalImporte:N0}</p>
    </div>
</div>

</body>
</html>";

            return content;
        }
    }
}
