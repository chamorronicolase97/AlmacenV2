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
using ClasePersistente = Entidades.Grupo;
using ClaseNegocio = Negocio.Grupo;
using Datos;

namespace Escritorio
{
    public partial class frmABMSGrupos : Form
    {
        private ClasePersistente _objetoSeleccionado;
        private BindingSource bindingSource;
        private bool _modoSeleccion = false;
        public frmABMSGrupos()
        {
            InitializeComponent();

            bindingSource = new BindingSource();
        }
        public ClasePersistente ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }
        public bool ModoSeleccion { get { return _modoSeleccion; } set { _modoSeleccion = value; } }

        private void frmABMSGrupos_Load(object sender, EventArgs e)

        {
            if (_modoSeleccion)
            {
                btnCrear.Enabled = false;
                btnModificar.Enabled = false;
                btnBorrar.Enabled = false;
            }

            CargarGrilla();
        }

        private async void CargarGrilla()
        {
            var l = await ClaseNegocio.ListarTodos();

            bindingSource.DataSource = l;
            dgvDatos.DataSource = bindingSource.DataSource;

            dgvDatos.Columns["GrupoID"].HeaderText = "ID";
            dgvDatos.Columns["Descripcion"].HeaderText = "Descripción";

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMCGrupo f = new frmAMCGrupo();
            f.SoloLectura = false;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            ClasePersistente Clase = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["GrupoID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar el Grupo " + Clase.Descripcion + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;

            if (!ClaseNegocio.EsVacio(Clase.GrupoID))
            {
                frmMostrarMensaje.MostrarMensaje($"{ClasePersistente.NombreClase}", "El Grupo " + ClasePersistente.NombreClase + " no se encuentra vacio, no puede eliminarse.");
                return;
            }
            ClaseNegocio.Eliminar(Clase);

            frmMostrarMensaje.MostrarMensaje($"{ClasePersistente.NombreClase}", "Baja de " + ClasePersistente.NombreClase + " exitosa.");

            CargarGrilla();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            ClasePersistente Clase = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["GrupoID"].Value));


            frmAMCGrupo f = new frmAMCGrupo();
            f.Clase = Clase;
            f.Modificacion = true;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private async void btnSeleccionar_ClickAsync(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null)
            {
                frmMostrarMensaje.MostrarMensaje($"Seleccionar", "No hay ningún registro seleccionado");
                return;
            }

            _objetoSeleccionado = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["GrupoID"].Value));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                frmAMCGrupo f = new frmAMCGrupo();
                ClasePersistente grupo = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["GrupoID"].Value));
                f.SoloLectura = true;
                f.Clase = grupo;
                f.Show(this);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string str = "";
            string filtro = txtFiltro.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filtro))
            {
                bindingSource.RemoveFilter();
            }
            else
            {
                str += $@"Descripcion LIKE '%{filtro}%' and ";
            }

            str += "1=1";
            bindingSource.Filter = str;
        }
    }
}
