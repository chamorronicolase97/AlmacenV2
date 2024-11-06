using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class frmCargando : Form
    {
        public frmCargando()
        {
            InitializeComponent();
        }

        public async Task CargarAsync(Task tareaDeCarga)
        {
            tmr.Enabled = true; // Opcional: Inicia el temporizador si deseas mostrar una animación de carga.

            // Espera la tarea de carga asíncrona
            await tareaDeCarga;

            // Una vez completada la tarea, cierra el formulario de carga
            this.Close();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            if (pbrCargando.Value < 100)
            {
                pbrCargando.Value++;
            }
            if (pbrCargando.Value == 100)
            {
                tmr.Enabled = false;
            }
        }      
    }
}
