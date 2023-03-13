using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos.Repositorios
{
   public class CD_Prestamo
   {
        Repositorio conexion = new Repositorio();
        public DataTable TraerProducto(string Buscar)
        {
            string consulta = "Select * from producto where codigoP = '" + Buscar + "'";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta,conexion.abrirConexion());
            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            return dt;
        }
        public DataTable TraerUsuario(string Buscar)
        {
            string consulta = "Select  * from usuario where Cedula = '" + Buscar + "'";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.abrirConexion());
            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            return dt;

        }
        public void insertPrestamo(string fecha, string cedu, DataGridView productos)
        {
            int id = 0;
            SqlCommand comando = new SqlCommand(null, conexion.abrirConexion());
            comando.CommandText = "InsertPrestamo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@fechaP", fecha);
            comando.Parameters.AddWithValue("@cedu", cedu);
            comando.Parameters.AddWithValue("@idP", SqlDbType.Int).Direction = ParameterDirection.Output;

            int result = comando.ExecuteNonQuery();
            if (result > 0)
            {
                id = Convert.ToInt32(comando.Parameters["@idp"].Value);
                Console.WriteLine("Exitos, id:" + id.ToString());

            }
            conexion.cerrarConexion();
            int Contador = 0;
            foreach (DataGridViewRow row in productos.Rows)
            {
                SqlCommand commando = new SqlCommand(null,conexion.abrirConexion());
                commando.CommandText = "InsertDetPrestamo";
                commando.CommandType = CommandType.StoredProcedure;
                commando.Parameters.AddWithValue("@idP", id);
                commando.Parameters.AddWithValue("@cant", Convert.ToInt32(row.Cells["Cantidad"].Value));
                commando.Parameters.AddWithValue("@idProd", Convert.ToInt32(row.Cells["Codigo"].Value));
                int Fila = commando.ExecuteNonQuery();
                Contador += Fila;
            };
            if (Contador > 0)
            {
                Console.WriteLine("Exitos, cantidad:" + Contador.ToString());
            }
        }
        public void LIstaPrestamo(DataGridView vista)
        {
            string consulta = "Select * from Completa where cantidad > 0";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.abrirConexion());
            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            vista.DataSource = dt;
            vista.Columns["Cedula"].DisplayIndex = 0;
            vista.Columns["Nombre"].DisplayIndex = 1;
            vista.Columns["Apellido"].DisplayIndex = 2;
            vista.Columns["Codigo"].DisplayIndex = 3;
            vista.Columns["Producto"].DisplayIndex = 4;
            vista.Columns["cantidad"].DisplayIndex = 5;
            vista.Columns["Fecha_Prestamo"].DisplayIndex = 6;
            vista.Columns["ID"].DisplayIndex = 7;
            vista.Columns["Entregar"].DisplayIndex = 8;
            vista.Columns["Devolver"].DisplayIndex = 9;
                

        }
        public int BuscarPrestamo(DataGridView vista, string buscar)
        {
            string consulta = "Select * from Completa where Cedula  like '%" + buscar + "%' and cantidad >0  or Codigo like     '%" + buscar + "%' and cantidad > 0";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.abrirConexion());
            DataTable dt = new DataTable();
            int Resultado = adaptador.Fill(dt);

            vista.DataSource = dt;
            vista.Columns["Cedula"].DisplayIndex = 0;
            vista.Columns["Nombre"].DisplayIndex = 1;
            vista.Columns["Apellido"].DisplayIndex = 2;
            vista.Columns["Codigo"].DisplayIndex = 3;
            vista.Columns["Producto"].DisplayIndex = 4;
            vista.Columns["cantidad"].DisplayIndex = 5;
            vista.Columns["Fecha_Prestamo"].DisplayIndex = 6;
            vista.Columns["ID"].DisplayIndex = 7;
            vista.Columns["Entregar"].DisplayIndex = 8;
            vista.Columns["Devolver"].DisplayIndex = 9;

            return Resultado;
        }
        public DataTable TraerDatos(DataGridView vista, string buscar)
        {
            string consulta = "Select * from Devolver where Cedula = '" + buscar + "' or Codigo = '" + buscar + "'";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.abrirConexion());
            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            return dt;
        }
        public void InsertDevolucion(string Idproduct, string cantD, string fecha, string idPrestamo)
        {
            SqlCommand comando = new SqlCommand(null, conexion.abrirConexion());
            comando.CommandText = "SP_SumStock";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idP", idPrestamo);
            comando.Parameters.AddWithValue("@CantD", cantD);
            comando.Parameters.AddWithValue("@fecha", fecha);
            comando.Parameters.AddWithValue("@idProdcut", Idproduct);
            comando.ExecuteNonQuery();
            conexion.cerrarConexion();
        }
    }
}
