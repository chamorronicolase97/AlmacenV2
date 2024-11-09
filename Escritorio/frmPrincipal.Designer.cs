namespace Escritorio
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            principalToolStripMenuItem = new ToolStripMenuItem();
            cambiarUsuarioToolStripMenuItem = new ToolStripMenuItem();
            reiniciarToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            depositoToolStripMenuItem = new ToolStripMenuItem();
            recepciónToolStripMenuItem = new ToolStripMenuItem();
            compraToolStripMenuItem = new ToolStripMenuItem();
            pedidosToolStripMenuItem = new ToolStripMenuItem();
            ventaToolStripMenuItem = new ToolStripMenuItem();
            principalDeVentaToolStripMenuItem = new ToolStripMenuItem();
            administraciónToolStripMenuItem = new ToolStripMenuItem();
            categoriasToolStripMenuItem = new ToolStripMenuItem();
            proveedoresToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            costosProductosToolStripMenuItem = new ToolStripMenuItem();
            configuraciónToolStripMenuItem = new ToolStripMenuItem();
            gruposToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            permisosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            panel1 = new Panel();
            lblBienvenido = new Label();
            monthCalendar1 = new MonthCalendar();
            asignarPermisosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // principalToolStripMenuItem
            // 
            principalToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cambiarUsuarioToolStripMenuItem, reiniciarToolStripMenuItem, salirToolStripMenuItem });
            principalToolStripMenuItem.Name = "principalToolStripMenuItem";
            principalToolStripMenuItem.Size = new Size(65, 20);
            principalToolStripMenuItem.Text = "Principal";
            // 
            // cambiarUsuarioToolStripMenuItem
            // 
            cambiarUsuarioToolStripMenuItem.Name = "cambiarUsuarioToolStripMenuItem";
            cambiarUsuarioToolStripMenuItem.Size = new Size(162, 22);
            cambiarUsuarioToolStripMenuItem.Text = "Cambiar Usuario";
            cambiarUsuarioToolStripMenuItem.Click += cambiarUsuarioToolStripMenuItem_Click;
            // 
            // reiniciarToolStripMenuItem
            // 
            reiniciarToolStripMenuItem.Name = "reiniciarToolStripMenuItem";
            reiniciarToolStripMenuItem.Size = new Size(162, 22);
            reiniciarToolStripMenuItem.Text = "Reiniciar";
            reiniciarToolStripMenuItem.Click += reiniciarToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(162, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // depositoToolStripMenuItem
            // 
            depositoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { recepciónToolStripMenuItem });
            depositoToolStripMenuItem.Name = "depositoToolStripMenuItem";
            depositoToolStripMenuItem.Size = new Size(66, 20);
            depositoToolStripMenuItem.Text = "Deposito";
            // 
            // recepciónToolStripMenuItem
            // 
            recepciónToolStripMenuItem.Name = "recepciónToolStripMenuItem";
            recepciónToolStripMenuItem.Size = new Size(129, 22);
            recepciónToolStripMenuItem.Text = "Recepción";
            recepciónToolStripMenuItem.Click += recepciónToolStripMenuItem_Click;
            // 
            // compraToolStripMenuItem
            // 
            compraToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pedidosToolStripMenuItem });
            compraToolStripMenuItem.Name = "compraToolStripMenuItem";
            compraToolStripMenuItem.Size = new Size(62, 20);
            compraToolStripMenuItem.Text = "Compra";
            // 
            // pedidosToolStripMenuItem
            // 
            pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            pedidosToolStripMenuItem.Size = new Size(116, 22);
            pedidosToolStripMenuItem.Text = "Pedidos";
            pedidosToolStripMenuItem.Click += pedidosToolStripMenuItem_Click;
            // 
            // ventaToolStripMenuItem
            // 
            ventaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { principalDeVentaToolStripMenuItem });
            ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            ventaToolStripMenuItem.Size = new Size(53, 20);
            ventaToolStripMenuItem.Text = "Ventas";
            // 
            // principalDeVentaToolStripMenuItem
            // 
            principalDeVentaToolStripMenuItem.Image = (Image)resources.GetObject("principalDeVentaToolStripMenuItem.Image");
            principalDeVentaToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            principalDeVentaToolStripMenuItem.Name = "principalDeVentaToolStripMenuItem";
            principalDeVentaToolStripMenuItem.Size = new Size(168, 22);
            principalDeVentaToolStripMenuItem.Text = "Principal de Venta";
            // 
            // administraciónToolStripMenuItem
            // 
            administraciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { categoriasToolStripMenuItem, proveedoresToolStripMenuItem, productosToolStripMenuItem, costosProductosToolStripMenuItem });
            administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            administraciónToolStripMenuItem.Size = new Size(100, 20);
            administraciónToolStripMenuItem.Text = "Administración";
            // 
            // categoriasToolStripMenuItem
            // 
            categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            categoriasToolStripMenuItem.Size = new Size(167, 22);
            categoriasToolStripMenuItem.Text = "Categorias";
            categoriasToolStripMenuItem.Click += categoriasToolStripMenuItem_Click;
            // 
            // proveedoresToolStripMenuItem
            // 
            proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            proveedoresToolStripMenuItem.Size = new Size(167, 22);
            proveedoresToolStripMenuItem.Text = "Proveedores";
            proveedoresToolStripMenuItem.Click += proveedoresToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(167, 22);
            productosToolStripMenuItem.Text = "Productos";
            productosToolStripMenuItem.Click += productosToolStripMenuItem_Click;
            // 
            // costosProductosToolStripMenuItem
            // 
            costosProductosToolStripMenuItem.Name = "costosProductosToolStripMenuItem";
            costosProductosToolStripMenuItem.Size = new Size(167, 22);
            costosProductosToolStripMenuItem.Text = "Costos Productos";
            costosProductosToolStripMenuItem.Click += costosProductosToolStripMenuItem_Click;
            // 
            // configuraciónToolStripMenuItem
            // 
            configuraciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gruposToolStripMenuItem, usuariosToolStripMenuItem, permisosToolStripMenuItem, asignarPermisosToolStripMenuItem });
            configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            configuraciónToolStripMenuItem.Size = new Size(95, 20);
            configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // gruposToolStripMenuItem
            // 
            gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            gruposToolStripMenuItem.Size = new Size(180, 22);
            gruposToolStripMenuItem.Text = "Grupos";
            gruposToolStripMenuItem.Click += gruposToolStripMenuItem_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(180, 22);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // permisosToolStripMenuItem
            // 
            permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            permisosToolStripMenuItem.Size = new Size(180, 22);
            permisosToolStripMenuItem.Text = "Permisos";
            permisosToolStripMenuItem.Click += permisosToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { principalToolStripMenuItem, depositoToolStripMenuItem, compraToolStripMenuItem, ventaToolStripMenuItem, administraciónToolStripMenuItem, configuraciónToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblBienvenido);
            panel1.Location = new Point(552, 179);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(248, 100);
            panel1.TabIndex = 4;
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblBienvenido.Location = new Point(15, 17);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(74, 15);
            lblBienvenido.TabIndex = 0;
            lblBienvenido.Text = "Bienvenid@";
            // 
            // monthCalendar1
            // 
            monthCalendar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            monthCalendar1.Location = new Point(552, 285);
            monthCalendar1.Margin = new Padding(8, 7, 8, 7);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 3;
            // 
            // asignarPermisosToolStripMenuItem
            // 
            asignarPermisosToolStripMenuItem.Name = "asignarPermisosToolStripMenuItem";
            asignarPermisosToolStripMenuItem.Size = new Size(180, 22);
            asignarPermisosToolStripMenuItem.Text = "Asignar Permisos";
            asignarPermisosToolStripMenuItem.Click += asignarPermisosToolStripMenuItem_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(monthCalendar1);
            Controls.Add(menuStrip1);
            Name = "frmPrincipal";
            Text = "Menu Principal";
            Load += frmPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem principalToolStripMenuItem;
        private ToolStripMenuItem cambiarUsuarioToolStripMenuItem;
        private ToolStripMenuItem reiniciarToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem depositoToolStripMenuItem;
        private ToolStripMenuItem recepciónToolStripMenuItem;
        private ToolStripMenuItem compraToolStripMenuItem;
        private ToolStripMenuItem pedidosToolStripMenuItem;
        private ToolStripMenuItem ventaToolStripMenuItem;
        private ToolStripMenuItem principalDeVentaToolStripMenuItem;
        private ToolStripMenuItem administraciónToolStripMenuItem;
        private ToolStripMenuItem categoriasToolStripMenuItem;
        private ToolStripMenuItem proveedoresToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem costosProductosToolStripMenuItem;
        private ToolStripMenuItem configuraciónToolStripMenuItem;
        private ToolStripMenuItem gruposToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem permisosToolStripMenuItem;
        private MenuStrip menuStrip1;
        private Panel panel1;
        private Label lblBienvenido;
        protected MonthCalendar monthCalendar1;
        private ToolStripMenuItem asignarPermisosToolStripMenuItem;
    }
}