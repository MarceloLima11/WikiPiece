using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiPiece.Data;
using WikiPiece.Models;

namespace WikiPiece.Controllers
{
    [ApiController]
    [Route("v1/[Controller]")]
    public class IlhaController : ControllerBase
    {
        private readonly WikiPieceContext _context;

        public IlhaController(WikiPieceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ilha>> GetAll()
        {
            var ilhas = _context.Ilhas.ToList();
            return ilhas;
        }   

        [HttpGet("{id}")]
        public ActionResult<Ilha> GetById([FromRoute] int id)
        {
            var ilha = _context.Ilhas.FirstOrDefault(x => x.Id == id);
            return ilha;
        }

        [HttpGet("Regiao")]
        public ActionResult<IEnumerable<Ilha>> GetByRegiao(string regiao)
        {
            var ilhasRegiao =_context.Ilhas.Where(x => x.Regiao == regiao).ToList();
            return ilhasRegiao;
        }

        [HttpGet("Clima")]
        public ActionResult<IEnumerable<Ilha>> GetByClima(string clima)
        {
            var ilhasClima = _context.Ilhas.Where(x => x.Clima == clima).ToList();
            return ilhasClima;
        }

        [HttpPost]
        public ActionResult<Ilha> Post([FromBody] Ilha ilha)
        {
            _context.Ilhas.Add(ilha);
            _context.SaveChanges();
            return ilha;
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Ilha newIlha)
        {
            var oldIlha = _context.Ilhas.FirstOrDefault(x => x.Id == id);
            _context.Entry(oldIlha).State = EntityState.Modified;
            _context.Update(newIlha);

            return NoContent();
        }
    }
}