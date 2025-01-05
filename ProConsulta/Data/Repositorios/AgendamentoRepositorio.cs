using Microsoft.EntityFrameworkCore;
using ProConsulta.Data.Repositorios.Interfaces;
using ProConsulta.Models;

namespace ProConsulta.Data.Repositorios
{
    public class AgendamentoRepositorio : IAgendamentoRepositorio
    {
        private readonly ApplicationDbContext _context;

        public AgendamentoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Agendamento agendamento)
        {
            try 
            {
                _context.Agendamentos.Add(agendamento);
                await _context.SaveChangesAsync();
            }
            catch
            {
                _context.ChangeTracker.Clear();
                throw;
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            Agendamento agendamento = await GetById(id);
            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Agendamento>> GetAll()
        {
            return await _context.Agendamentos
                .Include(agendamento => agendamento.Paciente)
                .Include(agendamento => agendamento.Medico)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Agendamento> GetById(int id)
        {
            return await _context.Agendamentos
                .Include(agendamento => agendamento.Paciente)
                .Include(agendamento => agendamento.Medico)
                .SingleOrDefaultAsync(agendamento => agendamento.Id == id);
        }

        public async Task UpdateAsync(Agendamento agendamento)
        {
            try
            {
                _context.Update(agendamento);
                await _context.SaveChangesAsync();
            }
            catch
            {
                _context.ChangeTracker.Clear();
                throw;
            }
        }

        public async Task<List<AgendamentoAnual>> GetReportAsync()
        {
            FormattableString query = @$"
                SELECT
                    MONTH(DataConsulta) AS Mes,
                    COUNT(*) AS Quantidade
                FROM
                    Agendamentos
                WHERE
                    YEAR(DataConsulta) = {DateTime.Today.Year.ToString()}
                GROUP BY
                    MONTH(DataConsulta)
                ORDER BY
                    Mes";

            var result = _context.Database.SqlQuery<AgendamentoAnual>(query);

            return await result.ToListAsync();
        }
    }
}
