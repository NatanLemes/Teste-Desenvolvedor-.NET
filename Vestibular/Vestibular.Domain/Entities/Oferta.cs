using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace Vestibular.Domain.Entities
{
    [Table("oferta")]
    public class Oferta
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [Column("vagas_disponiveis")]
        public int VagasDisponiveis { get; set; }
        public List<Inscricao> Inscricoes { get; set; }


    }
}
