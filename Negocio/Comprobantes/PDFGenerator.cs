using System;
using System.IO;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace Negocio
{

    public class PDFGenerator
    {
        private readonly IConverter _converter;

        public PDFGenerator()
        {
            // Configura el conversor con el contenedor de DinkToPdf
            _converter = new SynchronizedConverter(new PdfTools());
        }

        public byte[] ConvertHtmlToPdf(string htmlContent)
        {
            // Configura las opciones para la conversión de HTML a PDF
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,
                    Out = null  // Configura Out en null para devolver el PDF como byte array
                },
                Objects =
            {
                new ObjectSettings
                {
                    HtmlContent = htmlContent,
                    WebSettings = { DefaultEncoding = "utf-8" }
                }
            }
            };

            // Convierte el HTML a PDF y devuelve el resultado como byte array
            return _converter.Convert(doc);
        }
    }
}


