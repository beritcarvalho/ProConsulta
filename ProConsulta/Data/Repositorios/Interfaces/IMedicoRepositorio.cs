using ProConsulta.Models;

namespace ProConsulta.Data.Repositorios.Interfaces
{
    public interface IMedicoRepositorio
    {
        Task AddAsync(Medico medico);
        Task<List<Medico>> GetAll();
        Task<Medico> GetById(int id);
        Task UpdateAsync(Medico medico);
        Task DeleteByIdAsync(int id);
    }
}
