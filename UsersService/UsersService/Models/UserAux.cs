using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersService.Models
{
    public class UserAux
    {
        public int UsuarioId { get; set; }
        public string NmUsuario { get; set; }
        public string Token { get; set; }
        public bool Auth { get; set; }
    }
}
