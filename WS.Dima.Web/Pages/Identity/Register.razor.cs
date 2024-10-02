using Microsoft.AspNetCore.Components;
using MudBlazor;
using WS.Dima.Core.Handlers;
using WS.Dima.Core.Requests.Account;
using WS.Dima.Web.Security;

namespace WS.Dima.Web.Pages.Identity;

public partial class RegisterPage : ComponentBase
{
   [Inject] public ISnackbar Snackbar { get; set; } = null!;

   [Inject] public IAccountHandler Handler { get; set; } = null!;

   [Inject] public NavigationManager NavigationManager { get; set; } = null!;

   [Inject] public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

   public bool IsBusy { get; set; }
   public RegisterRequest InputModel { get; set; } = new();

   protected override async Task OnInitializedAsync()
   {
      var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
      var user = authState.User;
      if(user.Identity is { IsAuthenticated: true })
         NavigationManager.NavigateTo("/");
   }

   public async Task OnValidSubmitAsync()
   {
      IsBusy = true;

      try
      {
         var result =  await Handler.RegisterAsync(InputModel);
         if (result.IsSucess)
            NavigationManager.NavigateTo("/login");
         else
            Snackbar.Add(result.Message, Severity.Error);
      }
      catch (Exception ex)
      {
         Snackbar.Add(ex.Message, Severity.Error);
      }
      finally
      {
         IsBusy = false;
      }
   }
}