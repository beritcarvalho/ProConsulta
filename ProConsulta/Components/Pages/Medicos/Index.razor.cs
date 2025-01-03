using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProConsulta.Data.Repositorios.Interfaces;
using ProConsulta.Models;

namespace ProConsulta.Components.Pages.Medicos
{
    public class IndexMedicoPage : ComponentBase
    {
        [Inject]
        public IMedicoRepositorio Repositorio { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Medico> Medicos { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Medicos = await Repositorio.GetAll();
        }

        public async Task DeleteMedico(Medico Medico)
        {
            bool? resultado = await Dialog.ShowMessageBox("Atenção", $"Deseja excluir o Medico {Medico.Nome}?", yesText: "SIM", cancelText: "NÃO");

            try
            {
                if (resultado is true)
                {
                    await Repositorio.DeleteByIdAsync(Medico.Id);
                    Snackbar.Add($"Médico {Medico.Nome} excluído com sucesso!", Severity.Success);
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
            NavigationManager.NavigateTo($"/medicos/update/{id}");
        }
    }
}
