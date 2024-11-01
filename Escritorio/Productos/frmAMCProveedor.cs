using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasePersistente = Entidades.Proveedor;
using ClaseNegocio = Negocio.Proveedor;

namespace Escritorio
{
    public partial class frmAMCProveedor : Form
    {
        public ClasePersistente Clase { get; set; }
        protected bool _soloLectura;

        public bool Modificacion { get; set; } = false;
        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }


        public frmAMCProveedor()
        {
            InitializeComponent();

        }

        private void frmAMCCategoria_Load(object sender, EventArgs e)
        {
            if(Clase != null)
            {
                txtID.Text = Clase.ProveedorID.ToString();
                txtCUIT.Text = Clase.Cuit;
                txtRazonSocial.Text = Clase.RazonSocial;
                txtDireccion.Text = Clase.Direccion;
                txtMail.Text = Clase.Mail;
                txtTelefono.Text = Clase.Telefono;

                if (_soloLectura)
                {
                    txtCUIT.ReadOnly = true;
                    txtRazonSocial.ReadOnly = true;
                    txtDireccion.ReadOnly = true;
                    txtMail.ReadOnly = true;
                    txtTelefono.ReadOnly = true;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (_soloLectura)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (!Validar()) return;

                if (Clase == null)
                {
                    Clase = new ClasePersistente()
                    {
                        Cuit = txtCUIT.Text,
                        RazonSocial = txtRazonSocial.Text,
                        Direccion = txtDireccion.Text,
                        Mail = txtMail.Text,
                        Telefono = txtTelefono.Text,
                    };
                  await  ClaseNegocio.Agregar(Clase);
                }
                else
                {
                    Clase.Cuit = txtCUIT.Text;
                    Clase.RazonSocial = txtRazonSocial.Text;
                    Clase.Direccion = txtDireccion.Text;
                    Clase.Mail = txtMail.Text;
                    Clase.Telefono = txtTelefono.Text;

                    if (Modificacion)
                    {
                       ClaseNegocio.Modificar(Clase);
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private bool Validar()
        {
            if (txtCUIT.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Proveedor", "El proveedor debe tener un CUIT");
                return false;
            }


            return true;
        }


    }
}
