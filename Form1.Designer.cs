namespace GeneradorGarantia
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Controles
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblDev;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.TextBox txtTaller;
        private System.Windows.Forms.TextBox txtFirma;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Button btnGenerar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblDev = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // --- PANEL DE CABECERA (Estilo Moderno) ---
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlHeader.Controls.Add(this.lblDev);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(420, 30);

            // Etiqueta Desarrollador
            this.lblDev.AutoSize = true;
            this.lblDev.ForeColor = System.Drawing.Color.White;
            this.lblDev.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblDev.Location = new System.Drawing.Point(230, 7);
            this.lblDev.Text = "Desarrollada por Arlinton Feliz";

            // --- TÍTULO PRINCIPAL ---
            this.lblTitulo.Text = "Generador de Carta de Garantía";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 45);
            this.lblTitulo.Size = new System.Drawing.Size(380, 30);

            this.lblSubtitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(23, 75);
            this.lblSubtitulo.Size = new System.Drawing.Size(250, 2); // Línea roja decorativa

            // --- CAMPOS DE ENTRADA ---
            int startY = 85;
            int spacing = 38;

            this.txtTaller = CreateStyledField("Taller (Sres):", ref startY, spacing);
            this.txtMaterial = CreateStyledField("Material:", ref startY, spacing);
            this.txtDescripcion = CreateStyledField("Descripción:", ref startY, spacing);
            this.txtModelo = CreateStyledField("Modelo:", ref startY, spacing);
            this.txtMarca = CreateStyledField("Marca:", ref startY, spacing);
            this.txtSerie = CreateStyledField("Serie:", ref startY, spacing);
            this.txtFirma = CreateStyledField("Firma (Nombre):", ref startY, spacing);
            this.txtObservacion = CreateStyledField("Observación:", ref startY, spacing);

            // --- BOTÓN GENERAR CON MARGIN TOP ---
            startY += 30; // Este es el MARGIN TOP extra para el botón
            this.btnGenerar.Text = "GENERAR PDF";
            this.btnGenerar.Location = new System.Drawing.Point(25, startY);
            this.btnGenerar.Size = new System.Drawing.Size(360, 45);
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);

            // --- CONFIGURACIÓN DEL FORMULARIO ---
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(420, startY + 80);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.btnGenerar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jumbo - Gestión de Garantías";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Método auxiliar para crear campos con mejor estética
        private System.Windows.Forms.TextBox CreateStyledField(string labelText, ref int y, int spacing)
        {
            y += spacing;
            var lbl = new System.Windows.Forms.Label { 
                Text = labelText, 
                Location = new System.Drawing.Point(25, y + 3), 
                Size = new System.Drawing.Size(110, 20),
                Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular)
            };
            var txt = new System.Windows.Forms.TextBox { 
                Location = new System.Drawing.Point(140, y), 
                Size = new System.Drawing.Size(245, 25),
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };
            this.Controls.Add(lbl);
            this.Controls.Add(txt);
            return txt;
        }
    }
}