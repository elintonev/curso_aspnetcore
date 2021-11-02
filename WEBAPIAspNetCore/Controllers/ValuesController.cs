using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPIAspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly HeroContext _context;
        public ValuesController(HeroContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {   //USANDO LINQ METHOD
            var listHerois1 = _context.Herois.Where(h => h.Nome.Contains(nome)).ToList();
            //USANDO LINQ QUERY
            //var listHerois2 = (from Herois in _context.Herois where Herois.Nome.Contains(nome) select Herois).ToList();
            return Ok(listHerois1);
        }

        // GET api/values/5
        [HttpGet("atualizar/{nameHero}")]
        public ActionResult Get(string nameHero)
        {
            //var heroi = new Heroi() { Nome = nameHero};
            //_context.Add(heroi);
            var herois = _context.Herois.Where(h => h.Id == 3).FirstOrDefault();
            herois.Nome = "Homem Aranha";
            _context.SaveChanges();

           /*using (var contexto = new HeroContext()) {
                //contexto.Herois.Add(heroi);
                contexto.Add(heroi);
                contexto.SaveChanges();
            }*/

                return Ok();
        }
        // GET api/values/5
        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Heroi { Nome = "Capitão América" },
                new Heroi { Nome = "Doutor Estanho" },
                new Heroi { Nome = "Pantera Negra" },
                new Heroi { Nome = "Viúva Negra" },
                new Heroi { Nome = "Hulk" },
                new Heroi { Nome = "Gavião Arqueiro" },
                new Heroi { Nome = "Capitã Marvel" }
                );
            _context.SaveChanges();
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var heroi = _context.Herois.Where(x => x.Id == id).Single();
            _context.Remove(heroi);
            _context.SaveChanges();
        }
    }
}
