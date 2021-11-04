using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly HeroContext _context;

        public EFCoreRepository(HeroContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
           return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<Heroi>> GetAllHeros(bool incluirBatalha = false)
        {
            IQueryable<Heroi> query = _context.Herois.Include(h => h.IdentidadeSecreta).Include(h => h.Armas);
            if (incluirBatalha)
            {
                query = query.Include(h => h.HeroisBatalhas).ThenInclude(h => h.Batalha);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Heroi> GetHeroById(int id, bool incluirBatalha = false)
        {
            IQueryable<Heroi> query = _context.Herois.Include(h => h.IdentidadeSecreta).Include(h => h.Armas);
            if (incluirBatalha)
            {
                query = query.Include(h => h.HeroisBatalhas).ThenInclude(h => h.Batalha);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<Heroi>> GetHeroByNome(string nome, bool incluirBatalha = false)
        {
            IQueryable<Heroi> query = _context.Herois.Include(h => h.IdentidadeSecreta).Include(h => h.Armas);
            if (incluirBatalha)
            {
                query = query.Include(h => h.HeroisBatalhas).ThenInclude(h => h.Batalha);
            }

            query = query.AsNoTracking().Where(h => h.Nome.Contains(nome)).OrderBy(h => h.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable<Batalha>> GetAllBatalhas(bool incluirHeroi = false)
        {
            IQueryable<Batalha> query = _context.Batalhas;
            if (incluirHeroi)
            {
                query = query.Include(h => h.HeroisBatalhas).ThenInclude(h => h.Heroi);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Batalha> GetBatalhaById(int id, bool incluirHeroi = false)
        {
            IQueryable<Batalha> query = _context.Batalhas;
            if (incluirHeroi)
            {
                query = query.Include(h => h.HeroisBatalhas).ThenInclude(h => h.Heroi);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
