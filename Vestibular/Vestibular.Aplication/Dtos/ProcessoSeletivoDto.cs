using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vestibular.Aplication.Dtos
{
    public class ProcessoSeletivoDto
    {
        [Required(ErrorMessage = "Campo nome obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo data inicio obrigatório")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Campo data fim obrigatório")]
        public DateTime DataFim { get; set; }

    }
}
