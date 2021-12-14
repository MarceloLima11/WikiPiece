
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
        public ActionResult<IEnumerable<AkumaNoMi>> GetAll()
        {
            var listAkumas = _context.AkumaNoMiRepository.Get().ToList();
            return listAkumas;
        }

        [HttpGet("Nome/{nome}")]
        public ActionResult<IEnumerable<AkumaNoMiDTO>> GetByNome([FromRoute] string nome)
        {
            var akuma = _context.AkumaNoMiRepository.GetByNome(x => x.Nome == nome);

            var akumaDto = _mapper.Map<List<AkumaNoMiDTO>>(akuma);

            return akumaDto;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<AkumaNoMiDTO>> GetById([FromRoute] int id)
        {
            var akuma = _context.AkumaNoMiRepository.GetById(x => x.Id == id);

            var akumaDto = _mapper.Map<List<AkumaNoMiDTO>>(akuma);

            return akumaDto;
        }

        [HttpGet("Tipo/{tipo}")]
        public ActionResult<IEnumerable<AkumaNoMiDTO>> GetByTipo([FromRoute] string tipo)
        {
            var akumas = _context.AkumaNoMiRepository.GetByTipo(x => x.Tipo == tipo);

            var akumasDtos = _mapper.Map<List<AkumaNoMiDTO>>(akumas);

            return akumasDtos;
        }

        [HttpGet("Personagens")]
        public ActionResult<IEnumerable<AkumaNoMiDTO>> GetAkumasPersonagens()
        {
            var akumasPersonagens = _context.AkumaNoMiRepository.GetAkumasPersonagens();

            var akumasPersonagensDto = _mapper.Map<List<AkumaNoMiDTO>>(akumasPersonagens);

            return akumasPersonagensDto;
        }

        [HttpPost]
        public ActionResult<AkumaNoMi> Post([FromBody] AkumaNoMi newAkumaNoMi)
        {
            _context.AkumaNoMiRepository.Add(newAkumaNoMi);

            _context.CommitAsync();
            
            return newAkumaNoMi;
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AkumaNoMi akumaNoMi)
        {
            if(id != akumaNoMi.Id)
            return BadRequest();
            
            _context.AkumaNoMiRepository.Update(akumaNoMi);
            
            _context.CommitAsync();
            
            return NoContent();
        }
    }
}