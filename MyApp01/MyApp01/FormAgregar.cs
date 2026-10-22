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
    public partial class frmAgregar : Form
    {
        datos datos;
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            datos = new datos();

            if (datos.insertar(txtNombre.Text, txtPaterno.Text, txtMaterno.Text, txtTelefono.Text, txtCorreo.Text)) {
                MessageBox.Show("Registrado correctamente.");
                this.Close();
            }
            else {
                MessageBox.Show("No se ha registrado.");
            }
        }
    }
}
