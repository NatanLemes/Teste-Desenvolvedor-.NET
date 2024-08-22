using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vestibular.Aplication.Dtos;
using Vestibular.Aplication.Services.CandidadoService;
using Vestibular.Domain.Entities;
using Vestibular.Infraestrutura.Context;

namespace Vestibular.Aplication.Services.ProcessoSeletivoService
{
    public class ProcessoSeletivoService : IProcessoSeletivo
    {
        private readonly VestibularDbContext _context;

        public ProcessoSeletivoService(VestibularDbContext context)
        {
            _context = context;
        }

        public ProcessoSeletivoDto AddProcessoSeletivo(ProcessoSeletivoDto processo)
        {
            try
            {
                var processoInsert = new ProcessoSeletivo()
                {
                    Nome = processo.Nome,
                    DataFim = processo.DataFim,
                    DataInicio = processo.DataInicio
                };

                _context.ProcessosSeletivos.Add(processoInsert);
                _context.SaveChanges();
                return processo;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ProcessoSeletivo DeleteProcesso(int id)
        {
            try
            {
                var processoDelete = _context.ProcessosSeletivos.FirstOrDefault(x => x.Id == id);
                if (processoDelete == null) return processoDelete;

                _context.ProcessosSeletivos.Remove(processoDelete);
                _context.SaveChanges();
                return processoDelete;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<ProcessoSeletivo> GetAllProcessos()
        {
            try
            {
                var lstProcessos = _context.ProcessosSeletivos.ToList();
                //lstProcessos.ForEach(x => x.Inscricoes.AddRange(_context.Inscricoes.Where(i => i.IdProcessoSeletivo == x.Id).ToList()));

                return lstProcessos;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ProcessoSeletivo GetById(int id)
        {
            try
            {
                var processoBusca = _context.ProcessosSeletivos.FirstOrDefault(x => x.Id == id);

                return processoBusca;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ProcessoSeletivoDto UpdateProcesso(ProcessoSeletivoDto processoUpdate, int id)
        {
            try
            {
                var processoAntigo = _context.ProcessosSeletivos.FirstOrDefault(x => x.Id == id);

                processoAntigo.Nome = processoUpdate.Nome;
                processoAntigo.DataFim = processoUpdate.DataFim;
                processoAntigo.DataInicio = processoUpdate.DataInicio;

                _context.ProcessosSeletivos.Update(processoAntigo);
                _context.SaveChanges();
                return processoUpdate;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
