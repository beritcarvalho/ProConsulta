using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Data.Repositorios.Interfaces;
using ProConsulta.Extensions;
using ProConsulta.Models;

namespace ProConsulta.Components.Pages.Pacientes
{
    public class CreatePage : ComponentBase
    {
        [Inject]
        public IPacienteRepositorio Repositorio { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public PacienteInputModel InputModel { get; set; } = new();

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is PacienteInputModel model)
                {
                    var paciente = new Paciente
                    {
                        Nome = model.Nome,
                        Documento = model.Documento.RemoverCaracteresEspeciais(),
                        Email = model.Email,
                        Telefone = model.Telefone.RemoverCaracteresEspeciais(),
                        DataNascimento = model.DataNascimento ?? DateTime.Today
                    };

                    await Repositorio.AddAsync(paciente);
                    Snackbar.Add("Paciente cadastrado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/pacientes");
                }
            }
            catch(Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

    }
}
