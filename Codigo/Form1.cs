using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manga
{
    public partial class Form1 : Form
    {
        WebBrowser Navegador = new WebBrowser();
        public Form1()
        {
            InitializeComponent();
            Navegador.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(Navegador_DocumentCompleted);
        }

        void Navegador_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)

        {

            var Cadena = Navegador.Document.ToString();

            EscribirArchivoTexto("texto1.txt", Cadena);

        }



        private void EscribirArchivoTexto(string NombreArchivo, string Contenido)

        {

            FileStream stream = new FileStream(NombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(Contenido);

            writer.Close();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Navegador.Navigate("https://www.tumangaonline.com/lector/Shokugeki-no-Soma/8373/244.00/7634");
        }
    }
}
