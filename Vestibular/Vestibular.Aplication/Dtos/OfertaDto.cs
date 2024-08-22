using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vestibular.Aplication.Dtos
{
    public class OfertaDto
    {
        [Required(ErrorMessage = "Campo nome obrigatório")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo quanitdade de vagas obrigatório")]
        public int VagasDisponiveis { get; set; }
    }
}
