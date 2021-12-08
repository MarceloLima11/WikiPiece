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
    public class PersonagemController : ControllerBase
    {
        private readonly IPersonagemRepository _context;

        public PersonagemController(IPersonagemRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Personagem>> GetAll()
        {
            var listPersonagens = _context.Get().ToList();
            return listPersonagens;
        }

        [HttpGet("{id}")]
        public ActionResult<Personagem> GetById([FromRoute] int id)
        {
            var personagem = _context.GetById(x => x.Id == id);
            return personagem;
        }

        [HttpGet("Nome/{Nome}")]
        public ActionResult<Personagem> GetByNome([FromRoute] string nome)
        {
            var personagem = _context.GetByNome(x => x.Nome == nome);
            return personagem;
        }

        [HttpGet("Top5")]
        public ActionResult<IEnumerable<Personagem>> GetTop5()
        {
           var top5 = _context.GetTop5(x => x.Top5 == true).ToList();;

           return top5;
        }

        [HttpPost]
        public ActionResult<Personagem> Post([FromBody] Personagem personagem)
        {
            _context.Add(personagem);
            return personagem;
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Personagem personagem)
        {
            if(id != personagem.Id)
            return BadRequest("Ids diferentes.");

            _context.Update(personagem);
            return NoContent();
        }
    }
}