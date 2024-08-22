using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vestibular.Aplication.Enums;

namespace Vestibular.Aplication.Dtos
{
    public class InscricaoDto
    {
        [Required(ErrorMessage = "Campo candidato obrigatório")]
        public int IdCandidato { get; set; }

        [Required(ErrorMessage = "Campo processo seletivo obrigatório")]
        public int IdProcessoSeletivo { get; set; }

        [Required(ErrorMessage = "Campo oferta obrigatório")]
        public int IdOferta { get; set; }
    }
}
