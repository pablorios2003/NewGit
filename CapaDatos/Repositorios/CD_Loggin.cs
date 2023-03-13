using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorios
{
   public class CD_Loggin
    {
        private Repositorio conexion = new Repositorio();
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public int ValidarLogin(string name , string pass)
        {
            string consulta = "select * from Cuentas where NameUser='" + name + "' and Pass = '" + pass + "'";
            conexion.abrirConexion();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta,conexion.abrirConexion());
            adaptador.Fill(tabla);
            conexion.cerrarConexion();

            int result = tabla.Rows.Count;
            return result;

        }

        //Falta Terminar
        public int CambioPassword(string strEmail, string strNombre)
        {
            //CONSULTAMOS LA EXISTENCIA DEL USUARIO
            string consulta = "select * from Cuentas where Email='" + strEmail + "' and NameUser = '" + strNombre + "'";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.abrirConexion());
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            conexion.cerrarConexion();

            //GUARDAMOS EL RESULTADO PARA RETORNARLO Y PODER HACER VALIDACION
            int result = dt.Rows.Count;
            return result;
        }

        public void UpdatePassword(string strEmail, string strPassword)
        {
            string update = "Update Cuentas  set Pass = @Pass where Email = @Email";
            SqlCommand comando = new SqlCommand(update, conexion.abrirConexion());
            comando.Parameters.AddWithValue("@Pass", strPassword);
            comando.Parameters.AddWithValue("@Email", strEmail);
            comando.ExecuteNonQuery();
            conexion.cerrarConexion();
        }
    }

}
