using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;

namespace EFCore.Repo
{
    public class BatalhaContext : DbContext
    {

        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }

        public BatalhaContext(DbContextOptions<BatalhaContext> options) : base(options) { }

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
