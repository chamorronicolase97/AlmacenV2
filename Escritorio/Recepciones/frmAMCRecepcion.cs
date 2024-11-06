using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasePersistente = Entidades.Recepcion;
using ClaseNegocio = Negocio.Recepcion;
using Entidades;

namespace Escritorio
{
    public partial class frmAMCRecepcion : Form
    {
        private int _recepcionID = 0;
        public Recepcion Clase { get; set; }
        public Pedido Pedido { get; set; }
        public Proveedor Proveedor { get; set; }
        public bool Modificacion { get; set; } = false;
        protected bool _soloLectura;
        private IEnumerable<Entidades.DetalleRecepcion> _listadoDetalle;

        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }
        public frmAMCRecepcion()
        {
            InitializeComponent();

        }

        private void frmAMCRecepcion_Load(object sender, EventArgs e)
        {
            if (Clase != null)
            {
                Proveedor = Clase.Pedido.Proveedor;
                txtProveedor.Text = Proveedor.RazonSocial.ToString();
                txtNroPedido.Text = Clase.PedidoID.ToString();
                dtpFechaEntrega.Value = Clase.FechaEntrega;
                txtRecepcionID.Text = Clase.RecepcionID.ToString();

                if (_soloLectura)
                {
                    dtpFechaEntrega.Enabled = false;
                }
                CargarGrillaDetalles();
            }
            else
            {
                txtProveedor.Text = Proveedor.RazonSocial.ToString();
                txtNroPedido.Text = Pedido.PedidoID.ToString();
                txtRecepcionID.Text = _recepcionID.ToString();
                
            }
            txtProveedor.ReadOnly = true;
            txtNroPedido.ReadOnly = true;
            txtRecepcionID.ReadOnly = true;            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Clase == null)
            {
                if (Clase.Estado.PedidoEstadoID == Negocio.PedidoEstado.EnEdicion.PedidoEstadoID)
                {
                    if (dgvDetalles.Rows.Count != 0)
                    {
                        frmMostrarMensaje.MostrarMensaje("Recepcion", "Ya tiene productos ingresados, eliminelos antes de cancelar la recepción");
                        return;
                    }

                    if (MessageBox.Show("¿Desea Eliminar la  recepción iniciada?", "Recepcion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ClaseNegocio.Eliminar(Clase);
                    }

                }
            }

            Close();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            Clase.FechaEntrega = dtpFechaEntrega.Value;

            if (Modificacion)
            {
                ClaseNegocio.Modificar(Clase);
                this.DialogResult = DialogResult.OK;
            }
            else

            {
                Clase.Estado = Negocio.PedidoEstado.EnEdicion;
                ClaseNegocio.Agregar(Clase);

            }

            //actualizacion stock
            if (Clase.Estado.PedidoEstadoID == Negocio.PedidoEstado.Confirmado.PedidoEstadoID)
            {

                _listadoDetalle = await Negocio.DetalleRecepcion.ListarTodos(Clase.RecepcionID);

                foreach (DetalleRecepcion rec in _listadoDetalle)
                {
                    rec.Producto.Stock += rec.Cantidad;
                    Negocio.Producto.Modificar(rec.Producto);
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private bool Validar()
        {
            if (dtpFechaEntrega == null)
            {
                frmMostrarMensaje.MostrarMensaje("Recepcion", "Debe definir una fecha de recepción.");
                return false;
            }

            if (Clase.Estado.PedidoEstadoID == Negocio.PedidoEstado.EnEdicion.PedidoEstadoID)
            {
                if (MessageBox.Show("¿Desea finalizar la recepción?", "Recepcion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Clase.Estado = Negocio.PedidoEstado.Confirmado;                    
                }
            }

            return true;
        }

        private async void btnAsignar_Click(object sender, EventArgs e)
        {
            //Clase = ClaseNegocio.Get(ID);
            if (Clase == null)
            {
                Clase = new Recepcion()
                {
                    FechaEntrega = dtpFechaEntrega.Value,
                    Pedido = Pedido,
                    Estado = Negocio.PedidoEstado.EnEdicion
                };
               Clase =  await ClaseNegocio.Agregar(Clase);
                _recepcionID = Clase.RecepcionID;
            }

            frmAMCDetalleRecepcion f = new frmAMCDetalleRecepcion();
            f.Proveedor = Proveedor;
            f.Recepcion = Clase;
            f.ShowDialog(this);

            CargarGrillaDetalles();

        }

        private async void CargarGrillaDetalles()
        {

            _listadoDetalle = await Negocio.DetalleRecepcion.ListarTodos(Clase.RecepcionID);

            var recepciones = _listadoDetalle.Select(p => new
            {
                p.Producto.Descripcion,
                p.Cantidad,
                p.CostoUnitario
            }).ToList();

            dgvDetalles.DataSource = recepciones;
        }

    }
}
