using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasePersistente = Entidades.Categoria;
using ClaseNegocio = Negocio.Categoria;

namespace Escritorio
{
    public partial class frmAMCCategoria : Form
    {
        public ClasePersistente Clase { get; set; }
        protected bool _soloLectura;
        public bool Modificacion { get; set; } = false;
        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }
        public frmAMCCategoria()
        {
            InitializeComponent();

        }

        private void frmAMCCategoria_Load(object sender, EventArgs e)
        {
            if (Clase != null)
            {
                txtID.Text = Clase.CategoriaID.ToString();
                txtNombre.Text = Clase.Descripcion;
                txtUtilidad.Text = Clase.Utilidad.ToString();

                if (_soloLectura)
                {
                    txtNombre.ReadOnly = true;
                    txtUtilidad.ReadOnly = true;
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
                        Descripcion = txtNombre.Text,
                        Utilidad = Convert.ToInt32(txtUtilidad.Text)
                    };
                    await ClaseNegocio.Agregar(Clase);
                }
                else
                {
                    Clase.Descripcion = txtNombre.Text;
                    Clase.Utilidad = Convert.ToDecimal(txtUtilidad.Text.ToString());

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
            if (txtNombre.Text.Length == 0)
            {
                frmMostrarMensaje.MostrarMensaje("Categoria", "Debe escribir un nombre para la categoria");
                return false;
            }

            if (txtUtilidad.Text.Length == 0)
            {
                frmMostrarMensaje.MostrarMensaje("Categoria", "Debe escribir una utilidad para la categoria");
                return false;
            }

            if (!int.TryParse(txtUtilidad.Text, out int number))
            {
                frmMostrarMensaje.MostrarMensaje("Categoria", "Ingrese una utilidad válida");
                return false;
            }

            return true;
        }


    }
}
