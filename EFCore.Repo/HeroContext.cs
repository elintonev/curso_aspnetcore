using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;

namespace EFCore.Repo
{
    public class HeroContext : DbContext
    {

        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }
        public DbSet<IdentidadeSecreta> IdentidadeSecretas { get; set; }

        public HeroContext(DbContextOptions<HeroContext> options) : base(options) { }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Password=_43690;Persist Security Info=True;User ID=sa;Initial Catalog=HeroApp;Data Source=DESKTOP-C89AJ0F\SQL2017");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Método que relaciona os IDs gerando as Foreign Key 
            modelBuilder.Entity<HeroiBatalha>(entity =>  entity.HasKey(e => new { e.HeroiId, e.BatalhaId }));
        }
    }
}
