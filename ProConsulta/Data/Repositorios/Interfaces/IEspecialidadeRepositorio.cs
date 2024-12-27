using ProConsulta.Models;

namespace ProConsulta.Data.Repositorios.Interfaces
{
    public interface IEspecialidadeRepositorio
    {
        Task AddAsync(Especialidade especialidade);
        Task<List<Especialidade>> GetAll();
        Task<Especialidade> GetById(int id);
        Task UpdateAsync(Especialidade especialidade);
        Task DeleteByIdAsync(int id);
    }
}
