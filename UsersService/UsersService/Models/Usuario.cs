using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UsersService.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public Usuario()
        {
            DataCriacao = DateTime.Now;
            IeSituacao = "A";
        }
        [Key]
        public int UsuarioId { get; set; }
        public string NmUsuario { get; set; }
        [Display(Name = "Senha")]
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string IeSituacao { get; set; }
        public string Role { get; set; }
    }
}
