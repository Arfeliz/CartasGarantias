using System;
using System.Windows.Forms;

namespace GeneradorGarantia
{
    static class Program
    {
        /// <summary>
        ///  Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Habilita estilos visuales modernos para los controles de Windows
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia el formulario principal
            Application.Run(new Form1());
        }
    }
}