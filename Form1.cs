using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoCRUD.Clases;


namespace ProyectoCRUD
{
    public partial class Form1 : Form
    {

        public void limpiarCampos()
        {
            txtID.Text = "";
            txtCedula.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";

        }

        ClaseAlumnos objetoAlumno = new ClaseAlumnos();
        public Form1()
        {
            InitializeComponent();
            
            objetoAlumno.mostrarAlumnos(dgvAlumnos);
            txtID.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string cedula = txtCedula.Text;
                string nombres = txtNombres.Text;
                string apellidos = txtApellidos.Text;
                int edad = Convert.ToInt16(txtEdad.Text);

                objetoAlumno.guardarAlumnos(cedula,nombres,apellidos,edad);

                objetoAlumno.mostrarAlumnos(dgvAlumnos);
                limpiarCampos();

            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese una edad válida");
               
            }
            catch (Exception ex){

                MessageBox.Show("Error: " + ex.Message);

            }

        }

        private void dgvAlumnos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            objetoAlumno.seleccionarAlumno(dgvAlumnos,txtID,txtCedula,txtNombres,txtApellidos,txtEdad);


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {
                int ID = Convert.ToInt16(txtID.Text);
                string cedula = txtCedula.Text;
                string nombres = txtNombres.Text;
                string apellidos = txtApellidos.Text;
                int edad = Convert.ToInt16(txtEdad.Text);

                objetoAlumno.modificarAlumnos(ID,cedula, nombres, apellidos, edad);

                objetoAlumno.mostrarAlumnos(dgvAlumnos);
                limpiarCampos();

            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese una edad válida");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                int ID = Convert.ToInt16(txtID.Text);
                objetoAlumno.eliminarAlumno(ID);
                objetoAlumno.mostrarAlumnos(dgvAlumnos);
                limpiarCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                

            }





        }
    }
}
