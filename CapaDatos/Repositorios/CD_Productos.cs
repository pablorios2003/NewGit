using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos.Repositorios
{
   public class CD_Productos
    {
        private Repositorio conexion = new Repositorio();

        public DataTable Mostrar()
        {

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "select * from producto";
            comando.CommandType = CommandType.Text;
            SqlDataReader leer;
            leer = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(leer);
            conexion.cerrarConexion();

            return tabla;
        }
        public void Insertar(string codigoP, string nomP, int stock, string categoria)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "insert into producto values ('"+codigoP+"','"+nomP+"','"+stock+"','"+categoria+"')";
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void Editar(string codigoP, string nomP, int stock, string categoria) 
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "UpdateProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigo", codigoP);
            comando.Parameters.AddWithValue("@nomP", nomP);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@categoria", categoria);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void Eliminar(String codigo)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "EliminarProd";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public int Existencia(string code)
        {
            string consulta = "Select * from producto where codigoP='" + code + "'";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta,conexion.abrirConexion());
            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            int resultado = dt.Rows.Count;
            return resultado;
        }

    }
}
