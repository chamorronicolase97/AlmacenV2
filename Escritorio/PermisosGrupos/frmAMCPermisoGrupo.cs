using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasePersistente = Entidades.PermisoGrupo;
using ClaseNegocio = Negocio.PermisoGrupo;
using Datos;
using Entidades;
using Negocio;

namespace Escritorio
{
    public partial class frmAMCPermisoGrupo : Form
    {
        public ClasePersistente Clase { get; set; }
        protected bool _soloLectura;

        public bool Modificacion { get; set; } = false;
        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }
        private Entidades.Permiso _permiso;
        private Entidades.Grupo _grupo;
        private Entidades.Usuario _usuarioActual;
        const string CodPermiso = "PermisoGrupoAMC";
        public frmAMCPermisoGrupo()
        {
            InitializeComponent();
        }
        public frmAMCPermisoGrupo(Entidades.Usuario usuarioActual)
        {
            InitializeComponent();
            _usuarioActual = usuarioActual;
        }

        private void frmAMCCategoria_Load(object sender, EventArgs e)
        {
            if (_usuarioActual != null)
            {
                if (!Datos.PermisoGrupo.TienePermiso(_usuarioActual.Grupo.GrupoID, CodPermiso))
                {
                    MessageBox.Show("No tienes permiso para acceder a esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
            }
            if (Clase != null)
            {
                txtID.Text = Clase.PermisoGrupoID.ToString();

                txtPermiso.Text = Clase.Permiso.CodPermiso.ToString();
                txtGrupo.Text = Clase.Grupo.Descripcion.ToString();

                _permiso = Clase.Permiso;
                _grupo = Clase.Grupo;

                if (_soloLectura)
                {
                    btnAsignarPermiso.Enabled = false;
                    btnQuitarPermiso.Enabled = false;

                    btnAsignarGrupo.Enabled = false;
                    btnQuitarGrupo.Enabled = false;
                }
            }

            txtPermiso.ReadOnly = true;
            txtGrupo.ReadOnly = true;

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
                    Clase = new Entidades.PermisoGrupo
                    {
                        Permiso = _permiso,
                        PermisoID = _permiso.PermisoID,
                        Grupo = _grupo,
                        GrupoID = _grupo.GrupoID

                    };
                    await ClaseNegocio.Agregar(Clase);
                }
                else
                {
                    Clase.Permiso = _permiso;
                    Clase.PermisoID = _permiso.PermisoID;
                    Clase.Grupo = _grupo;
                    Clase.GrupoID = _grupo.GrupoID;

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

            if (_permiso == null)
            {
                frmMostrarMensaje.MostrarMensaje("Permiso", "Debe seleccionar un Permiso");
                return false;
            }

            if (_grupo == null)
            {
                frmMostrarMensaje.MostrarMensaje("Grupo", "Debe seleccionar un Grupo");
                return false;
            }

            return true;
        }

        private void HabilitarControles()
        {
            if (_permiso != null) { txtPermiso.Text = _permiso.CodPermiso; }
            else { txtPermiso.Text = ""; }
            if (_grupo != null) txtGrupo.Text = _grupo.Descripcion;
            else { txtGrupo.Text = ""; }
        }

        private void btnAsignarPermiso_Click(object sender, EventArgs e)
        {
            frmABMSPermisos f = new frmABMSPermisos { };
            f.ObjetoSeleccionado = _permiso;
            f.ModoSeleccion = true;
            f.ShowDialog(this);
            if (DialogResult.OK == f.DialogResult)
            {
                _permiso = f.ObjetoSeleccionado;

                HabilitarControles();
            }
        }

        private void btnConsultarPermiso_Click(object sender, EventArgs e)
        {
            if (_permiso == null) return;

            frmAMCPermiso f = new frmAMCPermiso();
            f.Clase = _permiso;
            f.SoloLectura = true;
            f.Show(this);
        }

        private void btnQuitarPermiso_Click(object sender, EventArgs e)
        {
            if (_permiso == null) return;

            _permiso = null;
            HabilitarControles();
        }

        private void btnAsignarGrupo_Click(object sender, EventArgs e)
        {
            frmABMSGrupos f = new frmABMSGrupos { };
            f.ObjetoSeleccionado = _grupo;
            f.ModoSeleccion = true;
            f.ShowDialog(this);
            if (DialogResult.OK == f.DialogResult)
            {
                _grupo = f.ObjetoSeleccionado;

                HabilitarControles();
            }
        }

        private void btnConsultarGrupo_Click(object sender, EventArgs e)
        {
            if (_grupo == null) return;

            frmAMCGrupo f = new frmAMCGrupo();
            f.Clase = _grupo;
            f.SoloLectura = true;
            f.Show(this);
        }

        private void btnQuitarGrupo_Click(object sender, EventArgs e)
        {
            if (_grupo == null) return;

            _grupo = null;
            HabilitarControles();
        }
    }
}
