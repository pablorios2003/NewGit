using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos.Repositorios
{
   public  class Repositorio
    {
        private  SqlConnection conexion = new SqlConnection("Server=ORUAM;Database=Inventario; integrated security= true");


        public SqlConnection abrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }
        public SqlConnection cerrarConexion()
        {
            if(conexion.State == ConnectionState.Open)
            
                conexion.Close();
            return conexion;
            
        }
    }

}
