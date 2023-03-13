using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Repositorios;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objectoCD = new CD_Productos();

        public DataTable mostrarProdu()
        {
            DataTable tabla = new DataTable();
            tabla = objectoCD.Mostrar();
            return tabla;
        }
        public void InsertarProd (string codigoP, string nomP, string stock, string categoria)
        {
            objectoCD.Insertar(codigoP, nomP, Convert.ToInt32(stock), categoria);
        }
        public void UpdateProd(string codigoP, string nomP, string stock, string categoria)
        {
            objectoCD.Editar(codigoP,nomP,Convert.ToInt32(stock),categoria);
        }
        public void EliminarProd(string codigo)
        {
            objectoCD.Eliminar(codigo);
        }
        public int ExistenciaProd(string codigo)
        {
          int result =  objectoCD.Existencia(codigo);
            return result;
        }
    }
}
