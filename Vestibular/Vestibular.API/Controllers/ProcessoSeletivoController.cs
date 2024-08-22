using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vestibular.Aplication.Dtos;
using Vestibular.Aplication.Services.CandidadoService;
using Vestibular.Aplication.Services.ProcessoSeletivoService;
using Vestibular.Domain.Entities;

namespace Vestibular.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessoSeletivoController : ControllerBase
    {
        private readonly IProcessoSeletivo _processoService;
        public ProcessoSeletivoController(IProcessoSeletivo processoService)
        {
            _processoService = processoService;
        }

        /// <summary>
        /// Busca Todos os processos
        /// </summary>
        /// <response code="200">Retorno da busca</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var processos = _processoService.GetAllProcessos();
            return Ok(processos);
        }

        /// <summary>
        /// Busca o processo pelo seu Id
        /// </summary>
        /// <response code="200">Retorno da busca</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            var processo = _processoService.GetById(id);
            return Ok(processo);
        }

        /// <summary>
        /// Cria um novo processo seletivo.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Retorna o processo criado</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /
        ///     {
        ///        "nome": "Processo #1",
        ///        "dataInicio": "2024-08-20",
        ///        "dataFim": "2024-08-21"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna o processo criado</response>
        /// <response code="400">Retorna quando há algum problema no momento do insert.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddProcesso(ProcessoSeletivoDto dto)
        {
            var retorno = _processoService.AddProcessoSeletivo(dto);
            if (retorno == null) return BadRequest();
            return CreatedAtAction(nameof(GetAll), retorno);
        }

        /// <summary>
        /// Altera o processo selecionado.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Retorna o processo alterado</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT / 1
        ///     {
        ///        "nome": "Processo #1",
        ///        "dataInicio": "2024-08-20",
        ///        "dataFim": "2024-08-21"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Retorna o processo alterado</response>
        /// <response code="400">Retorna quando há algum problema no momento do update.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateProcesso(ProcessoSeletivoDto dto, int id)
        {
            var retorno = _processoService.UpdateProcesso(dto, id);
            if (retorno == null) return BadRequest();
            return Ok(retorno);
        }

        /// <summary>
        /// Deleta o processo pelo seu Id
        /// </summary>
        /// <response code="200">processo deletado</response>
        /// <response code="400">Retorna quando há algum problema no momento da exclusão.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var retorno = _processoService.DeleteProcesso(id);
            if (retorno == null) return BadRequest();
            return Ok(retorno);
        }
    }
}
