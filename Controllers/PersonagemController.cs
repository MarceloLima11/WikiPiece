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
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public PersonagemController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonagemDTO>> GetAll()
        {
            var listPersonagens = _context.PersonagemRepository.Get();

            var listPersonagensDto = _mapper.Map<List<PersonagemDTO>>(listPersonagens);

            return listPersonagensDto;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PersonagemDTO>> GetById([FromRoute] int id)
        {
            var personagem = _context.PersonagemRepository.GetById(x => x.Id == id);

            var personagemDto = _mapper.Map<List<PersonagemDTO>>(personagem);

            return personagemDto;
        }

        [HttpGet("Nome/{nome}")]
        public ActionResult<IEnumerable<PersonagemDTO>> GetByNome([FromRoute] string nome)
        {
            var personagem = _context.PersonagemRepository.GetByNome(x => x.Nome == nome);

            var personagemDto = _mapper.Map<List<PersonagemDTO>>(personagem);

            return personagemDto;
        }

        [HttpGet("PersonagensAkumas")]
        public ActionResult<IEnumerable<PersonagemDTO>> GetPersonagensAkumas()
        {
            var personagemAkumas = _context.PersonagemRepository.GetPersonagensAkumas();

            var personagensAkumasDto = _mapper.Map<List<PersonagemDTO>>(personagemAkumas);

            return personagensAkumasDto;
        }

        [HttpGet("Top5")]
        public ActionResult<IEnumerable<PersonagemDTO>> GetTop5()
        {
           var top5 = _context.PersonagemRepository.GetTop5(x => x.Top5 == true);

           var personagensAkumasDto = _mapper.Map<List<PersonagemDTO>>(top5);

           return personagensAkumasDto;
        }

        [HttpPost]
        public ActionResult<PersonagemDTO> Post([FromBody] Personagem personagemDto)
        {
            _context.PersonagemRepository.Add(personagemDto);

            var personagensAkumasDto = _mapper.Map<PersonagemDTO>(personagemDto);

            return personagensAkumasDto;
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Personagem personagem)
        {
            if(id != personagem.Id)
            return BadRequest("Ids diferentes.");

            var personagemDto = _mapper.Map<List<PersonagemDTO>>(personagem);

            _context.PersonagemRepository.Update(personagem);

            _context.CommitAsync();

            return NoContent();
        }
    }
}