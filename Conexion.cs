using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace EntregaFinalHPII
{

    //Creamos el método que abre la conexión con la base de datos//
    public class Conexion
    {
        //Creamos la conexion, el command y el datareader
        SQLiteConnection conexion;
        SQLiteCommand comand;
        SQLiteDataReader datareader;
        public Conexion()
        {
            try
            {
                //Le asignamos la cadena de conexion para SQLite
                conexion = new SQLiteConnection("Data Source=dboEntregaFinal.db;Version=3");
                conexion.Open();//Abrimos la conexion
                                //comand = conexion.CreateCommand();
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡ERROR EN LA CONEXIÓN!" + ex.ToString());
            }
        }

        //Creamos un método para realizar la consulta de búsqueda para el Login//
        public int Consultalogin(string Usser, string Password)
        {
            //Bandera para verificar la correcta lectura de los datos//
            int ban = 0;
            //Asignamos al command el query
            comand = conexion.CreateCommand();
            comand.CommandText = "SELECT * FROM tblLogin where strUser = '"+ Usser +"'";
            datareader = comand.ExecuteReader();//Ejecutamos la consulta

            while (datareader.Read())
            {
                if (datareader.GetString(1) == Usser && datareader.GetString(2) == Password)//Evaluamos si la informacion ingresada y la de la base de datos es igual
                {
                    ban = 1;
                }
                else
                {
                    ban = 0;
                }
            }
            return ban;
        }

        //Creamos un método para realizar la consulta para la inserción de datos de forma manual//
        public bool InsertarDatos(string Cedula, string Nombre, string Apellido, string Correo)
        {
            //Variable booleana para realizar la verificación de la inserción de datos//
            bool consulta = false;
            try
            {
                //Abrimos la conexión//
                comand = conexion.CreateCommand();

                //Realizamos el Query que obtiene los datos del textBox//
                comand.CommandText = "INSERT INTO tblDatos (intCedula,varNombre,varApellido,varCorreo) VALUES ('" + Cedula + "','" + Nombre + "','" + Apellido + "','" + Correo + "')";

                if (comand.ExecuteNonQuery() > 0)
                {
                    consulta = true;
                }
                else
                {
                    consulta = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡ERROR EN LA INSERCIÓN DE LOS DATOS!" + ex.ToString());
            }
            return consulta;
        }
    }
}
