using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WikiPiece.Data;
using WikiPiece.Models;

namespace WikiPiece.Controllers
{
    [ApiController]
    [Route("v1/[Controller]")]
    public class ArcoController
    {
        private readonly WikiPieceContext _context;

        public ArcoController(WikiPieceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Arco>> GetAll()
        {
            var listArcos = _context.Arcos.ToList();
            return listArcos;
        }
        
    }
}