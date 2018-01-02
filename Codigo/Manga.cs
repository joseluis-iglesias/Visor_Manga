using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manga
{
    public class Manga
    {
        static WebBrowser Navegador = new WebBrowser();
        static String Ruta = "Home";
        static String navegar = "https://www.tumangaonline.com/";
        [STAThread]
        public static void Main() {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        public static void CargarPagina(String nuevaRuta = null)
        {
            if (nuevaRuta == null)
                Navegador.Navigate(navegar + Ruta);
            else
                Navegador.Navigate(navegar + nuevaRuta);
        }

        void Navegador_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                var Cadena = Navegador.DocumentText.ToString();
                Cadena = ExtraerLogin(Cadena);
                CargarPagina(Cadena);
                Cadena = Navegador.DocumentText.ToString();
                EscribirArchivoTexto("texto.txt", Cadena);
                Navegador.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static String ExtraerLogin(string Contenido)
        {
            String subStrMan = Contenido.Substring(Contenido.IndexOf("<ng-include ng-hide"), Contenido.IndexOf("<ng-include ng-show=\"visor\"") - Contenido.IndexOf("<ng-include ng-hide"));
            return subStrMan;
        }

        private static void EscribirArchivoTexto(string NombreArchivo, string Contenido)

        {

            FileStream stream = new FileStream(NombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(Contenido);

            writer.Close();

        }
    }
}