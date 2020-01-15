using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UsersService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InicioController : ControllerBase
    {
        // GET: api/Inicio
        [HttpGet]
        public Inicio Get()
        {
            Inicio ini = new Inicio
            {
                Descricao = "Dados para teste abaixo",
                Usuario = "nmUsuario",
                Senha = "senha",
            };
            return ini;
        }  
    }
}
