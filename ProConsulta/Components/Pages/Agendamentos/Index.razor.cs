using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProConsulta.Data.Repositorios.Interfaces;
using ProConsulta.Models;

namespace ProConsulta.Components.Pages.Agendamentos
{
    public class IndexAgendamentoPage : ComponentBase
    {
        [Inject]
        public IAgendamentoRepositorio Repositorio { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Agendamento> Agendamentos { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Agendamentos = await Repositorio.GetAll();
        }

        public async Task DeleteAgendamento(Agendamento agendamento)
        {
            bool? resultado = await Dialog.ShowMessageBox("Atenção", $"Deseja excluir o agendamento {agendamento.Id}?", yesText: "SIM", cancelText: "NÃO");

            try
            {
                if (resultado is true)
                {
                    await Repositorio.DeleteByIdAsync(agendamento.Id);
                    Snackbar.Add($"Agendamento {agendamento.Id} excluído com sucesso!", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public void GoToUpdate(int id)
        {
            NavigationManager.NavigateTo($"/agendamentos/update/{id}");
        }
    }
}
