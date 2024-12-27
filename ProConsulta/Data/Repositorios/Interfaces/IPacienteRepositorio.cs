using ProConsulta.Models;

namespace ProConsulta.Data.Repositorios.Interfaces
{
    public interface IPacienteRepositorio
    {
        Task AddAsync(Paciente paciente);
        Task<List<Paciente>> GetAll();
        Task<Paciente> GetById(int id);
        Task UpdateAsync(Paciente paciente);
        Task DeleteByIdAsync(int id);
    }
}
