using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrimeiraAPP_MVC4.Models
{
    public class ExerciciosModels
    {
        public int id { get; set; }
        [DisplayName("Categoria")]
        [Required]
        public int categoria { get; set; }
        [Required]
        [DisplayName("Dificuldade")]
        public int dificuldade { get; set; }
        [DisplayName("Descrição")]
        public string descricao { get; set; }
        [DisplayName("Repetições")]
        public int repeticoes { get; set; }
        [DisplayName("ID do Treinamento")]
        public int treinamentos_id { get; set; }
        [DisplayName("Nome do Treinamento")]
        public string treinamentos_nome { get; set; }
    }
}