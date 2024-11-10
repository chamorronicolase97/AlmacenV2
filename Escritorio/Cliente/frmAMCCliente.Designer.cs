namespace Escritorio
{
    partial class frmAMCCliente
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
            txtDenominacion = new TextBox();
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
            chkEmpleado = new CheckBox();
            chkPreferencial = new CheckBox();
            label7 = new Label();
            txtUsuario = new TextBox();
            label8 = new Label();
            txtContraseña = new TextBox();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(286, 265);
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
            btnCancelar.Location = new Point(374, 265);
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
            txtCUIT.Anchor = AnchorStyles.Top;
            txtCUIT.Location = new Point(100, 49);
            txtCUIT.Margin = new Padding(3, 2, 3, 2);
            txtCUIT.Name = "txtCUIT";
            txtCUIT.Size = new Size(181, 23);
            txtCUIT.TabIndex = 2;
            // 
            // txtDenominacion
            // 
            txtDenominacion.Anchor = AnchorStyles.Top;
            txtDenominacion.Location = new Point(100, 77);
            txtDenominacion.Margin = new Padding(3, 2, 3, 2);
            txtDenominacion.Name = "txtDenominacion";
            txtDenominacion.Size = new Size(181, 23);
            txtDenominacion.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(62, 52);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 4;
            label1.Text = "CUIT";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(12, 82);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 5;
            label2.Text = "Denominación";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(76, 23);
            label3.Name = "label3";
            label3.Size = new Size(18, 15);
            label3.TabIndex = 6;
            label3.Text = "ID";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Top;
            txtID.Enabled = false;
            txtID.Location = new Point(100, 20);
            txtID.Margin = new Padding(3, 2, 3, 2);
            txtID.Name = "txtID";
            txtID.Size = new Size(66, 23);
            txtID.TabIndex = 7;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(37, 107);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 9;
            label4.Text = "Domicilio";
            // 
            // txtDireccion
            // 
            txtDireccion.Anchor = AnchorStyles.Top;
            txtDireccion.Location = new Point(100, 104);
            txtDireccion.Margin = new Padding(3, 2, 3, 2);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(246, 23);
            txtDireccion.TabIndex = 8;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Location = new Point(64, 135);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 10;
            label5.Text = "Mail";
            // 
            // txtMail
            // 
            txtMail.Anchor = AnchorStyles.Top;
            txtMail.Location = new Point(100, 131);
            txtMail.Margin = new Padding(3, 2, 3, 2);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(246, 23);
            txtMail.TabIndex = 11;
            // 
            // txtTelefono
            // 
            txtTelefono.Anchor = AnchorStyles.Top;
            txtTelefono.Location = new Point(100, 160);
            txtTelefono.Margin = new Padding(3, 2, 3, 2);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(181, 23);
            txtTelefono.TabIndex = 12;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(42, 163);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 13;
            label6.Text = "Telefono";
            // 
            // chkEmpleado
            // 
            chkEmpleado.AutoSize = true;
            chkEmpleado.Location = new Point(40, 254);
            chkEmpleado.Name = "chkEmpleado";
            chkEmpleado.Size = new Size(79, 19);
            chkEmpleado.TabIndex = 14;
            chkEmpleado.Text = "Empleado";
            chkEmpleado.UseVisualStyleBackColor = true;
            // 
            // chkPreferencial
            // 
            chkPreferencial.AutoSize = true;
            chkPreferencial.Location = new Point(139, 254);
            chkPreferencial.Name = "chkPreferencial";
            chkPreferencial.Size = new Size(88, 19);
            chkPreferencial.TabIndex = 15;
            chkPreferencial.Text = "Preferencial";
            chkPreferencial.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Location = new Point(42, 193);
            label7.Name = "label7";
            label7.Size = new Size(47, 15);
            label7.TabIndex = 17;
            label7.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Anchor = AnchorStyles.Top;
            txtUsuario.Location = new Point(100, 190);
            txtUsuario.Margin = new Padding(3, 2, 3, 2);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(181, 23);
            txtUsuario.TabIndex = 16;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Location = new Point(27, 222);
            label8.Name = "label8";
            label8.Size = new Size(67, 15);
            label8.TabIndex = 19;
            label8.Text = "Contraseña";
            // 
            // txtContraseña
            // 
            txtContraseña.Anchor = AnchorStyles.Top;
            txtContraseña.Location = new Point(100, 219);
            txtContraseña.Margin = new Padding(3, 2, 3, 2);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(181, 23);
            txtContraseña.TabIndex = 18;
            // 
            // frmAMCCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 296);
            Controls.Add(label8);
            Controls.Add(txtContraseña);
            Controls.Add(label7);
            Controls.Add(txtUsuario);
            Controls.Add(chkPreferencial);
            Controls.Add(chkEmpleado);
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
            Controls.Add(txtDenominacion);
            Controls.Add(txtCUIT);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAMCCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cliente";
            Load += frmAMCCategoria_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtCUIT;
        private TextBox txtDenominacion;
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
        private CheckBox chkEmpleado;
        private CheckBox chkPreferencial;
        private Label label7;
        private TextBox txtUsuario;
        private Label label8;
        private TextBox txtContraseña;
    }
}