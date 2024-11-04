namespace Escritorio
{
    partial class frmAMCUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAMCUsuario));
            btnAceptar = new Button();
            btnCancelar = new Button();
            txtNomApe = new TextBox();
            txtUsuario = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtID = new TextBox();
            label4 = new Label();
            txtContraseña = new TextBox();
            label5 = new Label();
            txtGrupo = new TextBox();
            btnQuitarGrupo = new Button();
            btnConsultarGrupo = new Button();
            btnAsignarGrupo = new Button();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(308, 198);
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
            btnCancelar.Location = new Point(396, 198);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtNomApe
            // 
            txtNomApe.Location = new Point(126, 65);
            txtNomApe.Margin = new Padding(3, 2, 3, 2);
            txtNomApe.Name = "txtNomApe";
            txtNomApe.Size = new Size(246, 23);
            txtNomApe.TabIndex = 2;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(126, 93);
            txtUsuario.Margin = new Padding(3, 2, 3, 2);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(246, 23);
            txtUsuario.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 68);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 4;
            label1.Text = "Nombre Y Apellido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 96);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 5;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(102, 28);
            label3.Name = "label3";
            label3.Size = new Size(18, 15);
            label3.TabIndex = 6;
            label3.Text = "ID";
            // 
            // txtID
            // 
            txtID.Location = new Point(126, 25);
            txtID.Margin = new Padding(3, 2, 3, 2);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(66, 23);
            txtID.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(53, 123);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 9;
            label4.Text = "Contraseña";
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(126, 120);
            txtContraseña.Margin = new Padding(3, 2, 3, 2);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(246, 23);
            txtContraseña.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(80, 153);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 10;
            label5.Text = "Grupo";
            // 
            // txtGrupo
            // 
            txtGrupo.Location = new Point(126, 150);
            txtGrupo.Margin = new Padding(3, 2, 3, 2);
            txtGrupo.Name = "txtGrupo";
            txtGrupo.ReadOnly = true;
            txtGrupo.Size = new Size(246, 23);
            txtGrupo.TabIndex = 11;
            // 
            // btnQuitarGrupo
            // 
            btnQuitarGrupo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnQuitarGrupo.Image = (Image)resources.GetObject("btnQuitarGrupo.Image");
            btnQuitarGrupo.Location = new Point(436, 148);
            btnQuitarGrupo.Margin = new Padding(3, 2, 3, 2);
            btnQuitarGrupo.Name = "btnQuitarGrupo";
            btnQuitarGrupo.Size = new Size(31, 28);
            btnQuitarGrupo.TabIndex = 30;
            btnQuitarGrupo.UseVisualStyleBackColor = true;
            btnQuitarGrupo.Click += btnQuitarGrupo_Click;
            // 
            // btnConsultarGrupo
            // 
            btnConsultarGrupo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConsultarGrupo.Image = (Image)resources.GetObject("btnConsultarGrupo.Image");
            btnConsultarGrupo.Location = new Point(407, 148);
            btnConsultarGrupo.Margin = new Padding(3, 2, 3, 2);
            btnConsultarGrupo.Name = "btnConsultarGrupo";
            btnConsultarGrupo.Size = new Size(31, 28);
            btnConsultarGrupo.TabIndex = 29;
            btnConsultarGrupo.UseVisualStyleBackColor = true;
            btnConsultarGrupo.Click += btnConsultarGrupo_Click;
            // 
            // btnAsignarGrupo
            // 
            btnAsignarGrupo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAsignarGrupo.Image = (Image)resources.GetObject("btnAsignarGrupo.Image");
            btnAsignarGrupo.Location = new Point(378, 148);
            btnAsignarGrupo.Margin = new Padding(3, 2, 3, 2);
            btnAsignarGrupo.Name = "btnAsignarGrupo";
            btnAsignarGrupo.Size = new Size(31, 28);
            btnAsignarGrupo.TabIndex = 28;
            btnAsignarGrupo.UseVisualStyleBackColor = true;
            btnAsignarGrupo.Click += btnAsignarGrupo_Click;
            // 
            // frmAMCUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 229);
            Controls.Add(btnQuitarGrupo);
            Controls.Add(btnConsultarGrupo);
            Controls.Add(btnAsignarGrupo);
            Controls.Add(txtGrupo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtContraseña);
            Controls.Add(txtID);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtUsuario);
            Controls.Add(txtNomApe);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAMCUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuario";
            Load += frmAMCUsuario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtNomApe;
        private TextBox txtUsuario;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtID;
        private Label label4;
        private TextBox txtContraseña;
        private Label label5;
        private TextBox txtGrupo;
        private Button btnQuitarGrupo;
        private Button btnConsultarGrupo;
        private Button btnAsignarGrupo;
    }
}