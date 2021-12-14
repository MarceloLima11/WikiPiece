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
    public class IlhaController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public IlhaController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IlhaDTO>> GetAll()
        {
            var ilhas = _context.IlhaRepository.Get();

            var ilhasDto = _mapper.Map<List<IlhaDTO>>(ilhas);

            return ilhasDto;
        }   

        [HttpGet("{id}")]
        public ActionResult<IlhaDTO> GetById([FromRoute] int id)
        {
            var ilhas = _context.IlhaRepository.GetById(x => x.Id == id);

            var ilhasDto = _mapper.Map<List<IlhaDTO>>(ilhas);

            return Ok();
        }

        [HttpGet("Regiao/{regiao}")]
        public ActionResult<IEnumerable<IlhaDTO>> GetByRegiao(string regiao)
        {
            var ilhasRegiao =_context.IlhaRepository.GetByRegiao(x => x.Regiao == regiao);
            
            var ilhasDto = _mapper.Map<List<IlhaDTO>>(ilhasRegiao);

            return ilhasDto;
        }

        [HttpGet("Clima/{clima}")]
        public ActionResult<IEnumerable<IlhaDTO>> GetByClima(string clima)
        {
            var ilhasClima = _context.IlhaRepository.GetByClima(x => x.Clima == clima);

            var ilhasDto = _mapper.Map<List<IlhaDTO>>(ilhasClima);           
            return ilhasDto;
        }

        [HttpPost]
        public ActionResult<IlhaDTO> Post([FromBody] IlhaDTO ilhaDto)
        {
            var ilha = _mapper.Map<Ilha>(ilhaDto);

            _context.IlhaRepository.Add(ilha);

            _context.CommitAsync();

            return ilhaDto;
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] IlhaDTO newIlhaDto)
        {
            var ilha = _mapper.Map<Ilha>(newIlhaDto);

            _context.IlhaRepository.Update(ilha);

            _context.CommitAsync();
            
            return NoContent();
        }
    }
}