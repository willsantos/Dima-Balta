using Microsoft.AspNetCore.Components;
using MudBlazor;
using WS.Dima.Core.Handlers;
using WS.Dima.Web.Security;

namespace WS.Dima.Web.Pages.Identity;

public partial class LogoutPage : ComponentBase
{
    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    [Inject] public IAccountHandler Handler { get; set; } = null!;

    [Inject] public NavigationManager NavigationManager { get; set; } = null!;

    [Inject] public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;
    
    protected override async Task OnInitializedAsync()
    {
        if (await AuthenticationStateProvider.CheckAuthenticatedAsync())
        {
            await Handler.LogoutAsync();
            await AuthenticationStateProvider.GetAuthenticationStateAsync();
            AuthenticationStateProvider.NotifyAuthenticationStateChanged();
        }

        await base.OnInitializedAsync();
    }
}