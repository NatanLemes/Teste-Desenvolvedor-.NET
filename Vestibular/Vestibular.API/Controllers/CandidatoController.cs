using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Vestibular.Infraestrutura.Context;

namespace Vestibular.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatoController : ControllerBase
    {
        private VestibularDbContext _context;

        public CandidatoController(VestibularDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var candidatos = _context.Candidatos.ToList();
            return Ok(candidatos);
        }

        //[HttpPost]
        //public IActionResult AddCandidato()
        //{
        //    var candidatos = _context.Candidatos.ToList();
        //    return Ok(candidatos);
        //}
    }
}
