using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasePersistente = Entidades.Usuario;
using ClaseNegocio = Negocio.Usuario;
using Entidades;

namespace Escritorio
{
    public partial class frmAMCUsuario : Form
    {
        public ClasePersistente Clase { get; set; }
        protected bool _soloLectura;
        private Grupo? _grupo;
        private Entidades.Usuario _usuarioActual;
        const string Permiso = "UsuarioAMC";

        public bool Modificacion { get; set; } = false;
        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }
        public frmAMCUsuario()
        {
            InitializeComponent();
        }
        public frmAMCUsuario(Entidades.Usuario usuarioActual)
        {
            InitializeComponent();
            _usuarioActual = usuarioActual;
        }

        private void frmAMCUsuario_Load(object sender, EventArgs e)
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
                txtID.Text = Clase.UsuarioID.ToString();
                txtNomApe.Text = Clase.NombreApellido;
                txtUsuario.Text = Clase.CodUsuario;
                txtContraseña.Text = Clase.Contraseña;
                txtGrupo.Text = Clase.Grupo.Descripcion.ToString();

                if (SoloLectura)
                {
                    txtNomApe.ReadOnly = true;
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
            if (!SoloLectura)
            {
                if (!Validar()) return;

                if (Clase == null)
                {
                    Clase = new Usuario() 
                    {
                        NombreApellido = txtNomApe.Text,
                        CodUsuario = txtUsuario.Text,
                        Contraseña = txtContraseña.Text,
                        Grupo = _grupo,
                    };
                    ClaseNegocio.Agregar(Clase);
                }
                else
                {
                    Clase.NombreApellido = txtNomApe.Text;
                    Clase.CodUsuario = txtUsuario.Text;
                    Clase.Contraseña = txtContraseña.Text;
                    Clase.Grupo = _grupo;

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
            if (txtNomApe.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Usuario", "Debe escribir un NOMBRE y APELLIDO para el Usuario");
                return false;
            }

            List<string> nombre = txtNomApe.Text.Split(" ").ToList();
            if (nombre.Count < 2)
            {
                frmMostrarMensaje.MostrarMensaje("Usuario", "Debe escribir un NOMBRE y APELLIDO para el Usuario");
                return false;
            }

            if (txtContraseña.Text.Length == 0)
            {
                frmMostrarMensaje.MostrarMensaje("Usuario", "Debe escribir una contraseña para el Usuario");
                return false;
            }

            if (_grupo == null)
            {
                frmMostrarMensaje.MostrarMensaje("Usuario", "Debe seleccionar un grupo");
                return false;
            }


            return true;
        }

        private void HabilitarControles()
        {
            if (_grupo != null) { txtGrupo.Text = _grupo.Descripcion; }
            else { txtGrupo.Text = ""; }
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

            frmAMCGrupo f = new frmAMCGrupo
            {
                Clase = _grupo,
                SoloLectura = true
            };
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
