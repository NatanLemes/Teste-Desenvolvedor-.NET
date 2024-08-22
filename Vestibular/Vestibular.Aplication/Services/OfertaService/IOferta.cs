using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vestibular.Aplication.Dtos;
using Vestibular.Domain.Entities;

namespace Vestibular.Aplication.Services.OfertaService
{
    public interface IOferta
    {
        OfertaDto AddOferta(OfertaDto oferta);
        List<Oferta> GetAllOfertas();
        Oferta GetById(int id);
        OfertaDto UpdateOferta(OfertaDto ofertaUpdate, int id);
        Oferta DeleteOferta(int id);
    }
}
