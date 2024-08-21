using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vestibular.Domain.Entities
{
    [Table("inscricao")]
    public class Inscricao
    {
        [Key]
        public int Id { get; set; }
        public string NumeroInscricao { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public int? IdCandidato { get; set; }
        public int? IdProcessoSeletivo { get; set; }
        public int? IdOferta { get; set; }
        public Candidato Candidato { get; set; }
        public ProcessoSeletivo ProcessoSeletivo { get; set; }
        public Oferta Oferta { get; set; }
    }
}
