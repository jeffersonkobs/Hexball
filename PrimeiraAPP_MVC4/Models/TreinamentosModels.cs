using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrimeiraAPP_MVC4.Models
{
    public class TreinamentosModels
    {
        public int id { get; set; }
        [DisplayName("Nome do Treinamento")]
        [StringLength(50, ErrorMessage = "O campo Nome permite no máximo 100 caracteres!")]
        [Required]
        public string nome { get; set; }
        [Required]
        [DisplayName("Atleta")]
        public int atletas_id { get; set; }
        [DisplayName("Nome do Atleta")]
        public string atletas_nome { get; set; }    
        [DataType(DataType.Date)]
        [DisplayName("Data de Treinamento")]
        public DateTime data_hora { get; set; }
     }
}