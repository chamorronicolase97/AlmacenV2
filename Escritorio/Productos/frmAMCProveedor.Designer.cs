namespace Escritorio
{
    partial class frmAMCProveedor
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
            txtCUIT = new TextBox();
            txtRazonSocial = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtID = new TextBox();
            label4 = new Label();
            txtDireccion = new TextBox();
            label5 = new Label();
            txtMail = new TextBox();
            txtTelefono = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(291, 219);
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
            btnCancelar.Location = new Point(379, 219);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtCUIT
            // 
            txtCUIT.Anchor = AnchorStyles.Bottom;
            txtCUIT.Location = new Point(102, 57);
            txtCUIT.Margin = new Padding(3, 2, 3, 2);
            txtCUIT.Name = "txtCUIT";
            txtCUIT.Size = new Size(181, 23);
            txtCUIT.TabIndex = 2;
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Anchor = AnchorStyles.Bottom;
            txtRazonSocial.Location = new Point(102, 85);
            txtRazonSocial.Margin = new Padding(3, 2, 3, 2);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(181, 23);
            txtRazonSocial.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Location = new Point(64, 60);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 4;
            label1.Text = "CUIT";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Location = new Point(23, 90);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 5;
            label2.Text = "Razon Social";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Location = new Point(78, 31);
            label3.Name = "label3";
            label3.Size = new Size(18, 15);
            label3.TabIndex = 6;
            label3.Text = "ID";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Bottom;
            txtID.Enabled = false;
            txtID.Location = new Point(102, 28);
            txtID.Margin = new Padding(3, 2, 3, 2);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(66, 23);
            txtID.TabIndex = 7;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Location = new Point(39, 115);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 9;
            label4.Text = "Direccion";
            // 
            // txtDireccion
            // 
            txtDireccion.Anchor = AnchorStyles.Bottom;
            txtDireccion.Location = new Point(102, 112);
            txtDireccion.Margin = new Padding(3, 2, 3, 2);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(246, 23);
            txtDireccion.TabIndex = 8;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom;
            label5.AutoSize = true;
            label5.Location = new Point(66, 143);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 10;
            label5.Text = "Mail";
            // 
            // txtMail
            // 
            txtMail.Anchor = AnchorStyles.Bottom;
            txtMail.Location = new Point(102, 139);
            txtMail.Margin = new Padding(3, 2, 3, 2);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(246, 23);
            txtMail.TabIndex = 11;
            // 
            // txtTelefono
            // 
            txtTelefono.Anchor = AnchorStyles.Bottom;
            txtTelefono.Location = new Point(102, 168);
            txtTelefono.Margin = new Padding(3, 2, 3, 2);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(181, 23);
            txtTelefono.TabIndex = 12;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom;
            label6.AutoSize = true;
            label6.Location = new Point(44, 171);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 13;
            label6.Text = "Telefono";
            // 
            // frmAMCProveedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 250);
            Controls.Add(label6);
            Controls.Add(txtTelefono);
            Controls.Add(txtMail);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtDireccion);
            Controls.Add(txtID);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtRazonSocial);
            Controls.Add(txtCUIT);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAMCProveedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proveedor";
            Load += frmAMCCategoria_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtCUIT;
        private TextBox txtRazonSocial;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtID;
        private Label label4;
        private TextBox txtDireccion;
        private Label label5;
        private TextBox txtMail;
        private TextBox txtTelefono;
        private Label label6;
    }
}