using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class Heroi
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IdentidadeSecreta IdentidadeSecreta { get; set; }
        public ICollection<Arma> Armas { get; set; }
        public ICollection<HeroiBatalha> HeroisBatalhas { get; set; }

    }
}
