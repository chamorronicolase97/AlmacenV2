namespace Escritorio
{
    partial class frmCostosProductos
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
            dgvDatos = new DataGridView();
            splitContainer1 = new SplitContainer();
            pnlBotones = new Panel();
            btnBuscar = new Button();
            label1 = new Label();
            dtpFechaCosto = new DateTimePicker();
            txtFiltro = new TextBox();
            btnActualizarCostos = new Button();
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
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.RowTemplate.Height = 29;
            dgvDatos.Size = new Size(950, 381);
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
            splitContainer1.Panel1.Controls.Add(pnlBotones);
            splitContainer1.Panel1.Controls.Add(txtFiltro);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnActualizarCostos);
            splitContainer1.Panel2.Controls.Add(dgvDatos);
            splitContainer1.Size = new Size(1023, 464);
            splitContainer1.SplitterDistance = 79;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 1;
            // 
            // pnlBotones
            // 
            pnlBotones.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlBotones.Controls.Add(btnBuscar);
            pnlBotones.Controls.Add(label1);
            pnlBotones.Controls.Add(dtpFechaCosto);
            pnlBotones.Location = new Point(755, 3);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(256, 45);
            pnlBotones.TabIndex = 12;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.Location = new Point(177, 3);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(67, 35);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 14);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "Fecha";
            // 
            // dtpFechaCosto
            // 
            dtpFechaCosto.Format = DateTimePickerFormat.Short;
            dtpFechaCosto.Location = new Point(58, 8);
            dtpFechaCosto.Name = "dtpFechaCosto";
            dtpFechaCosto.Size = new Size(113, 23);
            dtpFechaCosto.TabIndex = 0;
            dtpFechaCosto.Value = new DateTime(2024, 11, 11, 0, 0, 0, 0);
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(10, 24);
            txtFiltro.Margin = new Padding(3, 2, 3, 2);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(165, 23);
            txtFiltro.TabIndex = 3;
            // 
            // btnActualizarCostos
            // 
            btnActualizarCostos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizarCostos.Location = new Point(953, 3);
            btnActualizarCostos.Name = "btnActualizarCostos";
            btnActualizarCostos.Size = new Size(67, 54);
            btnActualizarCostos.TabIndex = 2;
            btnActualizarCostos.Text = "Actualizar";
            btnActualizarCostos.UseVisualStyleBackColor = true;
            btnActualizarCostos.Click += btnActualizarCostos_ClickAsync;
            // 
            // frmCostosProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 464);
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(600, 400);
            Name = "frmCostosProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Costos Productos";
            Load += frmCostosProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            pnlBotones.ResumeLayout(false);
            pnlBotones.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvDatos;
        private SplitContainer splitContainer1;
        private TextBox txtFiltro;
        private Panel pnlBotones;
        private ToolTip toolTip1;
        private Button btnActualizarCostos;
        private Label label1;
        private DateTimePicker dtpFechaCosto;
        private Button button1;
        private Button btnBuscar;
    }
}