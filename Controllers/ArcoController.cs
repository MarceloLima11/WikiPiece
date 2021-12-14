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
    public class ArcoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _context;

        public ArcoController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArcoDTO>> GetAll()
        {
            var listArcos = _context.ArcoRepository.Get();

            var arcosDto = _mapper.Map<List<ArcoDTO>>(listArcos);

            return arcosDto;
        }

        [HttpGet("ArcoPersonagens")]
        public ActionResult<IEnumerable<ArcoDTO>> GetArcoPersonagens()
        {
            var arcoPersonagens = _context.ArcoRepository.GetArcoPersonagens();

            var personagensDto = _mapper.Map<List<ArcoDTO>>(arcoPersonagens);
            return personagensDto;
        }
        
        [HttpGet("Id/{id}")]
        public ActionResult<IEnumerable<ArcoDTO>> GetById([FromRoute] int id)
        {
            var arco = _context.ArcoRepository.GetById(x => x.Id == id);

            if(arco == null)
            return NotFound();
                                                                                                                                                                                                                                                                                                                        
                                                                                                                                                                                                                                                                                                                        
            var arcoDto = _mapper.Map<List<ArcoDTO>>(arco);

            return arcoDto;
        }

        [HttpGet("Nome/{nome}")]
        public ActionResult<IEnumerable<ArcoDTO>> GetByNome([FromRoute] string nome)
        {
            var arco = _context.ArcoRepository.GetByNome(x => x.Nome == nome);

            if(arco == null)
            return NotFound();

            var arcoDto = _mapper.Map<List<ArcoDTO>>(arco);
            return arcoDto;
        }

        [HttpPost]
        public ActionResult<ArcoDTO> Post([FromBody] ArcoDTO newArcoDto)
        {
            var arco = _mapper.Map<Arco>(newArcoDto);

            _context.ArcoRepository.Add(arco);

            _context.CommitAsync();

            return newArcoDto;
        }
        
        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] ArcoDTO newArco)
        {
            if(id != newArco.Id)
            return BadRequest("Ids de rota e body distintos!");

            var arco = _mapper.Map<Arco>(newArco);

            _context.ArcoRepository.Update(arco);

            _context.CommitAsync();

            return Ok();
        }
    }
}