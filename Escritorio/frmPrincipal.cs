namespace Escritorio
{
    public partial class frmPrincipal : Form
    {
        public Entidades.Usuario Usuario { get; set; }

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMSGrupos f = new frmABMSGrupos(Usuario);
            f.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMSProveedores f = new frmABMSProveedores(Usuario);
            f.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMSCategorias f = new frmABMSCategorias(Usuario);
            f.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMSProductos f = new frmABMSProductos(Usuario);
            f.Show();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMSPedidos f = new frmABMSPedidos(Usuario);
            f.Show();
        }

        private void recepciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMSRecepciones f = new frmABMSRecepciones(Usuario);
            f.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMSUsuarios f = new frmABMSUsuarios(Usuario);
            f.Show();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMSPermisos f = new frmABMSPermisos(Usuario);
            f.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                this.Show();
                Usuario = f.Usuario;
                lblBienvenido.Text = lblBienvenido.Text + " " + Usuario.NombreApellido;
            }
            else
            {
                this.Close();
            }
        }

        private void cambiarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reiniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load += frmPrincipal_Load;
        }

        private void costosProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCostosProductos f = new frmCostosProductos(Usuario);
            f.Show();
        }

        private void asignarPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMSPermisosGrupos f = new frmABMSPermisosGrupos(Usuario);
            f.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMSClientes f = new frmABMSClientes(Usuario);
            f.Show();
        }
    }
}