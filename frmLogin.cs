
/*
 * Santiago Londoño López
 * Santiago Ramirez Valencia
 * HERRAMIENTAS DE PROGRAMACION II
 * 9/11/2021
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace EntregaFinalHPII
{
    public partial class frmLogin : Form
    {
        //Llamamos la clase que realiza la conexión//
        Conexion Conn = new Conexion();
        public frmLogin()
        {
            InitializeComponent();
            txtUser.Text = "lsantiago";
            txtPassword.Text = "slondono";
        }

        //Evento keypress para iniciar sesion con la tecla enter
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                //Login();
                //btnIngresar.Focus();
            }
        }

        //Evento al pulsar el boton ingresar
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int ban = Conn.Consultalogin(txtUser.Text, txtPassword.Text);
            if (ban == 1) {
                frmPrincipal inicio = new frmPrincipal();
                inicio.Show();
            }
            else
            {
                MessageBox.Show("Usuario no existe");
            }
            
        }

        //Evento keypress para passar el cursor de usuario a contraseña con la tecla enter
        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPassword.Focus();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
