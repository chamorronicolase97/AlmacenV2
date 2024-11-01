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
    public partial class frmMostrarMensaje : Form
    {
        public frmMostrarMensaje()
        {
            InitializeComponent();
        }

        public static void MostrarMensaje(string Titulo, string Descripcion)
        {
            frmMostrarMensaje mensaje = new frmMostrarMensaje();
            mensaje.Text = Titulo;
            mensaje.lblDescripcion.Text = Descripcion;
            mensaje.ShowDialog();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
