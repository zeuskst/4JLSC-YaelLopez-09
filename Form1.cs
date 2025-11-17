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
            try
            {
                
                Validaciones.EntradaValida(txtNombre.Text, "Nombre");
                string nombre = txtNombre.Text;

                Validaciones.EntradaValida(txtApellidos.Text, "Apellidos");
                string apellidos = txtApellidos.Text;

                Validaciones.ValidarTelefono(txtTelefono.Text, "Teléfono");
                string telefono = txtTelefono.Text;

                Validaciones.EsFlotanteValido(txtEstatura.Text, "Estatura");
                float estatura = float.Parse(txtEstatura.Text);

                Validaciones.EsEnteroValido(txtEdad.Text, "Edad");
                int edad = int.Parse(txtEdad.Text);

                
                string genero = "";
                if (rbMasculino.Checked)
                    genero = "Masculino";
                else if (rbFemenino.Checked)
                    genero = "Femenino";
                else
                    throw new Exception("Debe seleccionar un género.");

                
                conexion conexion = new conexion();
                bool logrado = conexion.Insertar(nombre, apellidos, telefono, estatura, edad, genero);

                if (logrado)
                {
                    MessageBox.Show("Registro guardado con éxito", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (CampoVacioException ex)
            {
                MessageBox.Show(ex.Message, "Campo Vacío",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (EnteroInvalidoExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Número Entero Inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FlotanteInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Número Decimal Inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TelefonoInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Teléfono Inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (EntradaInvalidaException ex)
            {
                MessageBox.Show(ex.Message, "Entrada Inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (validacionExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Validaciones.EntradaValida(txtBuscar.Text, "Nombre a buscar");
                string nombreBuscar = txtBuscar.Text;

                conexion conexion = new conexion();
                DataTable resultado = conexion.Buscar(nombreBuscar);

                if (resultado.Rows.Count > 0)
                {
                    dataMostrar.DataSource = resultado;
                }
                else
                {
                    MessageBox.Show("No se encontraron registros con ese nombre",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (EntradaInvalidaException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnMostrartodos_Click(object sender, EventArgs e)
        {
            try
            {
                conexion conexion = new conexion();
                DataTable resultado = conexion.Mostrartodos();

                if (resultado.Rows.Count > 0)
                    dataMostrar.DataSource = resultado;
                else
                {
                    MessageBox.Show("No hay registros en la base de datos",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar registros: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
