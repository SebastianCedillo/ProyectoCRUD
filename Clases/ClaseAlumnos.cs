using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace ProyectoCRUD.Clases
{
    internal class ClaseAlumnos
    {
        ConexionBDD conex = new ConexionBDD();

        public void mostrarAlumnos(DataGridView tablaAlumnos)
        {

			

			try
			{
				tablaAlumnos.DataSource = null;
				string consulta = "SELECT * FROM alumnos";
				SqlDataAdapter lector = new SqlDataAdapter(consulta,conex.AbrirConexion());

				DataTable dt = new DataTable();
				lector.Fill(dt);
				tablaAlumnos.DataSource = dt;
				

			}
			catch (Exception ex)
			{
				MessageBox.Show("No se logro mostrar los registros" + ex.Message);
				
			}
			finally
			{
                conex.CerrarConexion();
            }
			 

        }  


		public void guardarAlumnos(string cedula, string nombres, string apellidos, int edad )
		{
			

			try
			{

				string query = "INSERT INTO alumnos (cedula, nombres, apellidos, edad) VALUES (@cedula,@nombres,@apellidos,@edad)";

				SqlCommand cmd = new SqlCommand(query,conex.AbrirConexion());
				//Agregamos los parametros sql con su respectivo parametro del metodo

				cmd.Parameters.AddWithValue("@cedula",cedula);
				cmd.Parameters.AddWithValue("@nombres",nombres);
				cmd.Parameters.AddWithValue("@apellidos",apellidos);
				cmd.Parameters.AddWithValue("@edad",edad);
				//Ejecutamos la query
				int filas = cmd.ExecuteNonQuery();

				//Validamos si fue insertado algun registro

				if(filas > 0)
				{
					MessageBox.Show("Alumno guardado exitosamente");
				}
				else
				{
                    MessageBox.Show("No se pudo guardar al alumno");
                }
				

			}
			catch (Exception ex)
			{

				MessageBox.Show("No se logro mostrar los registros, error: " + ex.Message);
				
			}
			finally
			{

				conex.CerrarConexion();
			}

		}



		public void seleccionarAlumno(DataGridView tablaAlumnos,TextBox id, TextBox cedula, TextBox nombres, TextBox apellidos, TextBox edad)
		
		{


			try
			{
				if (tablaAlumnos.SelectedRows.Count > 0)
				{
					
					id.Text = tablaAlumnos.CurrentRow.Cells[0].Value.ToString();
					cedula.Text = tablaAlumnos.CurrentRow.Cells[1].Value.ToString();
                    nombres.Text = tablaAlumnos.CurrentRow.Cells[2].Value.ToString();
                    apellidos.Text = tablaAlumnos.CurrentRow.Cells[3].Value.ToString();
                    edad.Text = tablaAlumnos.CurrentRow.Cells[4].Value.ToString();

                }

			}
			catch (Exception ex)
			{

                MessageBox.Show("Error al seleccionar alumno: " + ex.ToString());
            }
		}


        public void modificarAlumnos(int ID, string cedula, string nombres, string apellidos, int edad)
        {
            

            try
            {

                string query = "UPDATE ALUMNOS SET cedula= @cedula,nombres= @nombres ,apellidos= @apellidos ,edad=@edad WHERE id= @id";

                SqlCommand cmd = new SqlCommand(query, conex.AbrirConexion());
                //Agregamos los parametros sql con su respectivo parametro del metodo

                cmd.Parameters.AddWithValue("id", ID);
                cmd.Parameters.AddWithValue("@cedula", cedula);
                cmd.Parameters.AddWithValue("@nombres", nombres);
                cmd.Parameters.AddWithValue("@apellidos", apellidos);
                cmd.Parameters.AddWithValue("@edad", edad);
                //Ejecutamos la query
                int filas = cmd.ExecuteNonQuery();

                //Validamos si fue insertado algun registro

                if (filas > 0)
                {
                    MessageBox.Show("Alumno modificado exitosamente");
                }
                else
                {
                    MessageBox.Show("No se pudo modificar al alumno");
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("No se logro mostrar los registros, error: " + ex.Message);

            }
            finally
            {

                conex.CerrarConexion();
            }

        }

		public void eliminarAlumno(int ID)
		{
			try
			{

				string query = "DELETE FROM ALUMNOS WHERE id=@id";

				SqlCommand cmd = new SqlCommand(query,conex.AbrirConexion());
				cmd.Parameters.AddWithValue("@id",ID);
				int filas = cmd.ExecuteNonQuery();

				if (filas > 0)
				{
					MessageBox.Show("Se elimino el registro con exito");
				}
				else
				{
                    MessageBox.Show("No se logro eliminar el registro");
                }


			}
			catch (Exception ex)
			{

                MessageBox.Show("No se logro eliminar el registro, error: " + ex.Message);
            }
			finally
			{

				conex.CerrarConexion();
			}




		}










    }
}
