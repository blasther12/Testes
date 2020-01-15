using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersService.Models;

namespace UsersService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // GET: api/Login
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Post([FromBody]Usuario usuario)
        {
            Usuario user = new Usuario();
            try
            {
                user = _context.Usuarios.FirstOrDefault(x => x.NmUsuario == usuario.NmUsuario && x.Senha == usuario.Senha);
            }
            catch
            {
                user = null;
            }
            if (user == null)
                return Unauthorized();

           var token = TokenService.GenerateToken(user);

            UserAux u = new UserAux
            {
                UsuarioId = user.UsuarioId,
                NmUsuario = user.NmUsuario,
                Token = token,
                Auth = true
            };

            return Ok(u);
        }
    }
}
