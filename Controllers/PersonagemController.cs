using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<PersonagemDTO>>> GetAll()
        {
            var listPersonagens = await _context.PersonagemRepository.Get().ToListAsync();

            var listPersonagensDto = _mapper.Map<List<PersonagemDTO>>(listPersonagens);

            return listPersonagensDto;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PersonagemDTO>>> GetById([FromRoute] int id)
        {
            var personagem = await _context.PersonagemRepository.GetById(x => x.Id == id);

            var personagemDto = _mapper.Map<List<PersonagemDTO>>(personagem);

            return personagemDto;
        }

        [HttpGet("Nome/{nome}")]
        public async Task<ActionResult<IEnumerable<PersonagemDTO>>> GetByNome([FromRoute] string nome)
        {
            var personagem = await _context.PersonagemRepository.GetByNome(x => x.Nome == nome);

            var personagemDto = _mapper.Map<List<PersonagemDTO>>(personagem);

            return personagemDto;
        }

        [HttpGet("PersonagensAkumas")]
        public async Task<ActionResult<IEnumerable<PersonagemDTO>>> GetPersonagensAkumas()
        {
            var personagemAkumas = await _context.PersonagemRepository.GetPersonagensAkumas();

            var personagensAkumasDto = _mapper.Map<List<PersonagemDTO>>(personagemAkumas);

            return personagensAkumasDto;
        }

        [HttpGet("Top5")]
        public async Task<ActionResult<IEnumerable<PersonagemDTO>>> GetTop5()
        {
           var top5 = await _context.PersonagemRepository.GetTop5(x => x.Top5 == true);

           var personagensAkumasDto = _mapper.Map<List<PersonagemDTO>>(top5);

           return personagensAkumasDto;
        }

        [HttpPost]
        public async Task<ActionResult<PersonagemDTO>> Post([FromBody] PersonagemDTO personagemDto)
        {
            var personagem = _mapper.Map<Personagem>(personagemDto);

            _context.PersonagemRepository.Add(personagem);

            await _context.CommitAsync();

            return personagemDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PersonagemDTO personagemDto)
        {
            if(id != personagemDto.Id)
            return BadRequest("Ids diferentes.");

            var personagem = _mapper.Map<Personagem>(personagemDto);

            _context.PersonagemRepository.Update(personagem);

            await _context.CommitAsync();

            return NoContent();
        }
    }
}