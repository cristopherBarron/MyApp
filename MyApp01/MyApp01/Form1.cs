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

        private void dgvRegistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("mamadas");

            Form2 editar = new Form2(dgvRegistros.Rows[e.RowIndex].Cells[1].Value.ToString(), dgvRegistros.Rows[e.RowIndex].Cells[2].Value.ToString());
            //editar.Show();
            if (editar.ShowDialog() == DialogResult.OK)
            {
                string[] aux = encontrar();

                string nombre = editar.actualizaNombre;
                string correo = editar.actualizaCorreo;

                dgvRegistros.Rows[e.RowIndex].Cells[1].Value = nombre;
                dgvRegistros.Rows[e.RowIndex].Cells[2].Value = correo;

                string registrosActualizados = aux[0] + nombre + "," + correo + aux[1];
                var writer = new StreamWriter(ofdCSV.FileName);
                writer.Write(registrosActualizados);
                writer.Close();
            }
        }

        private string[] encontrar() {
            string[] aux = new string[2];
            
            var reader = new StreamReader(ofdCSV.FileName);
            string recor = "", registro = dgvRegistros.Rows[e.RowIndex].Cells[1].Value.ToString() + "," + dgvRegistros.Rows[e.RowIndex].Cells[2].Value.ToString();

            while (!reader.EndOfStream)
            {
                recor += reader.Read();
                if (recor.Contains(registro))
                    aux[1] += (char)recor[recor.Length - 1];
                else
                    aux[0] += (char)recor[recor.Length - 1];
            }

            aux[0] = aux[0].Substring(0, aux[0].Length - registro.Length - 1);

                //string[] aux = reader.ReadToEnd().ToString().Split(dgvRegistros.Rows[e.RowIndex].Cells[1].Value.ToString() + "," + dgvRegistros.Rows[e.RowIndex].Cells[2].Value.ToString());
                reader.Close();
            return aux;
        }

    }
}
