using Microsoft.EntityFrameworkCore;
using ProConsulta.Data.Repositorios.Interfaces;
using ProConsulta.Models;

namespace ProConsulta.Data.Repositorios
{
    public class MedicoRepositorio : IMedicoRepositorio
    {
        private readonly ApplicationDbContext _context;

        public MedicoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Medico medico)
        {
            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            Medico medico = await GetById(id);
            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Medico>> GetAll()
        {
            return await _context.Medicos
                .Include(medico => medico.Especialidade)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Medico> GetById(int id)
        {
            return await _context.Medicos.SingleOrDefaultAsync(medico => medico.Id == id);
        }

        public async Task UpdateAsync(Medico medico)
        {
            _context.Update(medico);
            await _context.SaveChangesAsync();
        }
    }
}
