using IssuerPersonalAccount.Data;
using IssuerPersonalAccount.ViewModels;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;

namespace IssuerPersonalAccount.Components.Pages;

public partial class LoginPage
{
    private bool _authSucceed = true;
    
    [Inject] private SignInManager<User> SignInManager { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private ILogger<LoginPage> Logger { get; set; } = null!;

    [SupplyParameterFromForm]
    public LoginViewModel LoginViewModel { get; set; } = new();

    private async Task OnValidSubmit(EditContext editContext)
    {
        var result = await SignInManager
            .PasswordSignInAsync(LoginViewModel.Login, LoginViewModel.Password, true, false);
        
        Logger.LogInformation("Аутентификация пользователя {LoginPage}: {Result}", LoginViewModel.Login, result.Succeeded);

        if (result.Succeeded)
            NavigationManager.NavigateTo("main", true);
        else
            _authSucceed = false;
    }
}