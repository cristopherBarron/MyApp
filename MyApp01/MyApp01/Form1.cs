using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.Globalization;
using System.IO;

namespace MyApp01
{
    public partial class Form1 : Form
    {
        List<Persona> registros = new List<Persona>();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtResultado_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (ofdCSV.ShowDialog() == DialogResult.OK)
            { 
                var reader = new StreamReader(ofdCSV.FileName);
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                registros = csv.GetRecords<Persona>().ToList();
                foreach (var registro in registros)
                {
                    dgvRegistros.Rows.Add(registro.id,registro.name,registro.email);
                }
            }
        }
    }
}
