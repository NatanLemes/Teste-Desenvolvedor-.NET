using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vestibular.Aplication.Dtos;
using Vestibular.Domain.Entities;

namespace Vestibular.Aplication.Services.InscricaoService
{
    public interface IInscricao
    {
        InscricaoDto AddInscricao(InscricaoDto inscricao);
        List<Inscricao> GetAllInscricoes();
        Inscricao GetById(int id);
        Inscricao UpdateInscricao(InscricaoUpdateDto inscricaoStatus, int id);
        Inscricao DeleteInscricao(int id);
        List<Inscricao> InscricaoPorCpf(string cpf);
        List<Inscricao> InscricaoPorOferta(int idOferta);
    }
}
