using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasePersistente = Entidades.DetalleRecepcion;
using ClaseNegocio = Negocio.DetalleRecepcion;
using Entidades;

namespace Escritorio
{
    public partial class frmAMCDetalleRecepcion : Form
    {
        private Producto? _producto;
        private Proveedor? _proveedor;
        private Recepcion? _recepcion;


        public ClasePersistente Clase { get; set; }

        public Proveedor Proveedor { get { return _proveedor; } set { _proveedor = value; } }
        public Recepcion Recepcion { get { return _recepcion; } set { _recepcion = value; } }
        public bool Modificacion { get; set; } = false;

        public frmAMCDetalleRecepcion()
        {
            InitializeComponent();

        }

        private void frmAMCDetallePedido_Load(object sender, EventArgs e)
        {
            if (Modificacion == true)
            {
                txtRecepcionID.Text = Clase.Recepcion.RecepcionID.ToString();
                if (txtProducto != null) { txtProducto.Text = Clase.Producto.Descripcion.ToString(); }
                txtCantidad.Text = Clase.Cantidad.ToString();
                txtCostoUnitario.Text = Clase.CostoUnitario.ToString();
            }
            else
            {
                txtRecepcionID.Text = Recepcion.RecepcionID.ToString();
            }
        }

        private void HabilitarControles()
        {
            if (_producto != null) { txtProducto.Text = _producto.Descripcion.ToString(); }

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
                Clase = new DetalleRecepcion();
            }

            Clase.Recepcion = Recepcion;
            Clase.Producto = _producto;
            Clase.Cantidad = Convert.ToInt32(txtCantidad.Text);
            Clase.CostoUnitario = Convert.ToDecimal(txtCostoUnitario.Text);
            Clase.FechaRecepcion = dtpFechaRecepcion.Value;

            if (Modificacion)
            {
                ClaseNegocio.Modificar(Clase);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {

               await ClaseNegocio.Agregar(Clase);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool Validar()
        {
            if (txtProducto.Text.Length == 0)
            {
                frmMostrarMensaje.MostrarMensaje("DetalleRecepcion", "Debe definir una fecha para el DetalleRecepcion");
                return false;
            }

            return true;
        }

        private void btnAsignarProducto_Click(object sender, EventArgs e)
        {
            frmABMSProductos f = new frmABMSProductos { };
            f.ObjetoSeleccionado = _producto;
            f.FiltroProveedor = Proveedor;
            if (DialogResult.OK == f.ShowDialog(this))
            {
                _producto = f.ObjetoSeleccionado;

                HabilitarControles();
            }
        }

        private void btnAsignarProveedor_Click(object sender, EventArgs e)
        {
            frmABMSProveedores f = new frmABMSProveedores { };
            f.ObjetoSeleccionado = _proveedor;
            if (DialogResult.OK == f.ShowDialog(this))
            {
                _proveedor = f.ObjetoSeleccionado;
            }

            HabilitarControles();
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

        private void btnConsultarProveedor_Click(object sender, EventArgs e)
        {
            if (_proveedor == null) return;

            frmAMCProveedor f = new frmAMCProveedor
            {
                Clase = _proveedor,
                SoloLectura = true
            };
            f.ShowDialog(this);
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (_producto == null) return;

            _producto = null;
        }

        private void btnQuitarProveedor_Click(object sender, EventArgs e)
        {
            if (_proveedor == null) return;

            _proveedor = null;
            HabilitarControles();
        }
    }
}
