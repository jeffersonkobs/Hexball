using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrimeiraAPP_MVC4.Models
{
    public class ExerciciosItemModels { 
        public int id { get; set; }
        [DisplayName("Exercicio")]
        [Required]
        public int exercicios_id { get; set; }
        [Required]
        [DisplayName("Tipo de Exercício")]
        public int exercicios_tipo_id { get; set; }
        [DisplayName("Nome do Tipo")]
        public string exercicios_tipo_nome { get; set; }
        [DisplayName("Lado do Lançador")]
        public int lado_lancador { get; set; }
        [DisplayName("quadrante")]
        public int quadrante { get; set; }
        [DisplayName("sequencia")]
        public int sequencia { get; set; }
    }
}