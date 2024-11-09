namespace Escritorio    
{
    partial class frmAMCPermisoGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAMCPermisoGrupo));
            btnAceptar = new Button();
            btnCancelar = new Button();
            btnQuitarPermiso = new Button();
            btnConsultarPermiso = new Button();
            btnAsignarPermiso = new Button();
            txtPermiso = new TextBox();
            btnQuitarGrupo = new Button();
            btnConsultarGrupo = new Button();
            btnAsignarGrupo = new Button();
            label6 = new Label();
            txtGrupo = new TextBox();
            label5 = new Label();
            txtID = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(180, 136);
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
            btnCancelar.Location = new Point(268, 136);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnQuitarPermiso
            // 
            btnQuitarPermiso.Anchor = AnchorStyles.None;
            btnQuitarPermiso.Image = (Image)resources.GetObject("btnQuitarPermiso.Image");
            btnQuitarPermiso.Location = new Point(298, 56);
            btnQuitarPermiso.Margin = new Padding(3, 2, 3, 2);
            btnQuitarPermiso.Name = "btnQuitarPermiso";
            btnQuitarPermiso.Size = new Size(31, 28);
            btnQuitarPermiso.TabIndex = 49;
            btnQuitarPermiso.UseVisualStyleBackColor = true;
            btnQuitarPermiso.Click += btnQuitarPermiso_Click;
            // 
            // btnConsultarPermiso
            // 
            btnConsultarPermiso.Anchor = AnchorStyles.None;
            btnConsultarPermiso.Image = (Image)resources.GetObject("btnConsultarPermiso.Image");
            btnConsultarPermiso.Location = new Point(269, 56);
            btnConsultarPermiso.Margin = new Padding(3, 2, 3, 2);
            btnConsultarPermiso.Name = "btnConsultarPermiso";
            btnConsultarPermiso.Size = new Size(31, 28);
            btnConsultarPermiso.TabIndex = 48;
            btnConsultarPermiso.UseVisualStyleBackColor = true;
            btnConsultarPermiso.Click += btnConsultarPermiso_Click;
            // 
            // btnAsignarPermiso
            // 
            btnAsignarPermiso.Anchor = AnchorStyles.None;
            btnAsignarPermiso.Image = (Image)resources.GetObject("btnAsignarPermiso.Image");
            btnAsignarPermiso.Location = new Point(240, 56);
            btnAsignarPermiso.Margin = new Padding(3, 2, 3, 2);
            btnAsignarPermiso.Name = "btnAsignarPermiso";
            btnAsignarPermiso.Size = new Size(31, 28);
            btnAsignarPermiso.TabIndex = 47;
            btnAsignarPermiso.UseVisualStyleBackColor = true;
            btnAsignarPermiso.Click += btnAsignarPermiso_Click;
            // 
            // txtPermiso
            // 
            txtPermiso.Location = new Point(81, 59);
            txtPermiso.Margin = new Padding(3, 2, 3, 2);
            txtPermiso.Name = "txtPermiso";
            txtPermiso.Size = new Size(154, 23);
            txtPermiso.TabIndex = 46;
            // 
            // btnQuitarGrupo
            // 
            btnQuitarGrupo.Anchor = AnchorStyles.None;
            btnQuitarGrupo.Image = (Image)resources.GetObject("btnQuitarGrupo.Image");
            btnQuitarGrupo.Location = new Point(298, 86);
            btnQuitarGrupo.Margin = new Padding(3, 2, 3, 2);
            btnQuitarGrupo.Name = "btnQuitarGrupo";
            btnQuitarGrupo.Size = new Size(31, 28);
            btnQuitarGrupo.TabIndex = 45;
            btnQuitarGrupo.UseVisualStyleBackColor = true;
            btnQuitarGrupo.Click += btnQuitarGrupo_Click;
            // 
            // btnConsultarGrupo
            // 
            btnConsultarGrupo.Anchor = AnchorStyles.None;
            btnConsultarGrupo.Image = (Image)resources.GetObject("btnConsultarGrupo.Image");
            btnConsultarGrupo.Location = new Point(269, 86);
            btnConsultarGrupo.Margin = new Padding(3, 2, 3, 2);
            btnConsultarGrupo.Name = "btnConsultarGrupo";
            btnConsultarGrupo.Size = new Size(31, 28);
            btnConsultarGrupo.TabIndex = 44;
            btnConsultarGrupo.UseVisualStyleBackColor = true;
            btnConsultarGrupo.Click += btnConsultarGrupo_Click;
            // 
            // btnAsignarGrupo
            // 
            btnAsignarGrupo.Anchor = AnchorStyles.None;
            btnAsignarGrupo.Image = (Image)resources.GetObject("btnAsignarGrupo.Image");
            btnAsignarGrupo.Location = new Point(240, 86);
            btnAsignarGrupo.Margin = new Padding(3, 2, 3, 2);
            btnAsignarGrupo.Name = "btnAsignarGrupo";
            btnAsignarGrupo.Size = new Size(31, 28);
            btnAsignarGrupo.TabIndex = 43;
            btnAsignarGrupo.UseVisualStyleBackColor = true;
            btnAsignarGrupo.Click += btnAsignarGrupo_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 93);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 42;
            label6.Text = "Grupo";
            // 
            // txtGrupo
            // 
            txtGrupo.Location = new Point(81, 88);
            txtGrupo.Margin = new Padding(3, 2, 3, 2);
            txtGrupo.Name = "txtGrupo";
            txtGrupo.Size = new Size(154, 23);
            txtGrupo.TabIndex = 41;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 63);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 40;
            label5.Text = "Permiso";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Bottom;
            txtID.Location = new Point(81, 32);
            txtID.Margin = new Padding(3, 2, 3, 2);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(66, 23);
            txtID.TabIndex = 39;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Location = new Point(53, 34);
            label3.Name = "label3";
            label3.Size = new Size(18, 15);
            label3.TabIndex = 38;
            label3.Text = "ID";
            // 
            // frmAMCPermisoGrupo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 167);
            Controls.Add(btnQuitarPermiso);
            Controls.Add(btnConsultarPermiso);
            Controls.Add(btnAsignarPermiso);
            Controls.Add(txtPermiso);
            Controls.Add(btnQuitarGrupo);
            Controls.Add(btnConsultarGrupo);
            Controls.Add(btnAsignarGrupo);
            Controls.Add(label6);
            Controls.Add(txtGrupo);
            Controls.Add(label5);
            Controls.Add(txtID);
            Controls.Add(label3);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "frmAMCPermisoGrupo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PermisoGrupo";
            Load += frmAMCCategoria_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private Button btnQuitarPermiso;
        private Button btnConsultarPermiso;
        private Button btnAsignarPermiso;
        private TextBox txtPermiso;
        private Button btnQuitarGrupo;
        private Button btnConsultarGrupo;
        private Button btnAsignarGrupo;
        private Label label6;
        private TextBox txtGrupo;
        private Label label5;
        private TextBox txtID;
        private Label label3;
    }
}