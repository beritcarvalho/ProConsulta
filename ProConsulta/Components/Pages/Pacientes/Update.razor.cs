using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Base;
using ProConsulta.Data.Repositorios.Interfaces;
using ProConsulta.Extensions;
using ProConsulta.Models;

namespace ProConsulta.Components.Pages.Pacientes
{
    public class UpdatePage : CustomComponentBase
    {
        [Parameter] 
        public int PacienteId { get; set; }

        [Inject]
        public IPacienteRepositorio Repositorio { get; set; } = null!;
        
        public PacienteInputModel InputModel { get; set; } = new();
        public Paciente? PacienteAtual { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PacienteAtual = await Repositorio.GetById(PacienteId);

            if (PacienteAtual is null)
                return;

            InputModel = new PacienteInputModel
            {
                Id = PacienteAtual.Id,
                Nome = PacienteAtual.Nome,
                Documento = PacienteAtual.Documento,
                Email = PacienteAtual.Email,
                Telefone = PacienteAtual.Telefone,
                DataNascimento = PacienteAtual.DataNascimento
            };

        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is PacienteInputModel model)
                {
                    PacienteAtual.Nome = model.Nome;
                    PacienteAtual.Documento = model.Documento.RemoverCaracteresEspeciais();
                    PacienteAtual.Email = model.Email;
                    PacienteAtual.Telefone = model.Telefone.RemoverCaracteresEspeciais();
                    PacienteAtual.DataNascimento = model.DataNascimento ?? PacienteAtual.DataNascimento;

                    await Repositorio.UpdateAsync(PacienteAtual);
                    Snackbar.Add("Paciente atualizado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/pacientes");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    }
}
