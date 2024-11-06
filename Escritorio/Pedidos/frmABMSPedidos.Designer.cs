namespace Escritorio
{
    partial class frmABMSPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmABMSPedidos));
            dgvDatos = new DataGridView();
            splitContainer1 = new SplitContainer();
            txtFiltro = new TextBox();
            gbEstados = new GroupBox();
            pnlCancelado = new Panel();
            pnlControlado = new Panel();
            label5 = new Label();
            label4 = new Label();
            pnlRecibido = new Panel();
            label3 = new Label();
            pnlConfirmado = new Panel();
            label2 = new Label();
            pnlEnEdicion = new Panel();
            label1 = new Label();
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
            gbEstados.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Location = new Point(3, 4);
            dgvDatos.Margin = new Padding(3, 2, 3, 2);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.RowTemplate.Height = 29;
            dgvDatos.Size = new Size(535, 291);
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
            splitContainer1.Panel1.Controls.Add(txtFiltro);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(gbEstados);
            splitContainer1.Panel2.Controls.Add(pnlBotones);
            splitContainer1.Panel2.Controls.Add(dgvDatos);
            splitContainer1.Size = new Size(584, 435);
            splitContainer1.SplitterDistance = 75;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 1;
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(10, 24);
            txtFiltro.Margin = new Padding(3, 2, 3, 2);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(165, 23);
            txtFiltro.TabIndex = 3;
            txtFiltro.TextChanged += txtFiltro_TextChanged;
            // 
            // gbEstados
            // 
            gbEstados.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbEstados.Controls.Add(pnlCancelado);
            gbEstados.Controls.Add(pnlControlado);
            gbEstados.Controls.Add(label5);
            gbEstados.Controls.Add(label4);
            gbEstados.Controls.Add(pnlRecibido);
            gbEstados.Controls.Add(label3);
            gbEstados.Controls.Add(pnlConfirmado);
            gbEstados.Controls.Add(label2);
            gbEstados.Controls.Add(pnlEnEdicion);
            gbEstados.Controls.Add(label1);
            gbEstados.Location = new Point(12, 301);
            gbEstados.Name = "gbEstados";
            gbEstados.Size = new Size(560, 53);
            gbEstados.TabIndex = 0;
            gbEstados.TabStop = false;
            gbEstados.Text = "Estados";
            // 
            // pnlCancelado
            // 
            pnlCancelado.Location = new Point(444, 19);
            pnlCancelado.Name = "pnlCancelado";
            pnlCancelado.Size = new Size(14, 15);
            pnlCancelado.TabIndex = 23;
            // 
            // pnlControlado
            // 
            pnlControlado.Location = new Point(331, 19);
            pnlControlado.Name = "pnlControlado";
            pnlControlado.Size = new Size(14, 15);
            pnlControlado.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(464, 19);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 22;
            label5.Text = "Cancelado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(351, 19);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 20;
            label4.Text = "Controlado";
            // 
            // pnlRecibido
            // 
            pnlRecibido.Location = new Point(225, 19);
            pnlRecibido.Name = "pnlRecibido";
            pnlRecibido.Size = new Size(14, 15);
            pnlRecibido.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(245, 19);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 18;
            label3.Text = "Recibido";
            // 
            // pnlConfirmado
            // 
            pnlConfirmado.Location = new Point(117, 19);
            pnlConfirmado.Name = "pnlConfirmado";
            pnlConfirmado.Size = new Size(14, 15);
            pnlConfirmado.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(137, 19);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 16;
            label2.Text = "Confirmado";
            // 
            // pnlEnEdicion
            // 
            pnlEnEdicion.Location = new Point(10, 19);
            pnlEnEdicion.Name = "pnlEnEdicion";
            pnlEnEdicion.Size = new Size(14, 15);
            pnlEnEdicion.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 19);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 14;
            label1.Text = "En Edición";
            // 
            // pnlBotones
            // 
            pnlBotones.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlBotones.Controls.Add(btnConsultar);
            pnlBotones.Controls.Add(btnSeleccionar);
            pnlBotones.Controls.Add(btnBorrar);
            pnlBotones.Controls.Add(btnCrear);
            pnlBotones.Controls.Add(btnModificar);
            pnlBotones.Location = new Point(541, 4);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(40, 202);
            pnlBotones.TabIndex = 13;
            // 
            // btnConsultar
            // 
            btnConsultar.Image = (Image)resources.GetObject("btnConsultar.Image");
            btnConsultar.Location = new Point(3, 2);
            btnConsultar.Margin = new Padding(3, 2, 3, 2);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(35, 35);
            btnConsultar.TabIndex = 17;
            toolTip1.SetToolTip(btnConsultar, "Nuevo");
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSeleccionar.Image = (Image)resources.GetObject("btnSeleccionar.Image");
            btnSeleccionar.Location = new Point(3, 158);
            btnSeleccionar.Margin = new Padding(3, 2, 3, 2);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(35, 35);
            btnSeleccionar.TabIndex = 14;
            toolTip1.SetToolTip(btnSeleccionar, "Seleccionar");
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Image = (Image)resources.GetObject("btnBorrar.Image");
            btnBorrar.Location = new Point(3, 119);
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
            btnCrear.Location = new Point(3, 41);
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
            btnModificar.Location = new Point(3, 80);
            btnModificar.Margin = new Padding(3, 2, 3, 2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(35, 35);
            btnModificar.TabIndex = 10;
            toolTip1.SetToolTip(btnModificar, "Modificar");
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // frmABMSPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 435);
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(600, 400);
            Name = "frmABMSPedidos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pedidos";
            Load += frmABMSPedidos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            gbEstados.ResumeLayout(false);
            gbEstados.PerformLayout();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvDatos;
        private SplitContainer splitContainer1;
        private TextBox txtFiltro;
        private Panel pnlBotones;
        private Button btnBorrar;
        private Button btnCrear;
        private Button btnModificar;
        private Button btnSeleccionar;
        private ToolTip toolTip1;
        private Button btnConsultar;
        private GroupBox gbEstados;
        private Panel pnlEnEdicion;
        private Label label1;
        private Panel pnlCancelado;
        private Panel pnlControlado;
        private Label label5;
        private Label label4;
        private Panel pnlRecibido;
        private Label label3;
        private Panel pnlConfirmado;
        private Label label2;
    }
}