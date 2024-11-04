using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasePersistente = Entidades.DetallePedido;
using ClaseNegocio = Negocio.DetallePedido;
using Entidades;

namespace Escritorio
{
    public partial class frmAMCDetallePedido : Form
    {
        private Producto? _producto;
        private Proveedor? _proveedor;
        private Pedido  _pedido;

        public ClasePersistente Clase { get; set; }

        public bool Modificacion { get; set; } = false;
        public Proveedor FiltroProveedor { get { return _proveedor; } set { _proveedor = value; } }
        public Pedido Pedido { get { return _pedido; } set { _pedido = value; } }

        public frmAMCDetallePedido()
        {
            InitializeComponent();

        }

        private void frmAMCDetallePedido_Load(object sender, EventArgs e)
        {
            if (Modificacion == true)
            {
                txtNroPedido.Text = Clase.Pedido.PedidoID.ToString();
                if (txtProducto != null) { txtProducto.Text = Clase.Producto.Descripcion.ToString(); }
                txtCantidad.Text = Clase.Cantidad.ToString();
                txtCostoUnitario.Text = Clase.CostoUnitario.ToString();
            }
            else
            {

            }
        }

        private void HabilitarControles()
        {
            if (_producto != null) { txtProducto.Text = _producto.Descripcion.ToString(); }
            else { txtProducto.Text = ""; }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            if (Clase == null)
            {
                Clase = new DetallePedido();
                Clase.Producto = _producto;
                Clase.ProductoID = _producto.ProductoID;
                Clase.Cantidad = Convert.ToInt32(txtCantidad.Text);
                Clase.CostoUnitario = Convert.ToDecimal(txtCostoUnitario.Text);
                Clase.PedidoID = _pedido.PedidoID;
                Clase.Pedido = _pedido;

              await  ClaseNegocio.Agregar(Clase);
            }
            else
            {
                Clase.Producto = _producto;
                Clase.ProductoID = _producto.ProductoID;
                Clase.Cantidad = Convert.ToInt32(txtCantidad.Text);
                Clase.CostoUnitario = Convert.ToDecimal(txtCostoUnitario.Text);
                if (Modificacion)
                {
                    ClaseNegocio.Modificar(Clase);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool Validar()
        {
            if (txtProducto.Text.Length == 0)
            {
                frmMostrarMensaje.MostrarMensaje("DetallePedido", "Debe definir una Producto para el DetallePedido");
                return false;
            }

            return true;
        }

        private void btnAsignarProducto_Click(object sender, EventArgs e)
        {
            frmABMSProductos f = new frmABMSProductos { };
            f.ObjetoSeleccionado = _producto;
            f.FiltroProveedor = _proveedor;
            f.ModoSeleccion = true;
            if (DialogResult.OK == f.ShowDialog(this))
            {
                _producto = f.ObjetoSeleccionado;

                HabilitarControles();
            }
        }

        private void btnConsultarProducto_Click(object sender, EventArgs e)
        {
            if (_producto == null) return;

            frmAMCProducto f = new frmAMCProducto
            {
                Clase = _producto,
                SoloLectura = true
            };
            f.ShowDialog(this);
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (_producto == null) return;

            _producto = null;
            HabilitarControles();
        }

    }
}
