using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vestibular.Aplication.Dtos;
using Vestibular.Aplication.Enums;
using Vestibular.Aplication.Services.CandidadoService;
using Vestibular.Domain.Entities;
using Vestibular.Infraestrutura.Context;

namespace Vestibular.Aplication.Services.InscricaoService
{
    public class InscricaoService : IInscricao
    {
        private readonly VestibularDbContext _context;

        public InscricaoService(VestibularDbContext context)
        {
            _context = context;
        }

        public InscricaoDto AddInscricao(InscricaoDto inscricao)
        {
            try
            {

                var inscicaoInsert = new Inscricao()
                {
                    NumeroInscricao = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper(),
                    Data = DateTime.Now,
                    Status = EStatus.EmAndamento.ToString(),
                    IdCandidato = inscricao.IdCandidato,
                    IdOferta = inscricao.IdOferta,
                    IdProcessoSeletivo = inscricao.IdProcessoSeletivo,
                };

                //candidato.Inscricoes.Add(inscicaoInsert);
                //oferta.Inscricoes.Add(inscicaoInsert);
                //processo.Inscricoes.Add(inscicaoInsert);

                _context.Inscricoes.Add(inscicaoInsert);
                _context.SaveChanges();
                return inscricao;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Inscricao DeleteInscricao(int id)
        {
            try
            {
                var inscricaoDelete = _context.Inscricoes.FirstOrDefault(x => x.Id == id);
                if (inscricaoDelete == null) return inscricaoDelete;

                _context.Inscricoes.Remove(inscricaoDelete);
                _context.SaveChanges();
                return inscricaoDelete;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Inscricao> GetAllInscricoes()
        {
            try
            {
                var lstInscricoes = _context.Inscricoes.ToList();

                //lstInscricoes.ForEach(x => x.Candidato = _context.Candidatos.FirstOrDefault(c => c.Id == x.IdCandidato));
                //lstInscricoes.ForEach(x => x.Oferta = _context.Ofertas.FirstOrDefault(c => c.Id == x.IdOferta));
                //lstInscricoes.ForEach(x => x.ProcessoSeletivo = _context.ProcessosSeletivos.FirstOrDefault(c => c.Id == x.IdProcessoSeletivo));

                return lstInscricoes;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Inscricao GetById(int id)
        {
            try
            {
                var inscricaoBusca = _context.Inscricoes.FirstOrDefault(x => x.Id == id);
                //inscricaoBusca.Candidato = _context.Candidatos.FirstOrDefault(c => c.Id == inscricaoBusca.IdCandidato);
                //inscricaoBusca.Oferta = _context.Ofertas.FirstOrDefault(c => c.Id == inscricaoBusca.IdOferta);
                //inscricaoBusca.ProcessoSeletivo = _context.ProcessosSeletivos.FirstOrDefault(c => c.Id == inscricaoBusca.IdProcessoSeletivo);

                return inscricaoBusca;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Inscricao UpdateInscricao(InscricaoUpdateDto status, int id)
        {
            try
            {
                //uma inscricao nao pode alterar o seu candidado, o processo seletivo ou sua oferta. o unico campo para alterar é seu status
                var inscricaoAntiga = _context.Inscricoes.FirstOrDefault(x => x.Id == id);

                inscricaoAntiga.Status = status.Status.ToString();

                _context.Inscricoes.Update(inscricaoAntiga);
                _context.SaveChanges();
                return inscricaoAntiga;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Inscricao> InscricaoPorCpf(string cpf)
        {
            try
            {
                var candidatoSelecionado = _context.Candidatos.FirstOrDefault(x =>string.Equals(x.CPF,cpf));
                if (candidatoSelecionado == null) return null;
                var lstInscricoes = _context.Inscricoes.Where(x=>x.IdCandidato == candidatoSelecionado.Id).ToList();
                lstInscricoes.ForEach(x => x.Candidato.Inscricoes = null);

                return lstInscricoes;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Inscricao> InscricaoPorOferta(int idOferta)
        {
            try
            {
                var oferta = _context.Ofertas.FirstOrDefault(x => x.Id == idOferta);
                if (oferta == null) return null;
                var lstInscricoes = _context.Inscricoes.Where(x => x.IdOferta == oferta.Id).ToList();
                lstInscricoes.ForEach(x => x.Oferta.Inscricoes = null);

                return lstInscricoes;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
