using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vestibular.Aplication.Dtos;
using Vestibular.Domain.Entities;

namespace Vestibular.Aplication.Services.ProcessoSeletivoService
{
    public interface IProcessoSeletivo
    {
        ProcessoSeletivoDto AddProcessoSeletivo(ProcessoSeletivoDto processo);
        List<ProcessoSeletivo> GetAllProcessos();
        ProcessoSeletivo GetById(int id);
        ProcessoSeletivoDto UpdateProcesso(ProcessoSeletivoDto processoUpdate, int id);
        ProcessoSeletivo DeleteProcesso(int id);
    }
}
