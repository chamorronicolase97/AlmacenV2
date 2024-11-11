using Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using ClasePersistente = Entidades.Categoria;
using ClaseNegocio = Negocio.Categoria;
using frmAMC = Escritorio.frmAMCCategoria;
using Entidades;

namespace Escritorio
{
    public partial class frmABMSCategorias : Form
    {
        private ClasePersistente _objetoSeleccionado;
        private BindingSource bindingSource;
        private bool _modoSeleccion;
        private Entidades.Usuario _usuarioActual;
        private List<ClasePersistente> _listaOriginal;

        const string Permiso = "CategoriasABMS";


        public frmABMSCategorias()
        {
            InitializeComponent();

            bindingSource = new BindingSource();
        }

        public frmABMSCategorias(Entidades.Usuario usuarioActual)
        {
            InitializeComponent();
            _usuarioActual = usuarioActual;
            bindingSource = new BindingSource();
        }

        public ClasePersistente ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }
        public bool ModoSeleccion { get { return _modoSeleccion; } set { _modoSeleccion = value; } }
        private void frmABMSCategorias_Load(object sender, EventArgs e)
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

            if (_modoSeleccion)
            {
                btnCrear.Enabled = false;
                btnModificar.Enabled = false;
                btnBorrar.Enabled = false;
            }
            CargarGrillaConCargando();
        }

        private async void CargarGrillaConCargando()
        {
            using (var frmCargando = new frmCargando())
            {
                frmCargando.Show();

                // Espera a que CargarGrilla complete la carga de datos
                await CargarGrilla();

                // El formulario `frmCargando` se cerrará automáticamente al salir del bloque `using`
            }
        }

        private async Task CargarGrilla()
        {
            var datos = await ClaseNegocio.ListarTodos();
            _listaOriginal = datos.ToList();

            bindingSource.DataSource = datos;
            dgvDatos.DataSource = bindingSource;

            dgvDatos.Columns["CategoriaID"].HeaderText = "ID";
            dgvDatos.Columns["Descripcion"].HeaderText = "Descripción";

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMC f = new frmAMC(_usuarioActual);
            f.SoloLectura = false;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrillaConCargando();
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            ClasePersistente Clase = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["CategoriaID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar la categoría " + Clase.Descripcion + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;

            if (!ClaseNegocio.EsVacio(Clase.CategoriaID))
            {
                frmMostrarMensaje.MostrarMensaje($"{ClasePersistente.NombreClase}", "La Categoría " + ClasePersistente.NombreClase + " no se encuentra vacia, no puede eliminarse.");
                return;
            }
            ClaseNegocio.Eliminar(Clase);

            frmMostrarMensaje.MostrarMensaje($"{ClasePersistente.NombreClase}", "Baja de " + ClasePersistente.NombreClase + " exitosa.");

            CargarGrillaConCargando();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            ClasePersistente Clase = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["CategoriaID"].Value));

            frmAMC f = new frmAMC(_usuarioActual);
            f.Clase = Clase;
            f.Modificacion = true;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrillaConCargando();
        }

        private async void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null)
            {
                frmMostrarMensaje.MostrarMensaje($"Seleccionar", "No hay ningún registro seleccionado");
                return;
            }

            _objetoSeleccionado = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["CategoriaID"].Value));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filtro))
            {
                bindingSource.DataSource = _listaOriginal;
            }
            else
            {
                var listaFiltrada = _listaOriginal.Where(c =>
                    (c.Descripcion != null && c.Descripcion.ToLower().Contains(filtro)) ||
                    (c.Utilidad != null && c.Utilidad.ToString().Contains(filtro))
                ).ToList();

                bindingSource.DataSource = listaFiltrada;
            }

            dgvDatos.Refresh();
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            if(dgvDatos.CurrentRow != null)
            {
                frmAMCCategoria f = new frmAMCCategoria(_usuarioActual);
                ClasePersistente categoria = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["CategoriaID"].Value));
                f.SoloLectura = true;
                f.Clase = categoria;
                f.Show(this);
            }
        }
    }
}
