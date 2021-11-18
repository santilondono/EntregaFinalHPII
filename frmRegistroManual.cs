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
    public partial class frmRegistroManual : Form
    {
        //Abrimos la conexión, utilizando la clase conexión//
        Conexion Conn_2 = new Conexion();
        public frmRegistroManual()
        {
            InitializeComponent();
        }

        //------VALIDACIÓN DE CÉDULA------//
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //El Focus se utiliza para avanzar al siguiente TXTBOX luego de cumplir con la sentencia ENTER (e.KeyChar == 13)//
                txtNombre.Focus();
            }
            if ((e.KeyChar >= 48 && e.KeyChar <= 59) || e.KeyChar == 13 || e.KeyChar == 08)
            {
                //El Handled se utiliza para deshabilitar o habilitar el teclado//
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Solo se permiten carácteres númericos.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            //TextLength mide la cantidad de carácteres utilizados//
            if (txtCedula.TextLength == 10)
            {
                if (e.KeyChar == 13 || e.KeyChar == 08)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        //------VALIDACIÓN DE NOMBRE------//
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //El Focus se utiliza para avanzar al siguiente TXTBOX luego de cumplir con la sentencia ENTER (e.KeyChar == 13)//
                txtApellido.Focus();
            }
            //Realizamos la condicional que sólo permita letras y algunas teclas especiales (Space, Suprimir, ENTER)
            if ((!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) && (!(e.KeyChar == 13)) && (!(e.KeyChar == 127)) && (!(e.KeyChar == 32)))
            {
                MessageBox.Show("Solo se permiten letras.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else 
            {
                e.Handled = false;
            }
        }

        //------VALIDACIÓN DE APELLIDO------//
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCorreo.Focus();
            }
            //Realizamos la condicional que sólo permita letras y algunas teclas especiales (Space, Suprimir, ENTER)
            if ((!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (!(e.KeyChar == 13)) && (!(e.KeyChar == 127)) && (!(e.KeyChar == 32))))
            {
                MessageBox.Show("Solo se permiten letras.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else
            {
                e.Handled = false;
            }
        }

        //------VALIDACIÓN DE CORREO------//
        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 13)
            {
                txtConfirmarCorreo.Focus();
            }
            //Verificamos que se utilice el @ en el correo y los dominios ".edu" y ".com"//
            if (txtCorreo.Text.Contains("@") && (txtCorreo.Text.Contains(".com") || txtCorreo.Text.Contains(".edu") || txtCorreo.Text.Contains(".co")))
            {
                ErrorProv.Clear();
            }
            else
            {
                ErrorProv.SetError(txtCorreo, "Faltan carácteres especiales en el correo (@ ó dominio)");
            }
        }

       
        //-----PROGRAMACIÓN DE BOTONES-----//

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Asignamo variables tipo string para almancenar la información de los TextBox//
            string Cedula, Nombre, Apellido, Correo;
            Cedula = txtCedula.Text;
            Nombre = txtNombre.Text;
            Apellido = txtApellido.Text;
            Correo = txtConfirmarCorreo.Text;

            /* Utilizamos un condicional para verificar que los datos hallar sido enviados a la bese de datos correctamente,
            en lacondicional llamamos a la clase, con las variables creadas */
            if(txtConfirmarCorreo.Text == txtCorreo.Text)
            {
                if (Conn_2.InsertarDatos(Cedula, Nombre, Apellido, Correo))
                {
                    txtCedula.Clear();
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtCorreo.Clear();
                    txtConfirmarCorreo.Clear();
                    MessageBox.Show("Datos registrado Exitosamente");
                }
                else
                {
                    MessageBox.Show("Los datos no se han podido registrar");
                }
            }
            else
            {
                MessageBox.Show("Los correos no coinciden.");
            }  
        }
    }
}
