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
    public class ArcoController : ControllerBase
    {
        private readonly WikiPieceContext _context;

        public ArcoController(WikiPieceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Arco>> GetAll()
        {
            var listArcos = _context.Arcos.ToList();
            return listArcos;
        }
        
        [HttpGet("{id}")]
        public ActionResult<Arco> GetById([FromRoute] int id)
        {
            var arco = _context.Arcos.FirstOrDefault(x => x.Id == id);

            return arco;
        }

        [HttpGet("{nome}")]
        public ActionResult<Arco> GetByNome([FromRoute] string nome)
        {
            var arco = _context.Arcos.FirstOrDefault(x => x.Nome == nome);
            return arco;
        }

        [HttpPost]
        public ActionResult<Arco> Post([FromBody] Arco newArco)
        {
            _context.Add(newArco);
            _context.SaveChanges();

            return newArco;
        }
        
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Arco newArco)
        {
            if(id != newArco.Id)
            return BadRequest();

            var oldArco = _context.Arcos.FirstOrDefault(x => x.Id == id);
            _context.Entry(oldArco).State = EntityState.Modified;
            _context.Update(newArco);

            return NoContent();
        }
    }
}