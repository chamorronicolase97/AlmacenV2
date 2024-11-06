using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase = Entidades.Usuario;

namespace Escritorio
{
    public partial class frmLogin : Form
    {
        public Clase? Usuario { get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            CargarGrillaConCargando();

        }
        private bool ValidarAntesDeAceptar()
        {
            if (txtUsuario.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un usuario.", "Iniciar Sesión", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una contraseña.", "Iniciar Sesión", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async Task Ingresar()
        {
            if (!ValidarAntesDeAceptar()) return;

            iLogin login = new iLogin();
            login.user = txtUsuario.Text;
            login.password = txtPassword.Text;

            Usuario = await Negocio.Usuario.Ingresar(login);

            if (Usuario != null)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario No encontrado.", "Iniciar Sesión", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }
        }

        private async void CargarGrillaConCargando()
        {
            using (var frmCargando = new frmCargando())
            {
                frmCargando.Show(); // Muestra el formulario de carga

                // Espera a que CargarGrilla complete la carga de datos
                await Ingresar();

                // El formulario `frmCargando` se cerrará automáticamente al salir del bloque `using`
            }
        }

    }
}
