using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasePersistente = Entidades.Permiso;
using ClaseNegocio = Negocio.Permiso;
using Entidades;

namespace Escritorio
{
    public partial class frmAMCPermiso : Form
    {
        public ClasePersistente Clase { get; set; }
        protected bool _soloLectura;

        public bool Modificacion { get; set; } = false;
        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }

        public frmAMCPermiso()
        {
            InitializeComponent();

        }

        private void frmAMCPermiso_Load(object sender, EventArgs e)
        {
            if(Clase != null)
            {
                txtID.Text = Clase.PermisoID.ToString();
                txtCodPermiso.Text = Clase.CodPermiso;
                txtDescripcion.Text = Clase.Descripcion;

                if (_soloLectura)
                {
                    txtCodPermiso.ReadOnly = true;
                    txtDescripcion.ReadOnly = true;

                    btnAsignar.Enabled = false;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(!_soloLectura)
            {
                if (!Validar()) return;

                if(Clase == null)
                {
                    Clase = new Permiso()
                    {
                        CodPermiso = txtCodPermiso.Text,
                        Descripcion = txtDescripcion.Text,
                    };
                    ClaseNegocio.Agregar(Clase);
                }
                else
                {
                    Clase.CodPermiso = txtCodPermiso.Text;
                    Clase.Descripcion = txtDescripcion.Text;

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
            if (txtCodPermiso.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Permiso", "Debe escribir un NOMBRE y APELLIDO para el Permiso");
                return false;
            }

            return true;
        }


    }
}
