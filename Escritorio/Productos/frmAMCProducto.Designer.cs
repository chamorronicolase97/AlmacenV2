namespace Escritorio
{
    partial class frmAMCProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAMCProducto));
            btnAceptar = new Button();
            btnCancelar = new Button();
            txtDescripcion = new TextBox();
            txtCosto = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtID = new TextBox();
            label4 = new Label();
            txtCodBarra = new TextBox();
            label5 = new Label();
            label6 = new Label();
            txtProveedor = new TextBox();
            btnQuitarProveedor = new Button();
            btnConsultarProveedor = new Button();
            btnAsignarProveedor = new Button();
            toolTip1 = new ToolTip(components);
            btnQuitarCategoria = new Button();
            btnConsultarCategoria = new Button();
            btnAsignarCategoria = new Button();
            txtCategoria = new TextBox();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(340, 202);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(82, 22);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(428, 202);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(102, 43);
            txtDescripcion.Margin = new Padding(3, 2, 3, 2);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(246, 23);
            txtDescripcion.TabIndex = 2;
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(102, 71);
            txtCosto.Margin = new Padding(3, 2, 3, 2);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(82, 23);
            txtCosto.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 46);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 4;
            label1.Text = "Descripcion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 74);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 5;
            label2.Text = "Costo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 17);
            label3.Name = "label3";
            label3.Size = new Size(18, 15);
            label3.TabIndex = 6;
            label3.Text = "ID";
            // 
            // txtID
            // 
            txtID.Location = new Point(102, 14);
            txtID.Margin = new Padding(3, 2, 3, 2);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(66, 23);
            txtID.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 101);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 9;
            label4.Text = "Cod. Barra";
            // 
            // txtCodBarra
            // 
            txtCodBarra.Location = new Point(102, 98);
            txtCodBarra.Margin = new Padding(3, 2, 3, 2);
            txtCodBarra.Name = "txtCodBarra";
            txtCodBarra.Size = new Size(246, 23);
            txtCodBarra.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 131);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 10;
            label5.Text = "Categoria";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 159);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 13;
            label6.Text = "Proveedor";
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(102, 156);
            txtProveedor.Margin = new Padding(3, 2, 3, 2);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(246, 23);
            txtProveedor.TabIndex = 12;
            // 
            // btnQuitarProveedor
            // 
            btnQuitarProveedor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnQuitarProveedor.Image = (Image)resources.GetObject("btnQuitarProveedor.Image");
            btnQuitarProveedor.Location = new Point(411, 154);
            btnQuitarProveedor.Margin = new Padding(3, 2, 3, 2);
            btnQuitarProveedor.Name = "btnQuitarProveedor";
            btnQuitarProveedor.Size = new Size(31, 28);
            btnQuitarProveedor.TabIndex = 23;
            toolTip1.SetToolTip(btnQuitarProveedor, "Quitar");
            btnQuitarProveedor.UseVisualStyleBackColor = true;
            btnQuitarProveedor.Click += btnQuitarProveedor_Click;
            // 
            // btnConsultarProveedor
            // 
            btnConsultarProveedor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConsultarProveedor.Image = (Image)resources.GetObject("btnConsultarProveedor.Image");
            btnConsultarProveedor.Location = new Point(382, 154);
            btnConsultarProveedor.Margin = new Padding(3, 2, 3, 2);
            btnConsultarProveedor.Name = "btnConsultarProveedor";
            btnConsultarProveedor.Size = new Size(31, 28);
            btnConsultarProveedor.TabIndex = 22;
            toolTip1.SetToolTip(btnConsultarProveedor, "Consultar");
            btnConsultarProveedor.UseVisualStyleBackColor = true;
            btnConsultarProveedor.Click += btnConsultarProveedor_Click;
            // 
            // btnAsignarProveedor
            // 
            btnAsignarProveedor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAsignarProveedor.Image = (Image)resources.GetObject("btnAsignarProveedor.Image");
            btnAsignarProveedor.Location = new Point(353, 154);
            btnAsignarProveedor.Margin = new Padding(3, 2, 3, 2);
            btnAsignarProveedor.Name = "btnAsignarProveedor";
            btnAsignarProveedor.Size = new Size(31, 28);
            btnAsignarProveedor.TabIndex = 21;
            toolTip1.SetToolTip(btnAsignarProveedor, "Asignar");
            btnAsignarProveedor.UseVisualStyleBackColor = true;
            btnAsignarProveedor.Click += btnAsignarProveedor_Click;
            // 
            // btnQuitarCategoria
            // 
            btnQuitarCategoria.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnQuitarCategoria.Image = (Image)resources.GetObject("btnQuitarCategoria.Image");
            btnQuitarCategoria.Location = new Point(411, 124);
            btnQuitarCategoria.Margin = new Padding(3, 2, 3, 2);
            btnQuitarCategoria.Name = "btnQuitarCategoria";
            btnQuitarCategoria.Size = new Size(31, 28);
            btnQuitarCategoria.TabIndex = 27;
            toolTip1.SetToolTip(btnQuitarCategoria, "Quitar");
            btnQuitarCategoria.UseVisualStyleBackColor = true;
            btnQuitarCategoria.Click += btnQuitarCategoria_Click;
            // 
            // btnConsultarCategoria
            // 
            btnConsultarCategoria.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConsultarCategoria.Image = (Image)resources.GetObject("btnConsultarCategoria.Image");
            btnConsultarCategoria.Location = new Point(382, 124);
            btnConsultarCategoria.Margin = new Padding(3, 2, 3, 2);
            btnConsultarCategoria.Name = "btnConsultarCategoria";
            btnConsultarCategoria.Size = new Size(31, 28);
            btnConsultarCategoria.TabIndex = 26;
            toolTip1.SetToolTip(btnConsultarCategoria, "Consultar");
            btnConsultarCategoria.UseVisualStyleBackColor = true;
            btnConsultarCategoria.Click += btnConsultarCategoria_Click;
            // 
            // btnAsignarCategoria
            // 
            btnAsignarCategoria.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAsignarCategoria.Image = (Image)resources.GetObject("btnAsignarCategoria.Image");
            btnAsignarCategoria.Location = new Point(353, 124);
            btnAsignarCategoria.Margin = new Padding(3, 2, 3, 2);
            btnAsignarCategoria.Name = "btnAsignarCategoria";
            btnAsignarCategoria.Size = new Size(31, 28);
            btnAsignarCategoria.TabIndex = 25;
            toolTip1.SetToolTip(btnAsignarCategoria, "Asignar");
            btnAsignarCategoria.UseVisualStyleBackColor = true;
            btnAsignarCategoria.Click += btnAsignarCategoria_Click;
            // 
            // txtCategoria
            // 
            txtCategoria.Location = new Point(102, 127);
            txtCategoria.Margin = new Padding(3, 2, 3, 2);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.Size = new Size(246, 23);
            txtCategoria.TabIndex = 24;
            // 
            // frmAMCProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 233);
            Controls.Add(btnQuitarCategoria);
            Controls.Add(btnConsultarCategoria);
            Controls.Add(btnAsignarCategoria);
            Controls.Add(txtCategoria);
            Controls.Add(btnQuitarProveedor);
            Controls.Add(btnConsultarProveedor);
            Controls.Add(btnAsignarProveedor);
            Controls.Add(label6);
            Controls.Add(txtProveedor);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtCodBarra);
            Controls.Add(txtID);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCosto);
            Controls.Add(txtDescripcion);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAMCProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Producto";
            Load += frmAMCCategoria_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtDescripcion;
        private TextBox txtCosto;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtID;
        private Label label4;
        private TextBox txtCodBarra;
        private Label label5;
        private Label label6;
        private TextBox txtProveedor;
        private Button btnQuitarProveedor;
        private Button btnConsultarProveedor;
        private Button btnAsignarProveedor;
        private ToolTip toolTip1;
        private Button btnQuitarCategoria;
        private Button btnConsultarCategoria;
        private Button btnAsignarCategoria;
        private TextBox txtCategoria;
    }
}