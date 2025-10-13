using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4JLSC_YaelLopez_09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = "";
            string apellidos = "";
            string telefono = "";
            float estatura= 0;
            int edad = 0;
            string genero = "";
            if(Validaciones.EntradaValida(txtNombre.Text)) nombre = txtNombre.Text;
            else
            {
                MessageBox.Show("Nombre invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(Validaciones.EntradaValida(txtApellidos.Text)) apellidos = txtApellidos.Text;
            else
            {
                MessageBox.Show("Apellidos invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(Validaciones.ValidarTelefono(txtTelefono.Text)) telefono = txtTelefono.Text;
            else
            {
                MessageBox.Show("Telefono invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(Validaciones.EsFlotanteValido(txtEstatura.Text)) estatura = float.Parse(txtEstatura.Text);
            else
            {
                MessageBox.Show("Estatura invalida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(Validaciones.EsEnteroValido(txtEdad.Text)) edad = int.Parse(txtEdad.Text);
            else
            {
                MessageBox.Show("Edad invalida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rbMasculino.Checked)
            {
                genero = "Masculino";
            }
            else if (rbFemenino.Checked)
            {
                genero = "Femenino";
            }
            else
            {
                MessageBox.Show("Debe seleccionar un genero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            conexion conexion = new conexion();
            bool logrado=conexion.Insertar(nombre, apellidos, telefono, estatura, edad, genero);
            if (logrado)
            {
                MessageBox.Show("Registro guardado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtTelefono.Text = "";
            txtEstatura.Text = "";
            txtEdad.Text = "";
            txtBuscar.Text = "";
            rbMasculino.Checked = false;
            rbFemenino.Checked = false;
            dataMostrar.DataSource = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreBuscar = "";
            if (Validaciones.EntradaValida(txtBuscar.Text)) nombreBuscar=txtBuscar.Text ;
            else
            {
                MessageBox.Show("Ingresa un nombre valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
                conexion conexion = new conexion();
            DataTable resultado = conexion.Buscar(nombreBuscar);
            if (resultado.Rows.Count > 0)
            {
                dataMostrar.DataSource = resultado;
            }
            else
            {
                MessageBox.Show("No se encontraron registros con ese nombre", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
