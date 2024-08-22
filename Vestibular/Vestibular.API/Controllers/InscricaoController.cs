using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vestibular.Aplication.Dtos;
using Vestibular.Aplication.Services.CandidadoService;
using Vestibular.Aplication.Services.InscricaoService;

namespace Vestibular.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InscricaoController : ControllerBase
    {
        private readonly IInscricao _inscricaoService;
        public InscricaoController(IInscricao inscricaoService)
        {
            _inscricaoService = inscricaoService;
        }

        /// <summary>
        /// Busca Todas as inscricoes
        /// </summary>
        /// <response code="200">Retorno da busca</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var inscricoes = _inscricaoService.GetAllInscricoes();
            return Ok(inscricoes);
        }

        /// <summary>
        /// Busca a inscricao pelo seu Id
        /// </summary>
        /// <response code="200">Retorno da busca</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            var inscricao = _inscricaoService.GetById(id);
            return Ok(inscricao);
        }

        /// <summary>
        /// Cria uma nova inscricao.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Retorna o Candidato criado</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /
        ///     {
        ///        "IdCandidato": 1,
        ///        "IdOferta": 1,
        ///        "IdProcessoSeletivo": 1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna a inscricao criada</response>
        /// <response code="400">Retorna quando há algum problema no momento do insert.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddCandidato(InscricaoDto dto)
        {
            var retorno = _inscricaoService.AddInscricao(dto);
            if (retorno == null) return BadRequest();
            return CreatedAtAction(nameof(GetAll), retorno);
        }

        /// <summary>
        /// Altera a inscricao selecionada.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Retorna a inscricao alterado</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT / 1
        ///     {
        ///        "status":"Aprovada"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Retorna a inscricao alterado</response>
        /// <response code="400">Retorna quando há algum problema no momento do update.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateInscricao([FromForm] InscricaoUpdateDto model, int id)
        {
            var retorno = _inscricaoService.UpdateInscricao(model, id);
            if (retorno == null) return BadRequest();
            return Ok(retorno);
        }

        /// <summary>
        /// Deleta a inscricao pelo seu Id
        /// </summary>
        /// <response code="200">Candidato deletado</response>
        /// <response code="400">Retorna quando há algum problema no momento da exclusão.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var retorno = _inscricaoService.DeleteInscricao(id);
            if (retorno == null) return BadRequest();
            return Ok(retorno);
        }

        /// <summary>
        /// Busca todas as inscrições de um determinado CPF
        /// </summary>
        /// <response code="200">Retorno da busca</response>
        [HttpGet("byCpf/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetbyCpf(string cpf)
        {
            var inscricao = _inscricaoService.InscricaoPorCpf(cpf);
            return Ok(inscricao);
        }

        /// <summary>
        /// Busca todas as inscrições de um determinado CPF
        /// </summary>
        /// <response code="200">Retorno da busca</response>
        [HttpGet("ByOferta/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetByOferta(int id)
        {
            var inscricao = _inscricaoService.InscricaoPorOferta(id);
            return Ok(inscricao);
        }
    }
}
