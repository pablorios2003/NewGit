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
    public  class CN_Usuario
    {
        private   CD_Usuario objectoCD = new CD_Usuario();
        public DataTable mostrarUsu()
        {
            DataTable tabla = new DataTable();
            tabla = objectoCD.Mostrar();
            return tabla;
        }
        public void InsertarUsu(string cedula, string nombre, string apellido, string celular, string email, string rol)
        {
            objectoCD.Insertar(cedula,nombre,apellido,celular,email,rol);
        }
        public void UpdateUsu(string cedula, string nombre, string apellido, string celular, string email, string rol)
        {
            objectoCD.Editar(cedula, nombre, apellido, celular, email, rol);
        }
        public void EliminarUsu(string cedula)
        {
            objectoCD.Eliminar(cedula);
        }
        public void FiltrarUsuario(string cedula, DataGridView vista)
        {
            objectoCD.FiltrarUsuario(cedula, vista);
        }
        public int ExitenciaUsuario(string cedula)
        {
           int result = objectoCD.Exitencia(cedula);
            return result;
        }

    }
}
  