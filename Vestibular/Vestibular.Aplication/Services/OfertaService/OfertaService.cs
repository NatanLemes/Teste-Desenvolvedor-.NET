using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vestibular.Aplication.Dtos;
using Vestibular.Aplication.Services.CandidadoService;
using Vestibular.Domain.Entities;
using Vestibular.Infraestrutura.Context;

namespace Vestibular.Aplication.Services.OfertaService
{
    public class OfertaService : IOferta
    {
        private readonly VestibularDbContext _context;

        public OfertaService(VestibularDbContext context)
        {
            _context = context;
        }
        public OfertaDto AddOferta(OfertaDto oferta)
        {
            try
            {
                var ofertaInsert = new Oferta()
                {
                    Nome = oferta.Nome,
                    Descricao = oferta.Descricao,
                    VagasDisponiveis = oferta.VagasDisponiveis,
                };

                _context.Ofertas.Add(ofertaInsert);
                _context.SaveChanges();
                return oferta;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Oferta DeleteOferta(int id)
        {
            try
            {
                var ofertaDelete = _context.Ofertas.FirstOrDefault(x => x.Id == id);
                if (ofertaDelete == null) return ofertaDelete;

                _context.Ofertas.Remove(ofertaDelete);
                _context.SaveChanges();
                return ofertaDelete;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Oferta> GetAllOfertas()
        {
            try
            {
                var lstOfertas = _context.Ofertas.ToList();
                //lstCandidatos.ForEach(x => x.Inscricoes.AddRange(_context.Inscricoes.Where(i => i.IdCandidato == x.Id).ToList()));

                return lstOfertas;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Oferta GetById(int id)
        {
            try
            {
                var ofertaBusca = _context.Ofertas.FirstOrDefault(x => x.Id == id);

                return ofertaBusca;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public OfertaDto UpdateOferta(OfertaDto ofertaUpdate, int id)
        {
            try
            {
                var ofertaAntiga = _context.Ofertas.FirstOrDefault(x => x.Id == id);

                ofertaAntiga.Nome = ofertaUpdate.Nome;
                ofertaAntiga.Descricao = ofertaUpdate.Descricao;
                ofertaAntiga.VagasDisponiveis = ofertaUpdate.VagasDisponiveis;

                _context.Ofertas.Update(ofertaAntiga);
                _context.SaveChanges();
                return ofertaUpdate;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
