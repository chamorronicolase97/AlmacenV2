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
using ClasePersistente = Entidades.Producto;
using ClaseNegocio = Negocio.Producto;
using frmAMC = Escritorio.frmAMCProducto;
using Entidades;

namespace Escritorio
{
    public partial class frmABMSProductos : Form
    {
        private ClasePersistente _objetoSeleccionado;
        private Entidades.Proveedor _proveedor;
        private BindingSource bindingSource;
        private bool formularioCargado = false;
        private bool _modoSeleccion = false;
        private Entidades.Usuario _usuarioActual;

        const string Permiso = "ProductosABMS";

        public Entidades.Proveedor FiltroProveedor { get { return _proveedor; } set { _proveedor = value; } }

        public frmABMSProductos()
        {
            InitializeComponent();

            bindingSource = new BindingSource();
        }
        public frmABMSProductos(Entidades.Usuario usuarioActual)
        {
            InitializeComponent();
            _usuarioActual = usuarioActual;
            bindingSource = new BindingSource();
        }

        public ClasePersistente ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }
        public bool ModoSeleccion { get { return _modoSeleccion; } set { _modoSeleccion = value; } }

        private void frmABMSProductos_Load(object sender, EventArgs e)
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

            List<Entidades.Categoria> categorias = new Datos.Categoria().ListarCategorias();
            Entidades.Categoria categoriaTodos = new Entidades.Categoria()
            {
                Descripcion = "Todos"
            };
            categorias.Sort(delegate (Categoria c1, Categoria c2) { return c1.Descripcion.CompareTo(c2.Descripcion); });
            categorias.Insert(0, categoriaTodos);

            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Descripcion";
            cmbCategoria.ValueMember = "CategoriaID";
            cmbCategoria.SelectedIndex = 0;


            List<Proveedor> proveedores = new Datos.Proveedor().ListarProveedores();
            Proveedor proveedorTodos = new Proveedor()
            {
                RazonSocial = "Todos"
            };
            proveedores.Sort(delegate (Proveedor c1, Proveedor c2) { return c1.RazonSocial.CompareTo(c2.RazonSocial); });
            proveedores.Insert(0, proveedorTodos);

            cmbProveedor.DataSource = proveedores;
            cmbProveedor.DisplayMember = "RazonSocial";
            cmbProveedor.ValueMember = "ProveedorID";
            cmbProveedor.SelectedIndex = 0;

            if (FiltroProveedor != null)
            {
                cmbProveedor.Enabled = false;
            }

            if (_modoSeleccion)
            {
                btnCrear.Enabled = false;
                btnModificar.Enabled = false;
                btnBorrar.Enabled = false;
            }

            CargarGrillaConCargando();

            formularioCargado = true;
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

        private async Task CargarGrilla()
        {
            var listado = await ClaseNegocio.ListarTodos();           
            var productosview = listado.Select(p => new { p.ProductoID, p.Descripcion, p.Costo, PrecioVenta = (p.Costo + (p.Costo * p.Categoria.Utilidad / 100)) ,p.Stock ,p.CodigoDeBarra, p.Proveedor.RazonSocial, p.ProveedorID, Categoria = p.Categoria.Descripcion, p.CategoriaID }).ToList();
            if (FiltroProveedor != null)
            {
                var listadoFiltrado = productosview.Where(f => f.ProveedorID == FiltroProveedor.ProveedorID).ToList();
                bindingSource.DataSource = listadoFiltrado;
            }
            else
            {                
                bindingSource.DataSource = productosview;
            }
            dgvDatos.DataSource = bindingSource;

            dgvDatos.Columns["ProductoID"].HeaderText = "ID";
            dgvDatos.Columns["Descripcion"].HeaderText = "Descripción";
            dgvDatos.Columns["CodigoDeBarra"].HeaderText = "Código de Barra";
            dgvDatos.Columns["Categoria"].HeaderText = "Categoría";
            dgvDatos.Columns["PrecioVenta"].HeaderText = "Precio Vta.";
            dgvDatos.Columns["CategoriaID"].Visible = false;
            dgvDatos.Columns["ProveedorID"].Visible = false;

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMC f = new frmAMC(_usuarioActual);
            f.SoloLectura = false;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrillaConCargando();
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            ClasePersistente Clase = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProductoID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar el Producto " + Clase.Descripcion + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;
            ClaseNegocio.Eliminar(Clase);

            frmMostrarMensaje.MostrarMensaje($"{Producto.NombreClase}", "Baja de " + Producto.NombreClase + " exitosa.");

            CargarGrillaConCargando();

        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            ClasePersistente Clase = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProductoID"].Value));

            frmAMC f = new frmAMC(_usuarioActual);
            f.Clase = Clase;
            f.Modificacion = true;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrillaConCargando();
        }

        private async void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null)
            {
                frmMostrarMensaje.MostrarMensaje($"Seleccionar", "No hay ningún registro seleccionado");
                return;
            }

            _objetoSeleccionado = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProductoID"].Value));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroRapido();
        }

        private void AplicarFiltroRapido()
        {
            string str = "";
            string filtro = txtFiltro.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filtro))
            {
                bindingSource.RemoveFilter();
            }
            else
            {
                str += $@"Descripcion LIKE '%{filtro}%' OR Convert(Costo, 'System.String') LIKE '%{filtro}%'
                                        OR CodigoDeBarra LIKE '%{filtro}%' and ";
            }
            if (cmbCategoria.SelectedIndex > 0)
            {
                str += "CategoriaID =" + cmbCategoria.SelectedValue.ToString() + " and ";
            }
            if (cmbProveedor.SelectedIndex > 0)
            {
                str += "ProveedorID =" + cmbProveedor.SelectedValue.ToString() + " and ";
            }
            str += "1=1";
            bindingSource.Filter = str;
        }

        private async void btnActualizarFiltro_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                ClasePersistente _producto = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProductoID"].Value));
                CargarGrillaConCargando();
            }
            else
            {
                CargarGrillaConCargando();
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvDatos == null) return;
            if (formularioCargado == false) return;
            AplicarFiltroRapido();
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvDatos == null) return;
            if (formularioCargado == false) return;
            AplicarFiltroRapido();
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                frmAMC f = new frmAMC(_usuarioActual);
                ClasePersistente clase = await ClaseNegocio.Get(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProductoID"].Value));
                f.SoloLectura = true;
                f.Clase = clase;
                f.Show(this);
            }
        }
    }
}
