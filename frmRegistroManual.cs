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
        public frmRegistroManual()
        {
            InitializeComponent();
        }


        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //El Focus se utiliza para avanzar al siguiente TXTBOX luego de cumplir con la sentencia ENTER (e.KeyChar == 13)//
                txtNombre.Focus();
            }
            if ((e.KeyChar >= 48 && e.KeyChar <= 59) || e.KeyChar == 13 || e.KeyChar == 08)
            {
                
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
                    //Handled desabilita o habilita las teclas//
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //El Focus se utiliza para avanzar al siguiente TXTBOX luego de cumplir con la sentencia ENTER (e.KeyChar == 13)//
                txtApellido.Focus();
            }
            if ((!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)))
            {
                MessageBox.Show("Solo se permiten letras.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else if (e.KeyChar == 13 || e.KeyChar == 127 || e.KeyChar == 32)
            {
                e.Handled = false;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //El Focus se utiliza para avanzar al siguiente TXTBOX luego de cumplir con la sentencia ENTER (e.KeyChar == 13)//
                txtApellido.Focus();
            }
            if ((!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)))
            {
                MessageBox.Show("Solo se permiten letras.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else if (e.KeyChar == 13 || e.KeyChar == 127 || e.KeyChar == 32)
            {
                e.Handled = false;
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Verificamos que se utilice el @ en el correo y los dominios ".edu" y ".com"//
            if (txtCorreo.Text.Contains("@") && (txtCorreo.Text.Contains(".com") || txtCorreo.Text.Contains(".edu")) || txtCorreo.Text.Contains (".co"))
            {
                ErrorProv01.Clear();
                MessageBox.Show("Inscripción finalizada.");
            }
            else
            {
                ErrorProv01.SetError(txtCorreo, "Faltan carácteres especiales en el correo (@ ó dominio)");
            }
        }

        private void txtConfirmarCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmPrincipal FrmReturn = new frmPrincipal();
            FrmReturn.Show();
        }

        public void btnRegistrar_Click(object sender, EventArgs e)
        {
            string Cedula, Nombre, Apellido, Correo, Correo_2;
            Cedula = txtCedula.Text;
            Nombre = txtNombre.Text;
            Apellido = txtApellido.Text;
            Correo = txtCorreo.Text;
            Correo_2 = txtConfirmarCorreo.Text;
            
            

        }
    }
}
