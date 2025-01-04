using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Data.Repositorios.Interfaces;
using ProConsulta.Models;

namespace ProConsulta.Components.Pages.Agendamentos
{
    public class CreateAgendamentoPage : ComponentBase
    {
        [Inject]
        private IAgendamentoRepositorio AgendamentoRepositorio { get; set; } = null!;
       
        [Inject]
        private IMedicoRepositorio MedicoRepositorio { get; set; } = null!;
       
        [Inject]
        private IPacienteRepositorio PacienteRepositorio { get; set; } = null!;
        
        [Inject]
        private ISnackbar Snackbar { get; set; } = null!;
        
        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        public AgendamentoInputModel InputModel { get; set; } = new AgendamentoInputModel();

        public List<Medico> Medicos { get; set; }
        public List<Paciente> Pacientes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Medicos = await MedicoRepositorio.GetAll();
            Pacientes = await PacienteRepositorio.GetAll();
        }

        public async Task OnValidSubmitAsync(EditContext context)
        {
            try
            {
                if (context.Model is AgendamentoInputModel model)
                {
                    var agendamento = new Agendamento
                    {                            
                        Observacao = model.Observacao,
                        PacienteId = model.Paciente.Id,
                        MedicoId = model.Medico.Id,
                        HoraConsulta = (TimeSpan)model.HoraConsulta,
                        DataConsulta = (DateTime)model.DataConsulta
                    };

                    
                    await AgendamentoRepositorio.AddAsync(agendamento);
                    Snackbar.Add("Agendamento cadastrado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/agendamentos");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public async Task<IEnumerable<Medico>> BuscarMedico(string input, CancellationToken token)
        {
            IEnumerable<Medico> medicos;

            if (string.IsNullOrEmpty(input))
                return Medicos;

            return Medicos.Where(x => x.Nome.Contains(input, StringComparison.InvariantCultureIgnoreCase) || x.Crm.Contains(input, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<IEnumerable<Paciente>> BuscarPaciente(string input, CancellationToken token)
        {
            IEnumerable<Medico> medicos;

            if (string.IsNullOrEmpty(input))
                return Pacientes;

            return Pacientes.Where(x => x.Nome.Contains(input, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
