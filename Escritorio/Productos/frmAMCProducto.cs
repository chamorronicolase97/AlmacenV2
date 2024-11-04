using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasePersistente = Entidades.Producto;
using ClaseNegocio = Negocio.Producto;
using Entidades;

namespace Escritorio
{
    public partial class frmAMCProducto : Form
    {
        public ClasePersistente Clase { get; set; }
        protected bool _soloLectura;
        private Proveedor? _proveedor;
        private Categoria? _categoria;

        public bool Modificacion { get; set; } = false;
        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }
        public frmAMCProducto()
        {
            InitializeComponent();

        }

        private void frmAMCCategoria_Load(object sender, EventArgs e)
        {
            if(Clase != null)
            {
                txtID.Text = Clase.ProductoID.ToString();
                txtDescripcion.Text = Clase.Descripcion;
                txtCosto.Text = Clase.Costo.ToString();
                txtCodBarra.Text = Clase.CodigoDeBarra;
                txtCategoria.Text = Clase.Categoria.Descripcion.ToString();
                txtProveedor.Text = Clase.Proveedor.RazonSocial.ToString();

                _categoria = Clase.Categoria;
                _proveedor = Clase.Proveedor;

                if (_soloLectura)
                {
                    txtDescripcion.ReadOnly = true;
                    txtCosto.ReadOnly = true;
                    txtCodBarra.ReadOnly = true;

                    btnAsignarCategoria.Enabled = false;
                    btnQuitarCategoria.Enabled = false;

                    btnAsignarProveedor.Enabled = false;
                    btnQuitarProveedor.Enabled = false;
                }
            }
            txtCategoria.ReadOnly = true;
            txtProveedor.ReadOnly = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
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

                if(Clase == null)
                {
                    Clase = new Producto
                    {
                        Descripcion = txtDescripcion.Text,
                        Costo = null,
                        CodigoDeBarra = txtCodBarra.Text,
                        Proveedor = _proveedor,
                        ProveedorID = _proveedor.ProveedorID,
                        Categoria  = _categoria,
                        CategoriaID = _categoria.CategoriaID
                       
                    };
                  await  ClaseNegocio.Agregar( Clase );
                }
                else
                {
                    Clase.Descripcion = txtDescripcion.Text;
                    Clase.Costo = Convert.ToDecimal(txtCosto.Text);
                    Clase.CodigoDeBarra = txtCodBarra.Text;
                    Clase.Proveedor = _proveedor;
                    Clase.ProveedorID = _proveedor.ProveedorID;
                    Clase.Categoria = _categoria;
                    Clase.CategoriaID = _categoria.CategoriaID;

                    if (Modificacion)
                    {
                        ClaseNegocio.Modificar(Clase);
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        private bool Validar()
        {
            if (txtDescripcion.Text.Length == 0)
            {
                frmMostrarMensaje.MostrarMensaje("Producto", "Debe escribir una descripción para el producto");
                return false;
            }

            if (_categoria == null)
            {
                frmMostrarMensaje.MostrarMensaje("Producto", "Debe seleccionar una Categoría");
                return false;
            }

            if (_proveedor == null)
            {
                frmMostrarMensaje.MostrarMensaje("Producto", "Debe seleccionar un Proveedor");
                return false;
            }


            return true;
        }

        private void HabilitarControles()
        {
            if (_proveedor != null) { txtProveedor.Text = _proveedor.RazonSocial; }
            else { txtProveedor.Text = ""; }
            if (_categoria != null) txtCategoria.Text = _categoria.Descripcion;
            else { txtCategoria.Text = ""; }
        }

        private void btnAsignarProveedor_Click(object sender, EventArgs e)
        {
            frmABMSProveedores f = new frmABMSProveedores { };
            f.ObjetoSeleccionado = _proveedor;
            if (DialogResult.OK == f.ShowDialog(this))
            {
                _proveedor = f.ObjetoSeleccionado;

                HabilitarControles();
            }
        }
        private void btnConsultarProveedor_Click(object sender, EventArgs e)
        {
            if (_proveedor == null) return;

            frmAMCProveedor f = new frmAMCProveedor();
            f.Clase = _proveedor;
            f.SoloLectura = true;
            f.Show(this);
        }

        private void btnQuitarProveedor_Click(object sender, EventArgs e)
        {
            if (_proveedor == null) return;

            _proveedor = null;
            HabilitarControles();
        }

        private void btnAsignarCategoria_Click(object sender, EventArgs e)
        {
            frmABMSCategorias f = new frmABMSCategorias { };
            f.ObjetoSeleccionado = _categoria;
            f.ModoSeleccion = true;
            if (DialogResult.OK == f.ShowDialog(this))
            {
                _categoria = f.ObjetoSeleccionado;

                HabilitarControles();
            }
        }

        private void btnConsultarCategoria_Click(object sender, EventArgs e)
        {
            if (_categoria == null) return;

            frmAMCCategoria f = new frmAMCCategoria();
            f.Clase = _categoria;
            f.SoloLectura = true;
            f.Show(this);
        }

        private void btnQuitarCategoria_Click(object sender, EventArgs e)
        {
            if (_categoria == null) return;

            _categoria = null;
            HabilitarControles();
        }
    }
}
