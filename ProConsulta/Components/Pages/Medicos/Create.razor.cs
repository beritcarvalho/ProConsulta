using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MudBlazor;
using ProConsulta.Data.Repositorios.Interfaces;
using ProConsulta.Extensions;
using ProConsulta.Models;

namespace ProConsulta.Components.Pages.Medicos
{
    public class CreateMedicoPage : ComponentBase
    {
        [Inject]
        public IEspecialidadeRepositorio EspecialidadeRepositorio { get; set; }

        [Inject]
        public IMedicoRepositorio Repositorio { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Especialidade> Especialidades { get; set; } = new();
        public MedicoInputModel InputModel { get; set; } = new();

        protected override async Task OnInitializedAsync() 
            => Especialidades = await EspecialidadeRepositorio.GetAll();

        public async Task OnValidSubmitAsync(EditContext context)
        {
            try
            {
                if (context.Model is MedicoInputModel model)
                {
                    var medico = new Medico
                    {
                        Nome = model.Nome,
                        Documento = model.Documento.RemoverCaracteresEspeciais(),
                        Crm = model.Crm.RemoverCaracteresEspeciais(),
                        Telefone = model.Telefone.RemoverCaracteresEspeciais(),
                        EspecialidadeId = model.EspecialidadeId,
                    };

                    await Repositorio.AddAsync(medico);
                    Snackbar.Add("Médico cadastrado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/medicos");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);             
            }
        }
    }
}
