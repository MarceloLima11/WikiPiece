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
    public class ArcoController : ControllerBase
    {
        private readonly IArcoRepository _context;

        public ArcoController(IArcoRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Arco>> GetAll()
        {
            var listArcos = _context.Get().ToList();
            return listArcos;
        }
        
        [HttpGet("{id}")]
        public ActionResult<Arco> GetById([FromRoute] int id)
        {
            var arco = _context.GetById(x => x.Id == id);

            return arco;
        }

        [HttpGet("{nome}")]
        public ActionResult<Arco> GetByNome([FromRoute] string nome)
        {
            var arco = _context.GetByNome(x => x.Nome == nome);
            return arco;
        }

        [HttpPost]
        public ActionResult<Arco> Post([FromBody] Arco newArco)
        {
            _context.Add(newArco);
            return newArco;
        }
        
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Arco newArco)
        {
            if(id != newArco.Id)
            return BadRequest();

            _context.Update(newArco);

            return NoContent();
        }
    }
}