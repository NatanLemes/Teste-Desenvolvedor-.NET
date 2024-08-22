using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vestibular.Aplication.Dtos;
using Vestibular.Domain.Entities;

namespace Vestibular.Aplication.Services.CandidadoService
{
    public interface ICandidato
    {
        CandidatoDto AddCandidato(CandidatoDto candidato);
        List<Candidato> GetAllCandidatos();
        Candidato GetById(int id);
        CandidatoDto UpdateCandidato(CandidatoDto candidatoUpdate, int id);
        Candidato DeleteCandidato(int id);
    }
}
