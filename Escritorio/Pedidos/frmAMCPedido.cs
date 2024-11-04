using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasePersistente = Entidades.Pedido;
using ClaseNegocio = Negocio.Pedido;
using Entidades;

namespace Escritorio
{
    public partial class frmAMCPedido : Form
    {
        private int _nroPedido;
        private Proveedor? _proveedor;
        private IEnumerable<Entidades.DetallePedido> _listadoDetalle;
        public ClasePersistente Clase { get; set; }
        protected bool _soloLectura;

        public bool Modificacion { get; set; } = false;
        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }

        public frmAMCPedido()
        {
            InitializeComponent();

        }

        private void frmAMCPedido_Load(object sender, EventArgs e)
        {
            if (Clase != null)
            {
                txtNroPedido.Text = Clase.PedidoID.ToString();
                _nroPedido = Clase.PedidoID;
                dtpFechaEntrega.Value = Clase.FechaEntrega;
                _proveedor = Clase.Proveedor;

                if (_soloLectura)
                {
                    txtNroPedido.ReadOnly = true;
                    dtpFechaEntrega.Enabled = false;
                    txtProveedor.ReadOnly = true;

                    btnAsignarProveedor.Enabled = false;
                    btnQuitarProveedor.Enabled = false;

                    btnAsignar.Enabled = false;
                }
            }
            else
            {                
                
            }


            HabilitarControles();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Clase == null)
            {
                if (Clase.PedidoEstado.PedidoEstadoID == Negocio.PedidoEstado.EnEdicion.PedidoEstadoID)
                {
                    if (dgvDetalles.Rows.Count != 0)
                    {
                        frmMostrarMensaje.MostrarMensaje("Pedido", "Ya tiene productos ingresados, eliminelos antes de cancelar el pedido");
                        return;
                    }

                    if (MessageBox.Show("¿Desea Eliminar el pedido iniciada?", "Pedido", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ClaseNegocio.Eliminar(Clase);
                    }

                }
            }

            Close();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (_soloLectura)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (!Validar()) return;

                if (Clase == null)
                {
                    Clase = new ClasePersistente()
                    {
                        FechaEntrega = dtpFechaEntrega.Value,
                        ProveedorID = _proveedor.ProveedorID,
                        Proveedor = _proveedor,
                        PedidoEstado = Negocio.PedidoEstado.EnEdicion,
                        PedidoEstadoID = Negocio.PedidoEstado.EnEdicion.PedidoEstadoID
                       
                    };
                   await  ClaseNegocio.Agregar(Clase);
                }
                else
                {
                    Clase.FechaEntrega = dtpFechaEntrega.Value;
                    Clase.Proveedor = _proveedor;                    

                    if (Modificacion)
                    {
                        ClaseNegocio.Modificar(Clase);
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();


        }

        private bool Validar()
        {
            if (dtpFechaEntrega == null)
            {
                frmMostrarMensaje.MostrarMensaje("Pedido", "Debe definir una fecha para el Pedido");
                return false;
            }
            if (_proveedor == null)
            {
                frmMostrarMensaje.MostrarMensaje("Pedido", "Debe definir un Proveedor para el Pedido");
                return false;
            }

            if(Clase.PedidoEstado.PedidoEstadoID == Negocio.PedidoEstado.EnEdicion.PedidoEstadoID)
            {
                if(MessageBox.Show("¿Desea finalizar Pedido?", "Pedido", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Clase.PedidoEstado = Negocio.PedidoEstado.Confirmado;                    
                }
            }

            return true;
        }

        private async void btnAsignar_Click(object sender, EventArgs e)
        {
            if (_proveedor == null) return;

            if (Clase == null)
            {
                Clase = new ClasePersistente()
                {
                    FechaEntrega = dtpFechaEntrega.Value,
                    Proveedor = _proveedor,
                    PedidoEstado = Negocio.PedidoEstado.EnEdicion
                };
              await  ClaseNegocio.Agregar(Clase);
            }

            frmAMCDetallePedido f = new frmAMCDetallePedido();
            f.Pedido = Clase;
            f.FiltroProveedor = _proveedor;

            f.ShowDialog(this);
            CargarGrillaDetalles();
        }

        private async void CargarGrillaDetalles()
        {
            _listadoDetalle = await Negocio.DetallePedido.ListarTodos(_nroPedido);
            var pedidosview = _listadoDetalle.Select(p => new
            {
                p.Pedido.PedidoID,
                p.Pedido.FechaEntrega,
                p.Producto.Descripcion,
                p.Cantidad,
                p.CostoUnitario,
            }).ToList();
            dgvDetalles.DataSource = pedidosview;
            dgvDetalles.Columns["PedidoID"].HeaderText = "Nro. Pedido";
        }

        private void HabilitarControles()
        {
            if (_proveedor != null) { txtProveedor.Text = _proveedor.RazonSocial.ToString(); }
            else { txtProveedor.Text = ""; }

            CargarGrillaDetalles();

            if (Modificacion)
            {

            }
            else
            {

            }

        }

        private void btnAsignarProveedor_Click(object sender, EventArgs e)
        {
            frmABMSProveedores f = new frmABMSProveedores { };
            f.ObjetoSeleccionado = _proveedor;
            f.ModoSeleccion = true;
            if (DialogResult.OK == f.ShowDialog(this))
            {
                _proveedor = f.ObjetoSeleccionado;

                HabilitarControles();
            }
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

        private void btnQuitarProveedor_Click(object sender, EventArgs e)
        {
            if (_proveedor == null) return;

            _proveedor = null;
            HabilitarControles();
        }
    }
}
