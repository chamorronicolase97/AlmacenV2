using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasePersistente = Entidades.Cliente;
using ClaseNegocio = Negocio.Cliente;

namespace Escritorio
{
    public partial class frmAMCCliente : Form
    {
        public ClasePersistente Clase { get; set; }
        protected bool _soloLectura;
        private Entidades.Usuario _usuarioActual;
        const string Permiso = "ClienteAMC";

        public bool Modificacion { get; set; } = false;
        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }


        public frmAMCCliente()
        {
            InitializeComponent();
        }
        public frmAMCCliente(Entidades.Usuario usuarioActual)
        {
            InitializeComponent();
            _usuarioActual = usuarioActual;
        }

        private void frmAMCCategoria_Load(object sender, EventArgs e)
        {
            if (_usuarioActual != null)
            {
                if (!Datos.PermisoGrupo.TienePermiso(_usuarioActual.Grupo.GrupoID, Permiso))
                {
                    MessageBox.Show("No tienes permiso para acceder a esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
            }
            if (Clase != null)
            {
                txtID.Text = Clase.ClienteID.ToString();
                txtCUIT.Text = Clase.Cuit;
                txtDenominacion.Text = Clase.Denominacion;
                txtDireccion.Text = Clase.Domicilio;
                txtMail.Text = Clase.Email;
                txtTelefono.Text = Clase.Telefono;
                txtUsuario.Text = Clase.Usuario;
                txtContraseña.Text = Clase.Contraseña;

                if (_soloLectura)
                {
                    txtCUIT.ReadOnly = true;
                    txtDenominacion.ReadOnly = true;
                    txtDireccion.ReadOnly = true;
                    txtMail.ReadOnly = true;
                    txtTelefono.ReadOnly = true;
                    txtUsuario.ReadOnly = true;
                    txtContraseña.ReadOnly = true;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!_soloLectura)
            {
                if (!Validar()) return;

                if (Clase == null)
                {
                    Clase = new ClasePersistente()
                    {
                        Cuit = txtCUIT.Text,
                        Denominacion = txtDenominacion.Text,
                        Domicilio = txtDireccion.Text,
                        Email = txtMail.Text,
                        Telefono = txtTelefono.Text,
                        Empleado = chkEmpleado.Checked,
                        Preferencial = chkPreferencial.Checked,
                        Usuario = txtUsuario.Text,
                        Contraseña = txtContraseña.Text,
                    };
                    await ClaseNegocio.Agregar(Clase);
                }
                else
                {
                    Clase.Cuit = txtCUIT.Text;
                    Clase.Denominacion = txtDenominacion.Text;
                    Clase.Domicilio = txtDireccion.Text;
                    Clase.Email = txtMail.Text;
                    Clase.Telefono = txtTelefono.Text;
                    Clase.Empleado = chkEmpleado.Checked;
                    Clase.Preferencial = chkPreferencial.Checked;
                    Clase.Usuario = txtUsuario.Text;
                    Clase.Contraseña = txtContraseña.Text;

                    if (Modificacion)
                    {
                        ClaseNegocio.Modificar(Clase);
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool Validar()
        {
            if (txtCUIT.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Cliente", "El Cliente debe tener un CUIT");
                return false;
            }

            if (txtDenominacion.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Cliente", "El Cliente debe tener una Denominación");
                return false;
            }

            if (txtDireccion.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Cliente", "El Cliente debe tener una Dirección");
                return false;
            }

            if (txtMail.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Cliente", "El Cliente debe tener un Correo");
                return false;
            }

            if (txtTelefono.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Cliente", "El Cliente debe tener un Teléfono");
                return false;
            }

            return true;
        }

    }
}
