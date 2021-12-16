
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
    public class AkumaNoMiController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public AkumaNoMiController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AkumaNoMi>>> GetAll()
        {
            var listAkumas = await _context.AkumaNoMiRepository.Get().ToListAsync();
            return listAkumas;
        }

        [HttpGet("Nome/{nome}")]
        public async Task<ActionResult<IEnumerable<AkumaNoMiDTO>>> GetByNome([FromRoute] string nome)
        {
            var akuma = await _context.AkumaNoMiRepository.GetByNome(x => x.Nome == nome);

            var akumaDto = _mapper.Map<List<AkumaNoMiDTO>>(akuma);

            return akumaDto;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AkumaNoMiDTO>>> GetById([FromRoute] int id)
        {
            var akumas = await _context.AkumaNoMiRepository.GetById(x => x.Id == id);

            var akumaDto = _mapper.Map<List<AkumaNoMiDTO>>(akumas);

            return akumaDto;
        }

        [HttpGet("Tipo/{tipo}")]
        public async Task<ActionResult<IEnumerable<AkumaNoMiDTO>>> GetByTipo([FromRoute] string tipo)
        {
            var akumas = await _context.AkumaNoMiRepository.GetByTipo(x => x.Tipo == tipo);

            var akumasDtos = _mapper.Map<List<AkumaNoMiDTO>>(akumas);

            return akumasDtos;
        }

        [HttpGet("Personagens")]
        public async Task<ActionResult<IEnumerable<AkumaNoMiDTO>>> GetAkumasPersonagens()
        {
            var akumasPersonagens = await _context.AkumaNoMiRepository.GetAkumasPersonagens();

            var akumasPersonagensDto = _mapper.Map<List<AkumaNoMiDTO>>(akumasPersonagens);

            return akumasPersonagensDto;
        }

        [HttpPost]
        public async Task<ActionResult<AkumaNoMi>> Post([FromBody] AkumaNoMi newAkumaNoMi)
        {
            _context.AkumaNoMiRepository.Add(newAkumaNoMi);

            await _context.CommitAsync();
            
            return newAkumaNoMi;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] AkumaNoMi akumaNoMi)
        {
            if(id != akumaNoMi.Id)
            return BadRequest();
            
            _context.AkumaNoMiRepository.Update(akumaNoMi);
            
            await _context.CommitAsync();
            
            return NoContent();
        }
    }
}