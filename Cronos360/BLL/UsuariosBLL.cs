using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cronos360.CENT;
using Cronos360.DAL;

namespace Cronos360.BLL
{
    public class UsuariosBLL
    {
        public UsuariosDAL _usuariosDAL = new UsuariosDAL();

        public int ValidarUsuario(string usuario, string contraseña)
        {
            UsuariosDAL _usuariosDAL = new UsuariosDAL();
            return _usuariosDAL.ObtenerRolUsuario(usuario, contraseña);
        }
    }
}
