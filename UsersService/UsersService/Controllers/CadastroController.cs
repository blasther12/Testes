using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersService.Models;

namespace UsersService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly Context _context;

        public CadastroController(Context context)
        {
            _context = context;
        }
        // GET: api/Cadastro
        [Authorize]
        [HttpGet(Name = "Retorna_Usuarios")]
        public IEnumerable<Usuario> Get()
        {
            List<Usuario> usuarios = _context.Usuarios.ToList(); //realiza busca do usuarios no banco
            return usuarios;
        }

        // GET: api/Cadastro/5
        [Authorize]
        [HttpGet("{id}", Name = "Retorna_Usuario")]
        public Usuario Get(int id)
        {       
            Usuario usuario = _context.Usuarios.FirstOrDefault(x => x.UsuarioId == id); //realiza busca do usuario no banco
            return usuario;
        }

        // POST: api/Cadastro
        [HttpPost(Name = "Cadastra usuario")]
        public async Task<ActionResult> PostAsync([FromBody] Usuario value)
        {
            Usuario user = new Usuario();
            try
            {
                user = _context.Usuarios.FirstOrDefault(x => x.NmUsuario == value.NmUsuario); //realiza busca do usuario no banco
            }
            catch
            {
                user = null;
            }
            if (user != null)
                return Unauthorized();//Caso não exista retorna erro

            await _context.Usuarios.AddAsync(value); //Cria Usuario
            await _context.SaveChangesAsync(); //Realiza o commit
            return Ok();
        }

        // PUT: api/Cadastro/5
        [HttpPut("{id}", Name = "Altera_Usuario")]
        [Authorize]
        public async Task<ActionResult> Put(int id, [FromBody] Usuario value)
        {
            //Altaração de Nome e Senha
            Usuario usuario = new Usuario();
            try
            {
                 usuario = _context.Usuarios.FirstOrDefault(x => x.UsuarioId == id); //realiza busca do usuario no banco
            }
            catch
            {
                usuario = null;
            }

            if (usuario == null)
                return Unauthorized();//Caso não exista retorna erro

            usuario.NmUsuario = value.NmUsuario == null ? usuario.NmUsuario = usuario.NmUsuario : usuario.NmUsuario = value.NmUsuario; //verifica se NmUsuario é nulo
            usuario.Senha = value.Senha == null ? usuario.Senha = usuario.Senha : usuario.Senha = value.Senha; //verifica se Senha é nulo

            usuario.DataAtualizacao = DateTime.Now;

            _context.Update(usuario); // Altera usuario
            await _context.SaveChangesAsync(); //Realiza o commit
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "Exclui Usuario Selecionado")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(x => x.UsuarioId == id); //realiza busca do usuario no banco

            if (usuario == null)
                return Unauthorized();//Caso não exista retorna erro

            _context.Remove(usuario); //Realiza Exclusão do Usuario
            await _context.SaveChangesAsync(); //Realiza o commit

            return Ok();
        }
    }
}
