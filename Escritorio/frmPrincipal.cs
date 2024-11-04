namespace Escritorio
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMSGrupos f = new frmABMSGrupos();
            f.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMSProveedores f = new frmABMSProveedores();
            f.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMSCategorias f = new frmABMSCategorias();
            f.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMSProductos f = new frmABMSProductos();
            f.Show();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMSPedidos f = new frmABMSPedidos();
            f.Show();
        }
    }
}