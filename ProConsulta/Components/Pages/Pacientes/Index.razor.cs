using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProConsulta.Data.Repositorios.Interfaces;
using ProConsulta.Models;

namespace ProConsulta.Components.Pages.Pacientes
{
    public class IndexPage : ComponentBase
    {
        [Inject]
        public IPacienteRepositorio Repositorio { get; set; } = null!;
        
        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Paciente> Pacientes { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Pacientes = await Repositorio.GetAll();
        }

        public async Task DeletePaciente(Paciente paciente)
        {
            bool? resultado = await Dialog.ShowMessageBox("Atenção", $"Deseja excluir o paciente {paciente.Nome}?", yesText: "SIM", cancelText: "NÃO");

            try
            {
                if (resultado is true)
                {
                    await Repositorio.DeleteByIdAsync(paciente.Id);
                    Snackbar.Add($"Paciente {paciente.Nome} excluído com sucesso!", Severity.Success);
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
            NavigationManager.NavigateTo($"/pacientes/update/{id}");
        }
    }
}
