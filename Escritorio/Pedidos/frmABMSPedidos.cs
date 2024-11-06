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

        #region Colores
        private Color colorEnEdicion = Color.LightBlue;
        private Color colorConfirmado = Color.LimeGreen;
        private Color colorRecibido = Color.DarkOliveGreen;
        private Color colorControlado = Color.Orange;
        private Color colorCancelado = Color.LightSalmon;
        #endregion
        public ClasePersistente Pedido { get; set; }
        public bool ModoSeleccion { get { return _modoSeleccion; } set { _modoSeleccion = value; } }

        public frmABMSPedidos()
        {
            InitializeComponent();

            bindingSource = new BindingSource();
        }

        private void frmABMSPedidos_Load(object sender, EventArgs e)
        {
            pnlEnEdicion.BackColor = colorEnEdicion;
            pnlConfirmado.BackColor = colorConfirmado;
            pnlRecibido.BackColor = colorRecibido;
            pnlControlado.BackColor = colorControlado;
            pnlCancelado.BackColor = colorCancelado;

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
                p.FechaEntrega,
                EstadoID = p.PedidoEstado?.PedidoEstadoID,
                Estado = p.PedidoEstado?.Descripcion
            }).ToList();
            bindingSource.DataSource = pedidosview;
            dgvDatos.DataSource = bindingSource;

            dgvDatos.Columns["RazonSocial"].HeaderText = "Razón Social";
            dgvDatos.Columns["FechaEntrega"].HeaderText = "Fecha Entrega";
            dgvDatos.Columns["EstadoID"].Visible = false;

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            PintarFilas();
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


            if (Pedido.PedidoEstado != Negocio.PedidoEstado.Confirmado)
            {
                frmMostrarMensaje.MostrarMensaje($"Seleccionar", "Debe seleccionar un Pedido en estado Confirmado.");
                return;
            }

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

        private void PintarFilas()
        {
            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                if (row.Cells["Estado"].Value != DBNull.Value)
                {
                    int estadoID = Convert.ToInt32(row.Cells["EstadoID"].Value);

                    switch (estadoID)
                    {
                        case 1:
                            row.DefaultCellStyle.BackColor = colorEnEdicion;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        case 2:
                            row.DefaultCellStyle.BackColor = colorConfirmado;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        case 3:
                            row.DefaultCellStyle.BackColor = colorCancelado;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        case 4:
                            row.DefaultCellStyle.BackColor = colorRecibido;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        case 5:
                            row.DefaultCellStyle.BackColor = colorControlado;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        default:
                            // Opcional: Color para valores no reconocidos
                            row.DefaultCellStyle.BackColor = Color.White;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                    }
                }
            }

        }

    }
}
