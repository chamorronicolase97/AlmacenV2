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
        private Entidades.Usuario _usuarioActual;
        const string Permiso = "PermisoAMC";

        public bool Modificacion { get; set; } = false;
        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }

        public frmAMCPermiso()
        {
            InitializeComponent();
        }
        public frmAMCPermiso(Entidades.Usuario usuarioActual)
        {
            InitializeComponent();
            _usuarioActual = usuarioActual;
        }

        private void frmAMCPermiso_Load(object sender, EventArgs e)
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
                txtID.Text = Clase.PermisoID.ToString();
                txtCodPermiso.Text = Clase.CodPermiso.Trim();
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
                        CodPermiso = txtCodPermiso.Text.Trim(),
                        Descripcion = txtDescripcion.Text,
                    };
                    ClaseNegocio.Agregar(Clase);
                }
                else
                {
                    Clase.CodPermiso = txtCodPermiso.Text.Trim();
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
