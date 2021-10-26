using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDalisa.Models;
using ProyectoDalisa.Entity;

namespace ProyectoDalisa.Services
{
    interface IdaoUsuario<U>
    {
         Usuario Logueo(string usu, string pas);

        void ActualizarUsuario(U u);

        void ActualizarPassword(U u);
    }
    
}
