namespace Proyecto1AppCalculadora
{
    partial class FrmHistorial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHistorial));
            this.BtnRegresar = new System.Windows.Forms.Button();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.lstHisotorial = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // BtnRegresar
            // 
            this.BtnRegresar.Location = new System.Drawing.Point(286, 238);
            this.BtnRegresar.Name = "BtnRegresar";
            this.BtnRegresar.Size = new System.Drawing.Size(75, 23);
            this.BtnRegresar.TabIndex = 0;
            this.BtnRegresar.Text = "Regresar";
            this.BtnRegresar.UseVisualStyleBackColor = true;
            this.BtnRegresar.Click += new System.EventHandler(this.BtnRegresar_Click);
            // 
            // lblHistorial
            // 
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorial.Location = new System.Drawing.Point(86, 9);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(203, 24);
            this.lblHistorial.TabIndex = 1;
            this.lblHistorial.Text = "Historial De Calculos";
            // 
            // lstHisotorial
            // 
            this.lstHisotorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstHisotorial.FormattingEnabled = true;
            this.lstHisotorial.ItemHeight = 24;
            this.lstHisotorial.Location = new System.Drawing.Point(12, 36);
            this.lstHisotorial.Name = "lstHisotorial";
            this.lstHisotorial.Size = new System.Drawing.Size(339, 196);
            this.lstHisotorial.TabIndex = 2;
            // 
            // FrmHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 273);
            this.Controls.Add(this.lstHisotorial);
            this.Controls.Add(this.lblHistorial);
            this.Controls.Add(this.BtnRegresar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmHistorial";
            this.Text = "Historial De Calculos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRegresar;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.ListBox lstHisotorial;
    }
}