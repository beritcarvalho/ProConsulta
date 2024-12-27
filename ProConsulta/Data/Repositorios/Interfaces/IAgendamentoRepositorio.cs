using ProConsulta.Models;

namespace ProConsulta.Data.Repositorios.Interfaces
{
    public interface IAgendamentoRepositorio
    {
        Task AddAsync(Agendamento agendamento);
        Task<List<Agendamento>> GetAll();
        Task<Agendamento> GetById(int id);
        Task UpdateAsync(Agendamento agendamento);
        Task DeleteByIdAsync(int id);
    }
}
