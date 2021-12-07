
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
    public class AkumaNoMiController : ControllerBase
    {
        private readonly IAkumaNoMiRepository _context;

        public AkumaNoMiController(IAkumaNoMiRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AkumaNoMi>> GetAll()
        {
            var listAkumas = _context.Get().ToList();
            return listAkumas;
        }

        [HttpGet("Nome/{nome}")]
        public ActionResult<AkumaNoMi> GetByNome(string nome)
        {
            var akuma = _context.GetByNome(x => x.Nome == nome);
            return akuma;
        }

        [HttpGet("{id}")]
        public ActionResult<AkumaNoMi> GetById(int id)
        {
            var akuma = _context.GetById(x => x.Id == id);
            return akuma;
        }

        [HttpGet("Tipo/{tipo}")]
        public ActionResult<IEnumerable<AkumaNoMi>> GetByTipo(string tipo)
        {
            var akumas = _context.GetByTipo(tipo).ToList();
            return akumas;
        }

        [HttpGet("Personagens")]
        public ActionResult<IEnumerable<AkumaNoMi>> GetAkumasPersonagens()
        {
            var akumasPersonagens = _context.GetAkumasPersonagens().ToList();
            return akumasPersonagens;
        }

        [HttpPost]
        public ActionResult<AkumaNoMi> Post([FromBody] AkumaNoMi newAkumaNoMi)
        {
            _context.Add(newAkumaNoMi);
            return newAkumaNoMi;
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AkumaNoMi akumaNoMi)
        {
            _context.Update(akumaNoMi);
            return NoContent();
        }
    }
}