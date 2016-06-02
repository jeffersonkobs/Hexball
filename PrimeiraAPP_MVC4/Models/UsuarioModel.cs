using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrimeiraAPP_MVC4.Models
{
    public class UsuarioModel
    {
        public int id { get; set; }
        [DisplayName("Primeiro Nome")]
        [StringLength(50, ErrorMessage = "O campo Nome permite no máximo 50 caracteres!")]
        public string nome { get; set; }
        [Required]
        [DisplayName("Sobrenome")]
        public string sobrenome { get; set; }
        [DisplayName("Endereço")]
        public string endereco { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Informe o Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
        [DisplayName("E-mail")]
        public string email { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Data de Nascimento")]
        public DateTime nascimento { get; set; }
        public char acao { get; set; }
    }
}