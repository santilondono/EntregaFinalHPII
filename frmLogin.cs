
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
        public frmLogin()
        {
            InitializeComponent();
            txtUser.Text = "lsantiago";
            txtPassword.Text = "slondono";
        }

        public void Login()
        {
            int ban = 0;
            //Extraemos la informacion del registro y se guarda en variables
            string user = txtUser.Text;
            string password = txtPassword.Text;

            //Creamos la conexion, el command y el datareader
            SQLiteConnection conexion;
            SQLiteCommand comand;
            SQLiteDataReader datareader;

            //Le asignamos la cadena de conexion para SQLite
            conexion = new SQLiteConnection("Data Source=dboEntregaFinal.db;Version=3");
            conexion.Open();//Abrimos la conexion
            comand = conexion.CreateCommand();

            //Asignamos al command el query
            comand.CommandText = "SELECT * FROM tblLogin";

            datareader = comand.ExecuteReader();//Ejecutamos la consulta

            //Mediante el datareader leemos los datos obtenidos por la consulta
            while (datareader.Read())
            {
                if (datareader.GetString(1) == user && datareader.GetString(2) == password)//Evaluamos si la informacion ingresada y la de la base de datos es igual
                {
                    frmPrincipal frmPrincipal = new frmPrincipal();//Instanciamos el formulario de la pantalla principal
                    frmPrincipal.Show();//Abrir pantalla principal
                    this.Hide();//OCultamos la ventana del login
                    ban++;//Marcamos la bandera como verdadera
                }
            }

            if (ban == 0)//Si la bandera es igual a cero el usuario y/o contraseña estaran incorectos
            {
                MessageBox.Show("USUARIO Y/O CONTRASEÑA INCORRECTOS");
            }

            conexion.Close();//Cerramos la conexion
        }

        //Evento keypress para iniciar sesion con la tecla enter
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                Login();
                btnIngresar.Focus();
            }
        }

        //Evento al pulsar el boton ingresar
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Login();
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
