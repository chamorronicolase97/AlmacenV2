﻿namespace Escritorio
{
    partial class frmABMSPermisosGrupos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmABMSPermisosGrupos));
            dgvDatos = new DataGridView();
            splitContainer1 = new SplitContainer();
            btnActualizarFiltro = new Button();
            txtFiltro = new TextBox();
            pnlBotones = new Panel();
            btnConsultar = new Button();
            btnSeleccionar = new Button();
            btnBorrar = new Button();
            btnCrear = new Button();
            btnModificar = new Button();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Location = new Point(3, 3);
            dgvDatos.Margin = new Padding(3, 2, 3, 2);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.RowTemplate.Height = 29;
            dgvDatos.Size = new Size(656, 291);
            dgvDatos.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnActualizarFiltro);
            splitContainer1.Panel1.Controls.Add(txtFiltro);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pnlBotones);
            splitContainer1.Panel2.Controls.Add(dgvDatos);
            splitContainer1.Size = new Size(705, 361);
            splitContainer1.SplitterDistance = 62;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 1;
            // 
            // btnActualizarFiltro
            // 
            btnActualizarFiltro.Image = (Image)resources.GetObject("btnActualizarFiltro.Image");
            btnActualizarFiltro.Location = new Point(665, 12);
            btnActualizarFiltro.Margin = new Padding(3, 2, 3, 2);
            btnActualizarFiltro.Name = "btnActualizarFiltro";
            btnActualizarFiltro.Size = new Size(35, 35);
            btnActualizarFiltro.TabIndex = 10;
            toolTip1.SetToolTip(btnActualizarFiltro, "Nuevo");
            btnActualizarFiltro.UseVisualStyleBackColor = true;
            btnActualizarFiltro.Click += btnActualizarFiltro_Click;
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(10, 24);
            txtFiltro.Margin = new Padding(3, 2, 3, 2);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(165, 23);
            txtFiltro.TabIndex = 3;
            toolTip1.SetToolTip(txtFiltro, "Aplica a Descripcion, Codigo de Barra, Costo, Proveedor y Categoria ");
            txtFiltro.TextChanged += txtFiltro_TextChanged;
            // 
            // pnlBotones
            // 
            pnlBotones.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlBotones.Controls.Add(btnConsultar);
            pnlBotones.Controls.Add(btnSeleccionar);
            pnlBotones.Controls.Add(btnBorrar);
            pnlBotones.Controls.Add(btnCrear);
            pnlBotones.Controls.Add(btnModificar);
            pnlBotones.Location = new Point(662, 3);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(40, 205);
            pnlBotones.TabIndex = 12;
            // 
            // btnConsultar
            // 
            btnConsultar.Image = (Image)resources.GetObject("btnConsultar.Image");
            btnConsultar.Location = new Point(3, 2);
            btnConsultar.Margin = new Padding(3, 2, 3, 2);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(35, 35);
            btnConsultar.TabIndex = 16;
            toolTip1.SetToolTip(btnConsultar, "Nuevo");
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSeleccionar.Image = (Image)resources.GetObject("btnSeleccionar.Image");
            btnSeleccionar.Location = new Point(2, 158);
            btnSeleccionar.Margin = new Padding(3, 2, 3, 2);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(35, 35);
            btnSeleccionar.TabIndex = 12;
            toolTip1.SetToolTip(btnSeleccionar, "Seleccionar");
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Image = (Image)resources.GetObject("btnBorrar.Image");
            btnBorrar.Location = new Point(2, 119);
            btnBorrar.Margin = new Padding(3, 2, 3, 2);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(35, 35);
            btnBorrar.TabIndex = 11;
            toolTip1.SetToolTip(btnBorrar, "Eliminar");
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnCrear
            // 
            btnCrear.Image = (Image)resources.GetObject("btnCrear.Image");
            btnCrear.Location = new Point(2, 41);
            btnCrear.Margin = new Padding(3, 2, 3, 2);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(35, 35);
            btnCrear.TabIndex = 9;
            toolTip1.SetToolTip(btnCrear, "Nuevo");
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnModificar
            // 
            btnModificar.Image = (Image)resources.GetObject("btnModificar.Image");
            btnModificar.Location = new Point(2, 80);
            btnModificar.Margin = new Padding(3, 2, 3, 2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(35, 35);
            btnModificar.TabIndex = 10;
            toolTip1.SetToolTip(btnModificar, "Modificar");
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // frmABMSPermisosGrupos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 361);
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(600, 400);
            Name = "frmABMSPermisosGrupos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PermisosGrupos";
            Load += frmABMSPermisosGrupos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvDatos;
        private SplitContainer splitContainer1;
        private TextBox txtFiltro;
        private Button btnBorrar;
        private Button btnModificar;
        private Button btnCrear;
        private Panel pnlBotones;
        private Button btnSeleccionar;
        private ToolTip toolTip1;
        private Button btnActualizarFiltro;
        private Button btnConsultar;
    }
}