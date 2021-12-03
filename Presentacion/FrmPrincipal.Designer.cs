
namespace Presentacion
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BttCargar = new System.Windows.Forms.Button();
            this.BttConsultar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BttCargar
            // 
            this.BttCargar.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttCargar.Location = new System.Drawing.Point(174, 66);
            this.BttCargar.Name = "BttCargar";
            this.BttCargar.Size = new System.Drawing.Size(108, 35);
            this.BttCargar.TabIndex = 0;
            this.BttCargar.Text = "Cargar";
            this.BttCargar.UseVisualStyleBackColor = true;
            this.BttCargar.Click += new System.EventHandler(this.BttCargar_Click);
            // 
            // BttConsultar
            // 
            this.BttConsultar.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttConsultar.Location = new System.Drawing.Point(174, 118);
            this.BttConsultar.Name = "BttConsultar";
            this.BttConsultar.Size = new System.Drawing.Size(108, 35);
            this.BttConsultar.TabIndex = 1;
            this.BttConsultar.Text = "Consultar";
            this.BttConsultar.UseVisualStyleBackColor = true;
            this.BttConsultar.Click += new System.EventHandler(this.BttConsultar_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 234);
            this.Controls.Add(this.BttConsultar);
            this.Controls.Add(this.BttCargar);
            this.Name = "FrmPrincipal";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BttCargar;
        private System.Windows.Forms.Button BttConsultar;
    }
}

