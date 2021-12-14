using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiPiece.Data;
using WikiPiece.Data.DTOs;
using WikiPiece.Models;
using WikiPiece.Repository.Interfaces;

namespace WikiPiece.Controllers
{
    [ApiController]
    [Route("v1/[Controller]")]
    public class PersonagemController : ControllerBase
    {
        private readonly IPersonagemRepository _context;
        private readonly IMapper _mapper;

        public PersonagemController(IPersonagemRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Personagem>> GetAll()
        {
            var listPersonagens = _context.Get().ToList();
            return listPersonagens;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PersonagemDTO>> GetById([FromRoute] int id)
        {
            var personagem = _context.GetById(x => x.Id == id);

            var personagemDto = _mapper.Map<List<PersonagemDTO>>(personagem);

            return personagemDto;
        }

        [HttpGet("Nome/{nome}")]
        public ActionResult<IEnumerable<PersonagemDTO>> GetByNome([FromRoute] string nome)
        {
            var personagem = _context.GetByNome(x => x.Nome == nome);

            var personagemDto = _mapper.Map<List<PersonagemDTO>>(personagem);

            return personagemDto;
        }

        [HttpGet("PersonagensAkumas")]
        public ActionResult<IEnumerable<PersonagemDTO>> GetPersonagensAkumas()
        {
            var personagemAkumas = _context.GetPersonagensAkumas();

            var personagensAkumasDto = _mapper.Map<List<PersonagemDTO>>(personagemAkumas);

            return personagensAkumasDto;
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