using System;
using System.Data;
using System.Windows.Forms;

namespace LoginSQL
{
    public partial class frmPrin : Form
    {
        public frmPrin()
        {
            InitializeComponent();
        }

        private void clsPrin_Load(object sender, EventArgs e)
        {
            Login frm = new Login();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                this.Close();
            }

            CargaDT();

        }

        public void CargaDT()
        {
            DataTable dt = new DataTable();
            clsConexion obData = new clsConexion();
            obData.DatosDT(dt);
            dgvUsuarios.DataSource = dt;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string direccion = txtDireccion.Text;
            string pass = txtPass.Text;
            clsConexion obData = new clsConexion();
            obData.Agregar(usuario,direccion,pass);
            CargaDT();

            txtUsuario.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtDireccion.Text = string.Empty;
        }

        private void frmPrin_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmPrin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
