using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vestibular.Aplication.Dtos;
using Vestibular.Aplication.Services.CandidadoService;
using Vestibular.Aplication.Services.OfertaService;

namespace Vestibular.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfertaController : ControllerBase
    {
        private readonly IOferta _ofertaService;
        public OfertaController(IOferta ofertaService)
        {
            _ofertaService = ofertaService;
        }

        /// <summary>
        /// Busca Todos as ofertas
        /// </summary>
        /// <response code="200">Retorno da busca</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var ofertas = _ofertaService.GetAllOfertas();
            return Ok(ofertas);
        }

        /// <summary>
        /// Busca a oferta pelo seu Id
        /// </summary>
        /// <response code="200">Retorno da busca</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            var oferta = _ofertaService.GetById(id);
            return Ok(oferta);
        }

        /// <summary>
        /// Cria uma nova oferta.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Retorna a oferta criada</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /
        ///     {
        ///        "nome": "Oferta #1",
        ///        "descricao": "essa é uma descrição de vaga",
        ///        "vagasdisponivies": 20
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna a oferta criada</response>
        /// <response code="400">Retorna quando há algum problema no momento do insert.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddOferta(OfertaDto dto)
        {
            var retorno = _ofertaService.AddOferta(dto);
            if (retorno == null) return BadRequest();
            return CreatedAtAction(nameof(GetAll), retorno);
        }

        /// <summary>
        /// Altera a oferta selecionado.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Retorna a oferta alterada</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT / 1
        ///     {
        ///        "nome": "Oferta #1 update",
        ///        "descricao": "essa é uma descrição de vaga",
        ///        "vagasdisponivies": 20
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Retorna o candidato alterado</response>
        /// <response code="400">Retorna quando há algum problema no momento do update.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateOferta(OfertaDto dto, int id)
        {
            var retorno = _ofertaService.UpdateOferta(dto, id);
            if (retorno == null) return BadRequest();
            return Ok(retorno);
        }

        /// <summary>
        /// Deleta a oferta pelo seu Id
        /// </summary>
        /// <response code="200">Oferta deletada</response>
        /// <response code="400">Retorna quando há algum problema no momento da exclusão.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var retorno = _ofertaService.DeleteOferta(id);
            if (retorno == null) return BadRequest();
            return Ok(retorno);
        }
    }
}
