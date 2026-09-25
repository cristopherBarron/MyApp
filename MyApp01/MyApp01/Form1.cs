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
                reader.Close();
                foreach (var registro in registros)
                {
                    dgvRegistros.Rows.Add(registro.id, registro.name, registro.email);
                }

            }
        }

        private void dgvRegistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;

            switch (e.ColumnIndex)
            { 
                case 3:
                    Form2 editar = new Form2(dgvRegistros.Rows[i].Cells[1].Value.ToString(), dgvRegistros.Rows[i].Cells[2].Value.ToString());
                    if (editar.ShowDialog() == DialogResult.OK)
                    {
                        dgvRegistros.Rows[i].Cells[1].Value = registros[i].name = editar.actualizaNombre;
                        dgvRegistros.Rows[i].Cells[2].Value = registros[i].email = editar.actualizaCorreo;
                    }
                    else return;
                    break;
                case 4:
                    if (MessageBox.Show("¿Esta seguro que quiere borrar el registro con el id: " + registros[i].id + " ?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        dgvRegistros.Rows.RemoveAt(i);
                        registros.RemoveAt(i);
                    }
                    else return;
                    break;
                default: return;
            }
            var writer = new StreamWriter(ofdCSV.FileName);
            var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csvWriter.WriteRecords(registros);
            writer.Close();
        }
    }
}
