using System;
using System.Windows.Forms;
using System.Linq;

namespace GeneradorGarantia
{
    // Es VITAL que diga ": Form" para que herede las funciones de ventana
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Este método está definido en el Form1.Designer.cs
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            // 1. Validación de campos
            if (string.IsNullOrWhiteSpace(txtTaller.Text) || string.IsNullOrWhiteSpace(txtMaterial.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text)|| string.IsNullOrWhiteSpace(txtModelo.Text) || string.IsNullOrWhiteSpace(txtMarca.Text)|| string.IsNullOrWhiteSpace(txtFirma.Text)|| string.IsNullOrWhiteSpace(txtObservacion.Text))
            {
                MessageBox.Show("Por favor, rellene los campos principales.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Configurar el cuadro de diálogo para guardar
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar Carta de Garantía";
                saveFileDialog.FileName = $"Garantia_{txtMaterial.Text}.pdf"; // Nombre sugerido

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = saveFileDialog.FileName;

                    var modelo = new GarantiaModel
                    {
                        Taller = txtTaller.Text.ToUpper(),
                        Material = txtMaterial.Text,
                        Descripcion = txtDescripcion.Text,
                        Modelo = txtModelo.Text,
                        Marca = txtMarca.Text,
                        Serie = txtSerie.Text,
                        FirmaNombre = txtFirma.Text,
                        Observacion = txtObservacion.Text
                    };

                    try 
                    {
                        // Pasamos la ruta elegida al generador
                        DocumentoGarantia.Generar(modelo, rutaArchivo);
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(rutaArchivo) { UseShellExecute = true });//Abrir de forma automática el PDF generado
                        MessageBox.Show("¡PDF guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}