namespace Escritorio
{
    partial class frmMostrarMensaje
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
            lblDescripcion = new Label();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(276, 39);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(82, 22);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescripcion.Location = new Point(12, 9);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(51, 19);
            lblDescripcion.TabIndex = 0;
            lblDescripcion.Text = "label1";
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.Bisque;
            splitContainer1.Panel1.Controls.Add(lblDescripcion);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.NavajoWhite;
            splitContainer1.Panel2.Controls.Add(btnAceptar);
            splitContainer1.Size = new Size(444, 135);
            splitContainer1.SplitterDistance = 39;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 3;
            // 
            // frmMostrarMensaje
            // 
            AccessibleRole = AccessibleRole.Alert;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 111);
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(460, 220);
            MinimizeBox = false;
            Name = "frmMostrarMensaje";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mensaje";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnAceptar;
        private Label lblDescripcion;
        private SplitContainer splitContainer1;
    }
}