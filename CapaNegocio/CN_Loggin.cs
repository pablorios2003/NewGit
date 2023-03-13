using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Repositorios;

namespace CapaNegocio
{
   public class CN_Loggin
    {
        CD_Loggin objectoCD = new CD_Loggin();

        public int validar(string User,string pass)
        {
           int result = objectoCD.ValidarLogin(User, pass);
            return result;
        }
    }
}
