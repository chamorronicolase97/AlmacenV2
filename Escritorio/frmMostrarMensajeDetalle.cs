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
    public partial class frmMostrarMensajeDetalle : Form
    {
        public frmMostrarMensajeDetalle()
        {
            InitializeComponent();
        }

        public static void MostrarMensaje(string Titulo, string Descripcion, string Detalle)
        {
            frmMostrarMensajeDetalle mensaje = new frmMostrarMensajeDetalle();
            mensaje.Text = Titulo;
            mensaje.lblDescripcion.Text = Descripcion;
            mensaje.txtDetalle.Text = Detalle;
            mensaje.ShowDialog();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
