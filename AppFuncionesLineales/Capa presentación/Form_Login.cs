using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppFuncionesLineales.Capa__acceso;

namespace AppFuncionesLineales
{


    public partial class Form_Login : Form
    {


        public Form_Login()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsuario.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();

            if (da.ValidarUsuario(txtUsuario.Text, txtContraseña.Text))
            {
                MessageBox.Show("Bienvenido");
                Form_Funciones fr = new Form_Funciones();
                fr.ShowDialog();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
                txtUsuario.Select();
            }

        }
    }
}
