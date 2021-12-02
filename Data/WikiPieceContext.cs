using Microsoft.EntityFrameworkCore;
using WikiPiece.Models;
using Microsoft.Extensions.Configuration;

namespace WikiPiece.Data
{
    public class WikiPieceContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public WikiPieceContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<AkumaNoMi> AkumaNoMis;
        public DbSet<Personagem> Personagens;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var mySqlConnectionStr = _configuration.GetConnectionString("WikiConnection");
            optionsBuilder.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr));
        }
    }
}