using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ProyectoCRUD.Clases
{
    internal class ConexionBDD
    {
        SqlConnection conexion = new SqlConnection("Server=DESKTOP-0OS6OUS;Database=colegioDB;User Id=sa;Password=SebastianCedillo9;");

        public SqlConnection AbrirConexion()
        {

            try
            {
                if (conexion.State == ConnectionState.Closed)
                    conexion.Open();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la conexion" + ex.ToString());

            }

            return conexion;


        }

        public SqlConnection CerrarConexion()
        {

            try
            {

                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror al cerrar la conexion: " + ex.ToString());

            }

            return conexion ;
        }
            


    }
}
