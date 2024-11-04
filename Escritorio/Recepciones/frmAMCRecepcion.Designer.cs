namespace Escritorio
{
    partial class frmAMCRecepcion
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
            btnAceptar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label3 = new Label();
            txtNroPedido = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            fontDialog1 = new FontDialog();
            panel1 = new Panel();
            vScrollBar1 = new VScrollBar();
            dgvDetalles = new DataGridView();
            btnAsignar = new Button();
            dtpFechaEntrega = new DateTimePicker();
            txtRecepcionID = new TextBox();
            label2 = new Label();
            txtProveedor = new TextBox();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(464, 269);
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
            btnCancelar.Location = new Point(552, 269);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Location = new Point(44, 73);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 4;
            label1.Text = "Fecha Entrega";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Location = new Point(53, 46);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 6;
            label3.Text = "Nro. Pedido";
            // 
            // txtNroPedido
            // 
            txtNroPedido.Anchor = AnchorStyles.Bottom;
            txtNroPedido.Enabled = false;
            txtNroPedido.Location = new Point(129, 43);
            txtNroPedido.Margin = new Padding(3, 2, 3, 2);
            txtNroPedido.Name = "txtNroPedido";
            txtNroPedido.ReadOnly = true;
            txtNroPedido.Size = new Size(98, 23);
            txtNroPedido.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.Controls.Add(vScrollBar1);
            panel1.Controls.Add(dgvDetalles);
            panel1.Location = new Point(41, 108);
            panel1.Name = "panel1";
            panel1.Size = new Size(544, 144);
            panel1.TabIndex = 8;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(525, 0);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(19, 144);
            vScrollBar1.TabIndex = 1;
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(0, 0);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.RowTemplate.Height = 25;
            dgvDetalles.Size = new Size(571, 137);
            dgvDetalles.TabIndex = 0;
            // 
            // btnAsignar
            // 
            btnAsignar.Location = new Point(464, 79);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(121, 23);
            btnAsignar.TabIndex = 9;
            btnAsignar.Text = "Añadir Producto";
            btnAsignar.UseVisualStyleBackColor = true;
            btnAsignar.Click += btnAsignar_Click;
            // 
            // dtpFechaEntrega
            // 
            dtpFechaEntrega.CustomFormat = "";
            dtpFechaEntrega.Format = DateTimePickerFormat.Short;
            dtpFechaEntrega.Location = new Point(129, 71);
            dtpFechaEntrega.Name = "dtpFechaEntrega";
            dtpFechaEntrega.Size = new Size(98, 23);
            dtpFechaEntrega.TabIndex = 10;
            // 
            // txtRecepcionID
            // 
            txtRecepcionID.Anchor = AnchorStyles.Bottom;
            txtRecepcionID.Enabled = false;
            txtRecepcionID.Location = new Point(129, 11);
            txtRecepcionID.Margin = new Padding(3, 2, 3, 2);
            txtRecepcionID.Name = "txtRecepcionID";
            txtRecepcionID.ReadOnly = true;
            txtRecepcionID.Size = new Size(98, 23);
            txtRecepcionID.TabIndex = 12;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Location = new Point(47, 14);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 11;
            label2.Text = "Recepción ID";
            // 
            // txtProveedor
            // 
            txtProveedor.Anchor = AnchorStyles.Bottom;
            txtProveedor.Enabled = false;
            txtProveedor.Location = new Point(345, 43);
            txtProveedor.Margin = new Padding(3, 2, 3, 2);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.ReadOnly = true;
            txtProveedor.Size = new Size(135, 23);
            txtProveedor.TabIndex = 14;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Location = new Point(279, 46);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 13;
            label4.Text = "Proveedor";
            // 
            // frmAMCRecepcion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 302);
            Controls.Add(txtProveedor);
            Controls.Add(label4);
            Controls.Add(txtRecepcionID);
            Controls.Add(label2);
            Controls.Add(dtpFechaEntrega);
            Controls.Add(btnAsignar);
            Controls.Add(panel1);
            Controls.Add(txtNroPedido);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "frmAMCRecepcion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recepcion";
            Load += frmAMCRecepcion_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private Label label1;
        private Label label3;
        private TextBox txtNroPedido;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private FontDialog fontDialog1;
        private Panel panel1;
        private DataGridView dgvDetalles;
        private Button btnAsignar;
        private DateTimePicker dtpFechaEntrega;
        private VScrollBar vScrollBar1;
        private TextBox txtRecepcionID;
        private Label label2;
        private TextBox txtProveedor;
        private Label label4;
    }
}