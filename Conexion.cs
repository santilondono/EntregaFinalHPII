using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace EntregaFinalHPII
{
    
    public class Conexion
    {
        SQLiteConnection conexion;
        SQLiteCommand comand;
        SQLiteDataReader datareader;
        public Conexion()
        {
            
            //Creamos la conexion, el command y el datareader
            try
            {
                //Le asignamos la cadena de conexion para SQLite
                conexion = new SQLiteConnection("Data Source=dboEntregaFinal.db;Version=3");
                conexion.Open();//Abrimos la conexion
                                //comand = conexion.CreateCommand();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR EN LA CONEXIÓN." + ex.ToString());
                
            }


        }
        public int Consultalogin(string Usser, string Password)
        {
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
    }
}
