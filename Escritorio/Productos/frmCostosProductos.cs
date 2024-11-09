using Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClaseNegocio = Negocio.Producto;

namespace Escritorio
{

    public partial class frmCostosProductos : Form
    {
        List<iProductoCosto> listado;
        private BindingSource bindingSource;
        private Entidades.Usuario _usuarioActual;

        const string Permiso = "CostosProductos";

        public frmCostosProductos()
        {
            InitializeComponent();
            bindingSource = new BindingSource();

        }
        public frmCostosProductos(Entidades.Usuario usuarioActual)
        {
            InitializeComponent();
            _usuarioActual = usuarioActual;
            bindingSource = new BindingSource();
        }

        private void frmCostosProductos_Load(object sender, EventArgs e)
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

            CargarGrillaConCargando();
        }

        private async Task CargarGrilla()
        {
            listado = await ClaseNegocio.ListarControlCosto(dtpFechaCosto.Value);

            bindingSource.DataSource = listado;
            dgvDatos.DataSource = bindingSource;

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

        private async void btnActualizarCostos_ClickAsync(object sender, EventArgs e)
        {
            ActualizarCosto();

            CargarGrillaConCargando();

        }

        private async Task ActualizarCosto()
        {
            if (dgvDatos == null)
            {
                frmMostrarMensaje.MostrarMensaje("Actualizar Costos", "No hay productos para actualizar.");
                return;
            }

            using (var frmCargando = new frmCargando())
            {
                frmCargando.Show();
                await ClaseNegocio.ActualizarCostos(dtpFechaCosto.Value);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrillaConCargando();
        }
    }
}
