using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace ProConsulta.Base
{
    public abstract class CustomComponentBase : ComponentBase
    {
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public bool Esconder { get; set; } = true;

        [CascadingParameter]
        public Task<AuthenticationState> Autenticacao { get; set; }

        public async Task ValidarExibicaoBotaoAsync()
        {
            AuthenticationState? autenticacao = await Autenticacao;

            Esconder = !autenticacao.User.IsInRole("Atendente");
        }
    }
}
