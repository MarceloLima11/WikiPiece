
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
    public class AkumaNoMiController : ControllerBase
    {
        private readonly WikiPieceContext _context;

        public AkumaNoMiController(WikiPieceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AkumaNoMi>> GetAll()
        {
            var listAkumas = _context.AkumaNoMis.ToList();
            return listAkumas;
        }

        [HttpGet("Nome/{nome}")]
        public ActionResult<AkumaNoMi> GetByName(string nome)
        {
            var akuma = _context.AkumaNoMis.FirstOrDefault(x => x.Nome == nome);
            return akuma;
        }

        [HttpGet("{id}")]
        public ActionResult<AkumaNoMi> GetById(int id)
        {
            var akuma = _context.AkumaNoMis.FirstOrDefault(x => x.Id == id);

            return akuma;
        }

        [HttpGet("Tipo/{tipo}")]
        public ActionResult<IEnumerable<AkumaNoMi>> GetByTipo(string tipo)
        {
            var akumas = _context.AkumaNoMis.Where(x => x.Tipo == tipo).ToList();
            return akumas;
        }

        [HttpGet("Personagens")]
        public ActionResult<IEnumerable<AkumaNoMi>> GetAkumasPersonagens()
        {
            var akumasPersonagens = _context.AkumaNoMis.Include(x => x.Personagens).ToList();
            return akumasPersonagens;
        }

        [HttpPost]
        public ActionResult<AkumaNoMi> Post([FromBody] AkumaNoMi newAkumaNoMi)
        {
            _context.AkumaNoMis.Add(newAkumaNoMi);
            _context.SaveChanges();
            return newAkumaNoMi;
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AkumaNoMi akumaNoMi)
        {
            var oldAkuma = _context.AkumaNoMis.FirstOrDefault(x => x.Id == id);

            _context.Entry(oldAkuma).State = EntityState.Modified;
            _context.Update(akumaNoMi);
            return NoContent();
        }
    }
}