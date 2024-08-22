using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vestibular.Aplication.Dtos;
using Vestibular.Aplication.Enums;
using Vestibular.Domain.Entities;
using Vestibular.Infraestrutura.Context;

namespace Vestibular.Aplication.Services.CandidadoService
{
    public class CandidatoService : ICandidato
    {

        private readonly VestibularDbContext _context;

        public CandidatoService(VestibularDbContext context)
        {
            _context = context;
        }

        public CandidatoDto AddCandidato(CandidatoDto candidato)
        {
            try
            {
                var candidatoInsert = new Candidato()
                {
                    Nome = candidato.Nome,
                    Email = candidato.Email,
                    Telefone = candidato.Telefone,
                    CPF =  candidato.Cpf,
                };

                _context.Candidatos.Add(candidatoInsert);
                _context.SaveChanges();
                return candidato;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Candidato DeleteCandidato(int id)
        {
            try
            {
                //quando deletar um candidado, sua inscricao fica como cancelada
                var candidatoDelete = _context.Candidatos.FirstOrDefault(x => x.Id == id);
                if (candidatoDelete == null) return candidatoDelete;

                
                var lstInscricoesCancelar = _context.Inscricoes.Where(x => x.IdCandidato == candidatoDelete.Id).ToList();
                lstInscricoesCancelar.ForEach(x => x.Status = EStatus.Cancelada.ToString());
                lstInscricoesCancelar.ForEach(x => _context.Inscricoes.Update(x));

                _context.Candidatos.Remove(candidatoDelete);
                _context.SaveChanges();
                return candidatoDelete;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Candidato> GetAllCandidatos()
        {
            try
            {
                var lstCandidatos = _context.Candidatos.ToList();
                //lstCandidatos.ForEach(x => x.Inscricoes.AddRange(_context.Inscricoes.Where(i => i.IdCandidato == x.Id).ToList()));


                return lstCandidatos;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Candidato GetById(int id)
        {
            try
            {
                var candidatoBusca =  _context.Candidatos.FirstOrDefault(x => x.Id == id);

                return candidatoBusca;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CandidatoDto UpdateCandidato(CandidatoDto candidatoUpdate, int id)
        {
            try
            {
                var candidatoAntigo = _context.Candidatos.FirstOrDefault(x => x.Id == id);

                candidatoAntigo.Nome = candidatoUpdate.Nome;
                candidatoAntigo.Email = candidatoUpdate.Email;
                candidatoAntigo.Telefone = candidatoUpdate.Telefone;
                candidatoAntigo.CPF = candidatoUpdate.Cpf;

                _context.Candidatos.Update(candidatoAntigo);
                _context.SaveChanges();
                return candidatoUpdate;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
