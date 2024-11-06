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
using ClasePersistente = Entidades.Recepcion;
using ClaseNegocio = Negocio.Recepcion;
using frmAMC = Escritorio.frmAMCRecepcion;
using Entidades;

namespace Escritorio
{
    public partial class frmABMSRecepciones : Form
    {
        private ClasePersistente _objetoSeleccionado;
        private IEnumerable<Entidades.Recepcion> _listado;
        private BindingSource bindingSource;

        #region Colores
        private Color colorEnEdicion = Color.LightBlue;
        private Color colorConfirmado = Color.LimeGreen;
        private Color colorRecibido = Color.DarkOliveGreen;
        private Color colorControlado = Color.Orange;
        private Color colorCancelado = Color.LightSalmon;
        #endregion

        public frmABMSRecepciones()
        {
            InitializeComponent();

            bindingSource = new BindingSource();

        }
        public ClasePersistente ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }
        private void frmABMSPedidos_Load(object sender, EventArgs e)
        {
            pnlEnEdicion.BackColor = colorEnEdicion;
            pnlConfirmado.BackColor = colorConfirmado;
            pnlRecibido.BackColor = colorRecibido;
            pnlControlado.BackColor = colorControlado;
            pnlCancelado.BackColor = colorCancelado;

            CargarGrilla();
        }

        private async void CargarGrilla()
        {
            _listado = await ClaseNegocio.ListarTodos();

            var recepcionview = _listado.Select(p => new
            {
                p.RecepcionID,
                Estado = p.Estado.Descripcion,
                EstadoID = p.Estado.PedidoEstadoID,
                p.PedidoID,
                p.Pedido.Proveedor?.RazonSocial,
                p.FechaEntrega
            }).ToList();
            bindingSource.DataSource = recepcionview;
            dgvDatos.DataSource = bindingSource;

            dgvDatos.Columns["RazonSocial"].HeaderText = "Razón Social";
            dgvDatos.Columns["EstadoID"].Visible = false;
            PintarFilas();
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmABMSPedidos pedidos = new frmABMSPedidos();
            pedidos.ModoSeleccion = true;
            MessageBox.Show("Seleccione pedido a recepcionar", "Recepción", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pedidos.ShowDialog();
            if (pedidos.DialogResult != DialogResult.OK) return;
            Pedido pedido = pedidos.Pedido;
            Proveedor proveedor = pedido.Proveedor;
            pedidos.Close();

            frmAMCRecepcion f = new frmAMCRecepcion();
            f.Pedido = pedido;
            f.Proveedor = proveedor;
            f.SoloLectura = false;

            f.ShowDialog(this);
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            ClasePersistente Clase = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["RecepcionID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar el Pedido " + Clase.RecepcionID + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;

            if (_listado.Count() > 0)
            {
                frmMostrarMensaje.MostrarMensaje($"{Recepcion.NombreClase}", "El " + Recepcion.NombreClase + " posee Detalles Recepciones, no puede eliminarse.");
                return;
            }
            ClaseNegocio.Eliminar(Clase);

            frmMostrarMensaje.MostrarMensaje($"{Recepcion.NombreClase}", "Baja de " + Recepcion.NombreClase + " exitosa.");

            CargarGrilla();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            ClasePersistente Clase = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["RecepcionID"].Value));

            if (Clase.Estado.PedidoEstadoID != Negocio.PedidoEstado.Confirmado.PedidoEstadoID)
            {
                frmMostrarMensaje.MostrarMensaje("Recepciones", "Las recepciones deben estar en Estado Controlado  para ser modificadas.");
                return;
            }

            frmAMCRecepcion f = new frmAMCRecepcion();
            f.Clase = Clase;
            f.Modificacion = true;
            f.ShowDialog(this);
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private async void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null)
            {
                frmMostrarMensaje.MostrarMensaje($"Seleccionar", "No hay ningún registro seleccionado");
                return;
            }

            _objetoSeleccionado = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["RecepcionID"].Value));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                frmAMCRecepcion f = new frmAMCRecepcion();
                Recepcion recepcion = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["RecepcionID"].Value));
                f.SoloLectura = true;
                f.Clase = recepcion;
                f.Show(this);
            }
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
