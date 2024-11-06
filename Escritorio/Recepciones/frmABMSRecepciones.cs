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

        public frmABMSRecepciones()
        {
            InitializeComponent();

            bindingSource = new BindingSource();

        }
        public ClasePersistente ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }
        private void frmABMSPedidos_Load(object sender, EventArgs e)

        {
            CargarGrilla();
        }

        private async void CargarGrilla()
        {
            _listado = await ClaseNegocio.ListarTodos();

            var recepcionview = _listado.Select(p => new
            {
                p.RecepcionID,                
                p.Estado.Descripcion,
                p.PedidoID,
                p.Pedido.Proveedor?.RazonSocial,
                p.FechaEntrega
            }).ToList();
            bindingSource.DataSource = recepcionview;
            dgvDatos.DataSource = bindingSource;
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
            
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)  CargarGrilla();
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

            if (Clase.Estado.PedidoEstadoID == Negocio.PedidoEstado.Confirmado.PedidoEstadoID || Clase.Estado.PedidoEstadoID == Negocio.PedidoEstado.Cancelado.PedidoEstadoID)
            {
                frmMostrarMensaje.MostrarMensaje("Recepciones", "Las recepciones deben estar en Estado de Edición para ser modificadas.");
                return ;
            }

            frmAMCRecepcion f = new frmAMCRecepcion();
            f.Clase = Clase;
            f.Modificacion = true;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private async void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null)
            {
                frmMostrarMensaje.MostrarMensaje($"Seleccionar", "No hay ningún registro seleccionado");
                return;
            }

            _objetoSeleccionado =  await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["RecepcionID"].Value));

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
    }
}
