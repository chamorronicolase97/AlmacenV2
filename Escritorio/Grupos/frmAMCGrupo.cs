
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasePersistente = Entidades.Grupo;
using ClaseNegocio = Negocio.Grupo;

namespace Escritorio
{
    public partial class frmAMCGrupo : Form
    {
        public ClasePersistente Clase { get; set; }
        protected bool _soloLectura;

        public bool Modificacion { get; set; } = false;
        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }
        public frmAMCGrupo()
        {
            InitializeComponent();

        }

        private void frmAMCCategoria_Load(object sender, EventArgs e)
        {
            if(Clase != null)
            {
                txtID.Text = Clase.GrupoID.ToString();
                txtNombre.Text = Clase.Descripcion;

                if (_soloLectura)
                {
                    txtNombre.ReadOnly = true;
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
                        Descripcion = txtNombre.Text,
                    };
                    await ClaseNegocio.Agregar(Clase);
                }
                else
                {
                    Clase.Descripcion = txtNombre.Text;

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
            if (txtNombre.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Grupo", "Debe escribir un nombre para el grupo");
                return false;
            }
            return true;
        }


    }
}
