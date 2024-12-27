using Microsoft.EntityFrameworkCore;
using ProConsulta.Data.Repositorios.Interfaces;
using ProConsulta.Models;

namespace ProConsulta.Data.Repositorios
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly ApplicationDbContext _context;

        public PacienteRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            Paciente paciente = await GetById(id);
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Paciente>> GetAll()
        {
            return await _context.Pacientes.AsNoTracking().ToListAsync();
        }

        public async Task<Paciente> GetById(int id)
        {
            return await _context.Pacientes.SingleOrDefaultAsync(paciente => paciente.Id == id);
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            _context.Update(paciente);
            await _context.SaveChangesAsync();
        }
    }
}
