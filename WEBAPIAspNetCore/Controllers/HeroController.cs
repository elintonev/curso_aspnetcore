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
        private readonly IEFCoreRepository _repo;
        public HeroController(IEFCoreRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<HeroController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var herois = await _repo.GetAllHeros(true);
                return Ok(herois);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e}");
            }

        }

        // GET api/<HeroController>/5
        [HttpGet("{id}", Name = "GetHero")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var herois = await _repo.GetHeroById(id, true);
                return Ok(herois);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e}");
            }
        }

        // POST api/<HeroController>
        [HttpPost]
        public async Task<IActionResult> Post(Heroi model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok("Show de Gol meu guri");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e}");
            }
            return BadRequest("Deu ruim!");
        }

        // PUT api/<HeroController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Heroi model)
        {
            try
            {
                var heroi = _repo.GetHeroById(id);
                if (heroi != null)
                {
                    _repo.Update(model);
                    if (await _repo.SaveChangesAsync())
                    {
                        return Ok("Brabo de mais!");
                    }
                }
                return BadRequest("Não achei!");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e}");
            }
        }

        // DELETE api/<HeroController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var heroi = _repo.GetHeroById(id);
                if (heroi != null)
                {
                    _repo.Delete(heroi);
                    if (await _repo.SaveChangesAsync())
                    {
                        return Ok("Brabo de mais!");
                    }
                }
                return BadRequest("Não achei!");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e}");
            }

        }
    }
}
