using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Vestibular.Aplication.Dtos;
using Vestibular.Aplication.Services.CandidadoService;
using Vestibular.Infraestrutura.Context;

namespace Vestibular.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidato _candidatoService;
        public CandidatoController(ICandidato candidatoService)
        {
            _candidatoService = candidatoService;
        }

        /// <summary>
        /// Busca Todos os candidatos
        /// </summary>
        /// <response code="200">Retorno da busca</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var candidatos = _candidatoService.GetAllCandidatos();
            return Ok(candidatos);
        }

        /// <summary>
        /// Busca o candidato pelo seu Id
        /// </summary>
        /// <response code="200">Retorno da busca</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            var candidato = _candidatoService.GetById(id);
            return Ok(candidato);
        }

        /// <summary>
        /// Cria um novo candidato.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Retorna o Candidato criado</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /
        ///     {
        ///        "nome": "Candidato #1",
        ///        "email": "candidato1@gmail.com",
        ///        "telefone": "21999999999",
        ///        "cpf": "22222222222"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna o candidato criado</response>
        /// <response code="400">Retorna quando há algum problema no momento do insert.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddCandidato(CandidatoDto dto)
        {
            var retorno = _candidatoService.AddCandidato(dto);
            if (retorno == null)return BadRequest();    
            return CreatedAtAction(nameof(GetAll),retorno);
        }

        /// <summary>
        /// Altera o candidato selecionado.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Retorna o Candidato alterado</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT / 1
        ///     {
        ///        "nome": "Candidato #1",
        ///        "email": "candidato1@gmail.com",
        ///        "telefone": "21999999999",
        ///        "cpf": "22222222222"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Retorna o candidato alterado</response>
        /// <response code="400">Retorna quando há algum problema no momento do update.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateCandidato(CandidatoDto dto, int id)
        {
            var retorno = _candidatoService.UpdateCandidato(dto, id);
            if (retorno == null) return BadRequest();
            return Ok( retorno);
        }

        /// <summary>
        /// Deleta o candidato pelo seu Id
        /// </summary>
        /// <response code="200">Candidato deletado</response>
        /// <response code="400">Retorna quando há algum problema no momento da exclusão.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var retorno = _candidatoService.DeleteCandidato(id);
            if (retorno == null) return BadRequest();
            return Ok(retorno);
        }
    }
}
