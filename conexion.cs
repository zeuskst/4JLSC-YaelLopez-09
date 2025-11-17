using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace _4JLSC_YaelLopez_09
{
    public class conexion
    {
        private readonly string link = "Data Source=LAPTOP-28BR3PVP\\SQLEXPRESS;Initial Catalog=Base;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=30";
        private SqlConnection conectar()
        {
            return new SqlConnection(link);
        }
        public bool Insertar(string nombre, string apellidos, string telefono,float estatura, int edad,string genero)
        {
            using (SqlConnection conexion = conectar())
            {
                string consulta = "INSERT INTO Registro(Nombre,Apellidos,Telefono,Estatura,Edad, Genero) VALUES(@Nombre,@Apellidos,@Telefono,@Estatura,@Edad,@Genero)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Apellidos", apellidos);
                comando.Parameters.AddWithValue("@Telefono", telefono);
                comando.Parameters.AddWithValue("@Estatura", estatura);
                comando.Parameters.AddWithValue("@Edad", edad);
                comando.Parameters.AddWithValue("@Genero", genero);
                try
                {
                    conexion.Open();
                   comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public DataTable Buscar(string nombre)
        {
            DataTable tabla= new DataTable();
            using (SqlConnection conexion = conectar())
            {
                try
                {
                    string consulta = "SELECT * FROM Registro WHERE Nombre LIKE @Nombre + '%'";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    SqlDataAdapter adaptador= new SqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                    return tabla;
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Error al consultar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            
        }
        public DataTable Mostrartodos()
        {
            DataTable tabla= new DataTable();
            using (SqlConnection conexion = conectar())
            {
                try
                {
                    string consulta = "SELECT * FROM Registro";
                    SqlCommand comando = new SqlCommand(consulta,conexion);
                    SqlDataAdapter adapatador = new SqlDataAdapter(comando);
                    adapatador.Fill(tabla);
                    return tabla;
                }catch(Exception ex)
                {
                    MessageBox.Show($"Error al consultar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
        
    }
}
