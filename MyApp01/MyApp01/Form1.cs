using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp01
{
    public partial class Form1 : Form
    {
        int contador = 0;
        bool save = false;
        string path;

        public Form1()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rctTexto.Clear();
            rctTexto.Focus();
            path = "";
            save = false;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofpAbrir.ShowDialog() == DialogResult.OK)
            {
                path = ofpAbrir.FileName;
                save = true;
                contador = 0;
                rctTexto.LoadFile(ofpAbrir.FileName, RichTextBoxStreamType.PlainText);
                guardarToolStripMenuItem.Enabled = false;
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (save == false)
            {
                if (sfdGuardar.ShowDialog() == DialogResult.OK)
                {
                    contador = 0;
                    path = sfdGuardar.FileName;
                    save = true;
                }

            }
            rctTexto.SaveFile(path, RichTextBoxStreamType.PlainText);
            guardarToolStripMenuItem.Enabled = false;
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardadoGeneral();
        }

        private void guardadoGeneral()
        {

            if (sfdGuardar.ShowDialog() == DialogResult.OK)
            {
                path = sfdGuardar.FileName;
                rctTexto.SaveFile(path, RichTextBoxStreamType.PlainText);
                guardarToolStripMenuItem.Enabled = true;
                save = true;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (save)
            {
                MessageBox.Show("Los cambios se guardaran.");
                rctTexto.SaveFile(path, RichTextBoxStreamType.PlainText);
            }
            this.Close();
        }

        private void tmrGuardar_Tick(object sender, EventArgs e)
        {
            contador++;
            if (contador >= 30)
            {  
                contador = 0;
                if (save)
                {

                    rctTexto.SaveFile(path, RichTextBoxStreamType.PlainText);
                    guardarToolStripMenuItem.Enabled = true;
                    toolStripStatusLabel1.Text = "guardado en la ruta: " + path + " el " + DateTime.Now.ToString();
                }
                else
                {
                    guardadoGeneral();
                }
            }

        }
    }
}

