using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiPiece.Data;
using WikiPiece.Models;
using WikiPiece.Repository.Interfaces;

namespace WikiPiece.Controllers
{
    [ApiController]
    [Route("v1/[Controller]")]
    public class IlhaController : ControllerBase
    {
        private readonly IIlhaRepository _context;

        public IlhaController(IIlhaRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ilha>> GetAll()
        {
            var ilhas = _context.Get().ToList();
            return ilhas;
        }   

        [HttpGet("{id}")]
        public ActionResult<Ilha> GetById([FromRoute] int id)
        {
            var ilha = _context.GetById(x => x.Id == id);
            return ilha;
        }

        [HttpGet("Regiao/{regiao}")]
        public ActionResult<IEnumerable<Ilha>> GetByRegiao(string regiao)
        {
            var ilhasRegiao =_context.GetByRegiao(x => x.Regiao == regiao).ToList();
            return ilhasRegiao;
        }

        [HttpGet("Clima/{clima}")]
        public ActionResult<IEnumerable<Ilha>> GetByClima(string clima)
        {
            var ilhasClima = _context.GetByClima(x => x.Clima == clima).ToList();
            return ilhasClima;
        }

        [HttpPost]
        public ActionResult<Ilha> Post([FromBody] Ilha ilha)
        {
            _context.Add(ilha);
            return ilha;
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Ilha newIlha)
        {
            _context.Update(newIlha);
            
            return NoContent();
        }
    }
}