using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEBAPIAspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly HeroContext _context;

        public HeroController(HeroContext context)
        {
            _context = context;
        }
        // GET: api/<HeroController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Heroi());
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e}");
            }

        }

        // GET api/<HeroController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/<HeroController>
        [HttpPost]
        public ActionResult Post(Heroi model)
        {
            try
            {
                _context.Herois.Add(model);
                _context.SaveChanges();
                return Ok("Show de Gol meu guri");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e}");
            }
        }

        // PUT api/<HeroController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Heroi model)
        {
            try
            {
                if (_context.Herois.AsNoTracking().FirstOrDefault(h => h.Id == id) != null)
                {
                    _context.Herois.Update(model);
                    _context.SaveChanges();
                    return Ok("Show de Gol meu guri");
                }
                return Ok("Não encontrado!");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e}");
            }
        }

        // DELETE api/<HeroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
