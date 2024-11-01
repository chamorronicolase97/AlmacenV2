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
            f.ShowDialog();
        }
    }
}