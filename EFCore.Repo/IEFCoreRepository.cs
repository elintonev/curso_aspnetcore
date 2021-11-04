using EFCore.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public interface IEFCoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Heroi>> GetAllHeros(bool incluirBatalha = false);
        Task<Heroi> GetHeroById(int id, bool incluirBatalha = false);
        Task<IEnumerable<Heroi>> GetHeroByNome(string nome, bool incluirBatalha = false);
        Task<IEnumerable<Batalha>> GetAllBatalhas(bool incluirBatalha = false);
        Task<Batalha> GetBatalhaById(int id, bool incluirBatalha = false);

    }
}
