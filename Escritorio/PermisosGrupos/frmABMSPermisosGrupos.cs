using Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasePersistente = Entidades.PermisoGrupo;
using ClaseNegocio = Negocio.PermisoGrupo;
using frmAMC = Escritorio.frmAMCPermisoGrupo;
using Entidades;

namespace Escritorio
{
    public partial class frmABMSPermisosGrupos : Form
    {
        private ClasePersistente _objetoSeleccionado;
        private Entidades.Proveedor _proveedor;
        private BindingSource bindingSource;
        private bool formularioCargado = false;
        private bool _modoSeleccion = false;
        private Entidades.Usuario _usuarioActual;
        const string CodPermiso = "PermisosGruposABMS";

        public frmABMSPermisosGrupos()
        {
            InitializeComponent();
            bindingSource = new BindingSource();
        }
        public frmABMSPermisosGrupos(Entidades.Usuario usuarioActual)
        {
            InitializeComponent();
            _usuarioActual = usuarioActual;
            bindingSource = new BindingSource();
        }

        public ClasePersistente ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }
        public bool ModoSeleccion { get { return _modoSeleccion; } set { _modoSeleccion = value; } }

        private void frmABMSPermisosGrupos_Load(object sender, EventArgs e)
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

            if (_modoSeleccion)
            {
                btnCrear.Enabled = false;
                btnModificar.Enabled = false;
                btnBorrar.Enabled = false;
            }

            CargarGrillaConCargando();

            formularioCargado = true;
        }

        private async void CargarGrillaConCargando()
        {
            using (var frmCargando = new frmCargando())
            {
                frmCargando.Show(); // Muestra el formulario de carga

                // Espera a que CargarGrilla complete la carga de datos
                await CargarGrilla();

                // El formulario `frmCargando` se cerrará automáticamente al salir del bloque `using`
            }
        }

        private async Task CargarGrilla()
        {
            var datos = await ClaseNegocio.ListarTodos();
            var permisosGruposview = datos.Select(p => new { p.PermisoGrupoID, p.PermisoID, p.Permiso.CodPermiso, p.GrupoID, p.Grupo.Descripcion}).ToList();

            bindingSource.DataSource = permisosGruposview;
            dgvDatos.DataSource = bindingSource;

            dgvDatos.Columns["PermisoGrupoID"].HeaderText = "ID";
            dgvDatos.Columns["CodPermiso"].HeaderText = "Cod. Permiso";
            dgvDatos.Columns["Descripcion"].HeaderText = "Grupo";
            dgvDatos.Columns["PermisoID"].Visible = false;
            dgvDatos.Columns["GrupoID"].Visible = false;

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

            ClasePersistente Clase = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PermisoGrupoID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar el Permiso de Grupo ?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;
            ClaseNegocio.Eliminar(Clase);

            frmMostrarMensaje.MostrarMensaje($"{PermisoGrupo.NombreClase}", "Baja de " + PermisoGrupo.NombreClase + " exitosa.");

            CargarGrillaConCargando();

        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            ClasePersistente Clase = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PermisoGrupoID"].Value));

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

            _objetoSeleccionado = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PermisoGrupoID"].Value));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroRapido();
        }

        private void AplicarFiltroRapido()
        {
            string str = "";
            string filtro = txtFiltro.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filtro))
            {
                bindingSource.RemoveFilter();
            }
            else
            {
                str += $@"CodPermiso LIKE '%{filtro}%' OR Descripcion LIKE '%{filtro}%' and ";
            }
            str += "1=1";
            bindingSource.Filter = str;
        }

        private async void btnActualizarFiltro_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                ClasePersistente _PermisoGrupo = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PermisoGrupoID"].Value));
                CargarGrillaConCargando();
            }
            else
            {
                CargarGrillaConCargando();
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvDatos == null) return;
            if (formularioCargado == false) return;
            AplicarFiltroRapido();
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvDatos == null) return;
            if (formularioCargado == false) return;
            AplicarFiltroRapido();
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                frmAMC f = new frmAMC(_usuarioActual);
                ClasePersistente clase = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PermisoGrupoID"].Value));
                f.SoloLectura = true;
                f.Clase = clase;
                f.Show(this);
            }
        }
    }
}
