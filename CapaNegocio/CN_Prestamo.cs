using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.Repositorios;

namespace CapaNegocio
{
   public class CN_Prestamo
    {
        CD_Prestamo Prestamo = new CD_Prestamo();
        public DataTable TraerProd(string Buscar)
        {
           DataTable P = Prestamo.TraerProducto(Buscar);
            return P;
        }
        public DataTable TraerUser(string Buscar)
        {
            DataTable U = Prestamo.TraerUsuario(Buscar);
            return U;
        }
        public void InsertPrestamo(string fecha, string cedu, DataGridView productos)
        {
            Prestamo.insertPrestamo(fecha,cedu,productos);
        }
        public void ListaPrest(DataGridView vista)
        {
            Prestamo.LIstaPrestamo(vista);
        }
        public int BuscarPrestamo(DataGridView vista, string buscar)
        {
           int result = Prestamo.BuscarPrestamo(vista,buscar);
            return result;
        }
        public DataTable TraerDatos(DataGridView vista, string buscar)
        {
          DataTable T = Prestamo.TraerDatos(vista, buscar);
            return T;
        }
        public void InsertDevolucion(string Idproduct, string cantD, string fecha, string idPrestamo)
        {
            Prestamo.InsertDevolucion(Idproduct, cantD, fecha, idPrestamo);
        }
    }
}
