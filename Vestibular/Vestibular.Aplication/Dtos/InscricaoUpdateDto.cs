using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vestibular.Aplication.Enums;

namespace Vestibular.Aplication.Dtos
{
    public class InscricaoUpdateDto
    {
        [Required]
        public EStatus Status { get; set; }
    }
}
