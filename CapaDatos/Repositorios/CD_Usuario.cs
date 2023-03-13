using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CapaDatos.Repositorios
{
    public class CD_Usuario
    {
        private Repositorio conexion = new Repositorio();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "MostrarUsuario";
            comando.CommandType = CommandType.Text;  
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrarConexion();

            return tabla;
        }
        public void Insertar(string cedula, string nombre, string apellido, string celular,string email ,string rol)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "InsertarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cedula", cedula);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@celular", celular);
            comando.Parameters.AddWithValue("@email", email);
            if (rol == "Instructor")
            {
                rol = "2";
                comando.Parameters.AddWithValue("@rol", rol);
            }
            else if (rol == "Aprendiz")
            {
                rol = "1";
                comando.Parameters.AddWithValue("@rol", rol);
            }
            else if (rol == "Practicante")
            {
                rol = "3";
                comando.Parameters.AddWithValue("@rol", rol);
            }

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Editar(string cedula, string nombre, string apellido, string celular, string email, string rol)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "UpdateUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cedula", cedula);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@celular", celular);
            comando.Parameters.AddWithValue("@email", email);
            if (rol == "Instructor")
            {
                rol = "2";
                comando.Parameters.AddWithValue("@rol", rol);
            }
            else if (rol == "Aprendiz")
            {
                rol = "1";
                comando.Parameters.AddWithValue("@rol", rol);
            }
            else if (rol == "Practicante")
            {
                rol = "3";
                comando.Parameters.AddWithValue("@rol", rol);
            }

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void Eliminar(String cedula)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "EliminarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cedula", cedula);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void FiltrarUsuario(string Cedula, DataGridView Vista)
        {
            DataTable dt = new DataTable();
            string consulta = "select * from usuario where Cedula like '" + Cedula + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter (consulta,conexion.abrirConexion());
            adapter.Fill(dt);
            Vista.DataSource = dt;           
        }
        public int Exitencia(string Cedula)
        {
            String consulta = "Select * from usuario where Cedula='" + Cedula + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion.abrirConexion());
            adapter.Fill(tabla);
            int restul = tabla.Rows.Count;
            return restul;
        }

    }
}
