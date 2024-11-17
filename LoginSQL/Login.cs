using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LoginSQL
{
    public partial class Login : Form
    {
        
        public Login()
        {
            clsConexion obData = new clsConexion();
            obData.Datos();
            InitializeComponent();
        }

        
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (Verificacion())
            {
                DialogResult = DialogResult.OK;
                MessageBox.Show("Bienvenido");

            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrecto.");
                txtPassword.Text = string.Empty;
                txtUsers.Text = string.Empty;
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public bool Verificacion()
        {
            clsConexion obData = new clsConexion();
            obData.Datos();
            string usuario = txtUsers.Text;
            string pass = txtPassword.Text;
            for (int i = 0; i < obData.iD.Length; i++)
            {
                if (usuario == obData.Usuario[i] && pass == obData.Password[i])
                {
                    return true;
                }

            }
            return false;
        }
    }
}
