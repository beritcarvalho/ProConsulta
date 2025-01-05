using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Base;
using ProConsulta.Data.Repositorios.Interfaces;
using ProConsulta.Extensions;
using ProConsulta.Models;

namespace ProConsulta.Components.Pages.Medicos
{
    public class UpdateMedicoPage : CustomComponentBase
    {
        [Parameter]
        public int MedicoId { get; set; }

        [Inject]
        public IMedicoRepositorio Repositorio { get; set; } = null!;

        [Inject]
        public IEspecialidadeRepositorio EspecialidadeRepositorio { get; set; } = null!;

        public Medico? MedicoAtual { get; set; }
        public MedicoInputModel InputModel { get; set; } = new();

        public List<Especialidade> Especialidades { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Especialidades = await EspecialidadeRepositorio.GetAll();
            MedicoAtual = await Repositorio.GetById(MedicoId);

            if(MedicoAtual is null)
                return;

            InputModel = new MedicoInputModel
            {
                Nome = MedicoAtual.Nome,
                Documento = MedicoAtual.Documento,
                Crm = MedicoAtual.Crm,
                Telefone = MedicoAtual.Telefone,
                EspecialidadeId = MedicoAtual.EspecialidadeId
            };
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is MedicoInputModel model)
                {
                    MedicoAtual.Nome = model.Nome;
                    MedicoAtual.Documento = model.Documento.RemoverCaracteresEspeciais();
                    MedicoAtual.Crm = model.Crm.RemoverCaracteresEspeciais();
                    MedicoAtual.Telefone = model.Telefone.RemoverCaracteresEspeciais();
                    MedicoAtual.EspecialidadeId = model.EspecialidadeId;

                    await Repositorio.UpdateAsync(MedicoAtual);
                    Snackbar.Add("Médico atualizado com sucesso!", Severity.Success);
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
