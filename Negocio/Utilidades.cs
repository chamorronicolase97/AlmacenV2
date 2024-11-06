using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Utilidades
    {
        /// <summary>
        /// Guarda un archivo PDF en la carpeta temporal y despues inicia el lector de PDF por defecto del sistema.
        /// </summary>
        /// <remarks>El nombre del archivo tiene que tener la extension .pdf</remarks>
        public static void VerPDFTemporal(string NombreArchivo, byte[] Contenido)
        {
            string filename = Path.Combine(Path.GetTempPath(), NombreArchivo);
            File.WriteAllBytes(filename, Contenido);
            new Process { StartInfo = new ProcessStartInfo(filename) { UseShellExecute = true } }.Start();
        }
    }
}
