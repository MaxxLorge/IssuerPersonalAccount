using IssuerPersonalAccount.Data;
using IssuerPersonalAccount.ViewModels;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace IssuerPersonalAccount.Components.Pages;

public partial class LoginPage
{
    [Inject] private SignInManager<User> SignInManager { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private ILogger<LoginPage> Logger { get; set; } = null!;

    [SupplyParameterFromForm]
    public LoginViewModel? LoginViewModel { get; set; } = new();

    private async Task OnValidSubmit()
    {
        var result = await SignInManager
            .PasswordSignInAsync(LoginViewModel.Login, LoginViewModel.Password, true, false);
        
        Logger.LogInformation("Аутентификация пользователя {LoginPage}: {Result}", LoginViewModel.Login, result.Succeeded);
    }
}