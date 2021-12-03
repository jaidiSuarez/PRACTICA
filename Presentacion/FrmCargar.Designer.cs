
namespace Presentacion
{
    partial class FrmCargar
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
            this.label1 = new System.Windows.Forms.Label();
            this.CmbProyectos = new System.Windows.Forms.ComboBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.BttCargar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proyectos";
            // 
            // CmbProyectos
            // 
            this.CmbProyectos.FormattingEnabled = true;
            this.CmbProyectos.Location = new System.Drawing.Point(195, 77);
            this.CmbProyectos.Name = "CmbProyectos";
            this.CmbProyectos.Size = new System.Drawing.Size(160, 21);
            this.CmbProyectos.TabIndex = 1;
            this.CmbProyectos.SelectedIndexChanged += new System.EventHandler(this.CmbProyectos_SelectedIndexChanged);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // BttCargar
            // 
            this.BttCargar.Font = new System.Drawing.Font("Lucida Fax", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttCargar.Location = new System.Drawing.Point(393, 74);
            this.BttCargar.Name = "BttCargar";
            this.BttCargar.Size = new System.Drawing.Size(75, 23);
            this.BttCargar.TabIndex = 2;
            this.BttCargar.Text = "Cargar";
            this.BttCargar.UseVisualStyleBackColor = true;
            this.BttCargar.Click += new System.EventHandler(this.BttCargar_Click);
            // 
            // FrmCargar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 245);
            this.Controls.Add(this.BttCargar);
            this.Controls.Add(this.CmbProyectos);
            this.Controls.Add(this.label1);
            this.Name = "FrmCargar";
            this.Text = "FrmCargar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbProyectos;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button BttCargar;
    }
}