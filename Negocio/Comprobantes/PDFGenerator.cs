using System.Diagnostics;
using System.IO;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

public class PDFGenerator
{

    public byte[] ConvertirHtmlAPdf(string htmlContent)
    {
        // Crear el documento PDF
        using (PdfSharpCore.Pdf.PdfDocument pdf = PdfGenerator.GeneratePdf(htmlContent, PdfSharpCore.PageSize.A4))
        {
            // Convertir el documento PDF a byte[] usando un MemoryStream
            using (MemoryStream stream = new MemoryStream())
            {
                pdf.Save(stream, false); // Guarda el PDF en el MemoryStream
                return stream.ToArray(); // Retorna el contenido del MemoryStream como byte[]
            }
        }
    }

}
