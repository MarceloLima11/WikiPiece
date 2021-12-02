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
    public class PersonagemController : ControllerBase
    {
        private readonly WikiPieceContext _context;

        public PersonagemController(WikiPieceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Personagem>> GetAll()
        {
            var listPersonagens = _context.Personagens.ToList();
            return listPersonagens;
        }

        [HttpGet("{id}")]
        public ActionResult<Personagem> GetId([FromRoute] int id)
        {
            var personagem = _context.Personagens.FirstOrDefault(x => x.Id == id);
            return personagem;
        }

        [HttpGet("Nome/{Nome}")]
        public ActionResult<Personagem> GetByNome([FromRoute] string nome)
        {
            var personagem = _context.Personagens.FirstOrDefault(x => x.Nome == nome);  
            return personagem;
        }

        [HttpGet("Top5")]
        public ActionResult<IEnumerable<Personagem>> GetTop5()
        {
           var top5 = _context.Personagens.Where(x => x.Top5 == true).ToList();

           return top5;
        }

        [HttpPost]
        public ActionResult<Personagem> Post([FromBody] Personagem personagem)
        {
            _context.Personagens.Add(personagem); 
            _context.SaveChanges();
            return personagem;
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Personagem personagem)
        {
            if(id != personagem.Id)
            {
                return BadRequest("Ids diferentes.");
            }

            var personagemId = _context.Personagens.FirstOrDefault(x => x.Id == id);
            _context.Entry(personagemId).State = EntityState.Modified;
            _context.Update(personagem);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}