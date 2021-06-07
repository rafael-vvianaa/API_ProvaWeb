using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProvaWeb.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(200, ErrorMessage = "Este campo deve conter entre 5 e 200 caracteres")]
        [MinLength(5, ErrorMessage = "Este campo deve conter entre 5 e 200 caracteres")]
        public string Nome { get; set; }

        [MaxLength(500, ErrorMessage = "Este campo deve conter no máximo 500 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal Matricula { get; set; }

        public DateTime DataDeCadastro  { get; set; }
        
    }
}

