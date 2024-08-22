using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vestibular.Aplication.Dtos
{
    public class CandidatoDto
    {
        [Required(ErrorMessage = "Campo nome obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo email obrigatório")]
        [EmailAddress(ErrorMessage ="Email invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo telefone obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo cpf obrigatório")]
        public string Cpf { get; set; }
    }
}
