using Microsoft.EntityFrameworkCore;
using WikiPiece.Models;
using Microsoft.Extensions.Configuration;

namespace WikiPiece.Data
{
    public class WikiPieceContext : DbContext
    {
        public DbSet<AkumaNoMi> AkumaNoMis { get; set; }
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<Ilha> Ilhas { get; set; }
        public DbSet<Arco> Arcos { get; set; }

        private readonly IConfiguration _configuration;

        public WikiPieceContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string mySqlConnectionStr = _configuration.GetConnectionString("WikiConnection");
            
            optionsBuilder.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr));
        }
    }
}