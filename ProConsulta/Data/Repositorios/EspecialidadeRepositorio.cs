using Microsoft.EntityFrameworkCore;
using ProConsulta.Data.Repositorios.Interfaces;
using ProConsulta.Models;

namespace ProConsulta.Data.Repositorios
{
    public class EspecialidadeRepositorio : IEspecialidadeRepositorio
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadeRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Especialidade especialidade)
        {
            _context.Especialidades.Add(especialidade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            Especialidade especialidade = await GetById(id);
            _context.Especialidades.Remove(especialidade);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Especialidade>> GetAll()
        {
            return await _context.Especialidades.AsNoTracking().ToListAsync();
        }

        public async Task<Especialidade> GetById(int id)
        {
            return await _context.Especialidades.SingleOrDefaultAsync(especialidade => especialidade.Id == id);
        }

        public async Task UpdateAsync(Especialidade especialidade)
        {
            _context.Update(especialidade);
            await _context.SaveChangesAsync();
        }
    }
}
