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
    public partial class fmrInformacion : Form
    {

        Datos datos;
        int idSelec = -1;
        
        public fmrInformacion()
        {
            InitializeComponent();
        }
        private void ActualizarGrid()
        {
            datos = new Datos();
            DataSet ds = datos.Informacion("Select id,nombre,paterno,materno,telefono,correo,Estado,Municipio from Datos " +
                "Inner Join Estados On Datos.idEstado = Estados.idEstado " +
                "Inner Join Municipios On Datos.idMunicipio=Municipios.idMunicipio");

            if (ds != null)
            {
                
                dgvInformacion.AutoGenerateColumns = false;
                dgvInformacion.Columns[1].DataPropertyName = "nombre";
                dgvInformacion.Columns[2].DataPropertyName = "paterno";
                dgvInformacion.Columns[3].DataPropertyName = "materno";
                dgvInformacion.Columns[0].DataPropertyName = "id";
                dgvInformacion.Columns[4].DataPropertyName = "telefono";
                dgvInformacion.Columns[5].DataPropertyName = "correo";
                dgvInformacion.Columns[6].DataPropertyName = "estado";
                dgvInformacion.Columns[7].DataPropertyName = "municipio";

                dgvInformacion.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("No se pudo obtener la información de la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            frmAgregar agregar = new frmAgregar();
            agregar.Show();
        }

        private void fmrInformacion_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void fmrInformacion_Activated(object sender, EventArgs e)
        {
            ActualizarGrid();
            dgvInformacion.ClearSelection();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (idSelec > 0)
            {
                frmAgregar agregar = new frmAgregar(dgvInformacion.CurrentRow.Cells[1].Value.ToString(),
                    dgvInformacion.CurrentRow.Cells[2].Value.ToString(),
                    dgvInformacion.CurrentRow.Cells[3].Value.ToString(),
                    dgvInformacion.CurrentRow.Cells[4].Value.ToString(),
                    dgvInformacion.CurrentRow.Cells[5].Value.ToString(),
                    idSelec);

                agregar.Show();

            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (idSelec > 0)
            {
                if (MessageBox.Show("¿Deseas eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    bool eliminado = datos.ejecutar("DELETE FROM Datos WHERE id = " + idSelec);

                    if (eliminado)
                    {
                        MessageBox.Show("Registro eliminado correctamente");
                        ActualizarGrid();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el registro");
                    }
                }
            }

        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvInformacion_CellMouseUp_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < (dgvInformacion.RowCount - 1))
            {
                dgvInformacion.Rows[e.RowIndex].Selected = true;
                dgvInformacion.CurrentCell = dgvInformacion.Rows[e.RowIndex].Cells[0];
                idSelec = Convert.ToInt32(dgvInformacion.Rows[e.RowIndex].Cells[0].Value);

            }
            else
                idSelec = -1;
        }
 
    }
}
