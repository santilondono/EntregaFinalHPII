using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EntregaFinalHPII
{
    public partial class frmPrincipal : Form
    {
        //Abrimos la conexión, utilizando la clase conexión//
        Conexion Conn_3 = new Conexion();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            
        }

        //Evento para que al cerrar la ventana finalice la ejecucion del programa
        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            string line;

            OpenFileDialog ofd = new OpenFileDialog();//Instanciamos la ventana para abrir el archivo
            ofd.InitialDirectory = Application.StartupPath;//Especificamos donde se abrira esta ventana por defecto
            ofd.Filter = "Archivos de texto y CSV(*.txt, *.csv)|*.txt;*.csv";//Especificamos que tipo de archivos podra subir

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(ofd.FileName);
                    while ((line = file.ReadLine()) != null)
                    {
                        dgvImportacion.Rows.Add(line.Split(';'));//Agregamos la fila al datagridview
                    }

                    file.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: "+ex.Message);
                }
            }
        }

        //Evento para cerrar el programa haciendo clic en el boton cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Evento para limpiar el datagridview haciendo clic en el boton limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvImportacion.Rows.Clear();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Form frmRegistrar = new frmRegistroManual();
            frmRegistrar.Show();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //Lectura de columnas//
            foreach (DataGridViewRow row in dgvImportacion.Rows)
            {
                bool Confirmacion;

                //Asignación y llenado de variables//
                string Cedulas = row.Cells["CC"].Value.ToString();
                string Nombres = row.Cells["Nombres"].Value.ToString();
                string Apellidos = row.Cells["Apellidos"].Value.ToString();
                string Correos = row.Cells["Correo"].Value.ToString();

                //Llamamos a la clase y enviamos los parámetros//
                Confirmacion = Conn_3.InsertarDatos(Cedulas, Nombres, Apellidos, Correos);
                if (Confirmacion)
                {
                    MessageBox.Show("Importación del DataGrid realizada a la base de datos.");
                }
                else
                {
                    MessageBox.Show("No se pudo realiza la importación del DataGrid realizada a la base de datos.");
                }
            }
        }
    }
}
