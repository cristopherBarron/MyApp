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
    public partial class frmInformacion : Form
    {
        datos datos;
        public frmInformacion()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmInformacion_Load(object sender, EventArgs e)
        {
            datos = new datos();
            DataSet ds = datos.informacion("SELECT * FROM datos");
            if (ds != null)
            {
                dgvInformacion.DataSource = ds.Tables[0];
            }
            else
                MessageBox.Show("Error al cargar la informacion","SISTEMA",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
