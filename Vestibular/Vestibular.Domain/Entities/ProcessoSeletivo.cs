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
    [Table("processo_seletivo")]

    public class ProcessoSeletivo
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        [Column("data_inicio")]
        public DateTime DataInicio { get; set; }

        [Column("data_termino")]
        public DateTime DataFim { get; set; }
        public List<Inscricao> Inscricoes { get; set; }

    }
}
