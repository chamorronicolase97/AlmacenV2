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
using ClasePersistente = Entidades.Pedido;
using ClaseNegocio = Negocio.Pedido;
using frmAMC = Escritorio.frmAMCPedido;
using Entidades;

namespace Escritorio
{
    public partial class frmABMSPedidos : Form
    {
        private BindingSource bindingSource; 
        private bool _modoSeleccion;
        private IEnumerable<Entidades.Pedido> _listado;
        public ClasePersistente Pedido { get; set; }
        public bool ModoSeleccion { get { return _modoSeleccion; } set { _modoSeleccion = value; } }

        public frmABMSPedidos()
        {
            InitializeComponent();

            bindingSource = new BindingSource();
        }

        private void frmABMSPedidos_Load(object sender, EventArgs e)

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
            _listado = await ClaseNegocio.ListarTodos();

            var pedidosview = _listado.Select(p => new
            {
                p.PedidoID,
                p.Proveedor.RazonSocial,
                p.FechaEntrega
            }).ToList();
            bindingSource.DataSource = pedidosview;
            dgvDatos.DataSource = bindingSource;

            dgvDatos.Columns["RazonSocial"].HeaderText = "Razón Social";
            dgvDatos.Columns["FechaEntrega"].HeaderText = "Fecha Entrega";

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMCPedido f = new frmAMCPedido();
            f.SoloLectura = false;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            ClasePersistente Clase = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PedidoID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar el Pedido " + Clase.PedidoID + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;

            bool tieneRecepcion = await ClaseNegocio.TieneRecepcion(Clase);
            if (tieneRecepcion)
            {
                frmMostrarMensaje.MostrarMensaje($"{Pedido.NombreClase}", "El " + Pedido.NombreClase + " posee una recepción, no puede eliminarse.");
                return;
            }
            ClaseNegocio.Eliminar(Clase);

            frmMostrarMensaje.MostrarMensaje($"{Pedido.NombreClase}", "Baja de " + Pedido.NombreClase + " exitosa.");

            CargarGrilla();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            ClasePersistente Clase = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PedidoID"].Value));

            frmAMC f = new frmAMC();
            f.Clase = Clase;
            f.Modificacion = true;
            f.Show();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private async void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null)
            {
                frmMostrarMensaje.MostrarMensaje($"Seleccionar", "No hay ningún registro seleccionado");
                return;
            }

            Pedido = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PedidoID"].Value));
            this.DialogResult = DialogResult.OK;
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                frmAMC f = new frmAMC();
                ClasePersistente clase = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PedidoID"].Value));
                f.SoloLectura = true;
                f.Clase = clase;
                f.Show(this);
            }
        }

        private async void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim().ToLower();


            _listado
                .Where(p => p.Proveedor.RazonSocial.ToLower().Contains(filtro))
                .Select(p => new
                {
                    p.PedidoID,
                    p.Proveedor.RazonSocial,
                    p.FechaEntrega
                }).ToList();

            bindingSource.DataSource = _listado;
            dgvDatos.DataSource = bindingSource;
        }

    }
}
