namespace Escritorio
{
    partial class frmCargando
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
            pbrCargando = new ProgressBar();
            tmr = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // pbrCargando
            // 
            pbrCargando.Location = new Point(12, 22);
            pbrCargando.Name = "pbrCargando";
            pbrCargando.Size = new Size(298, 23);
            pbrCargando.TabIndex = 0;
            // 
            // tmr
            // 
            tmr.Enabled = true;
            tmr.Tick += tmr_Tick;
            // 
            // frmCargando
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 64);
            ControlBox = false;
            Controls.Add(pbrCargando);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCargando";
            Text = "Cargando...";
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar pbrCargando;
        private System.Windows.Forms.Timer tmr;
    }
}