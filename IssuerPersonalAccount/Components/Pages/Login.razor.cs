using IssuerPersonalAccount.Data;
using IssuerPersonalAccount.ViewModels;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;

namespace IssuerPersonalAccount.Components.Pages;

public partial class Login
{
    [Inject] private SignInManager<User> SignInManager { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private ILogger<Login> Logger { get; set; } = null!;

    [SupplyParameterFromForm]
    public LoginViewModel? LoginViewModel { get; set; } = new();

    private async Task OnValidSubmit()
    {
        var result = await SignInManager
            .PasswordSignInAsync(LoginViewModel.Login, LoginViewModel.Password, true, false);
        
        Logger.LogInformation("Аутентификация пользователя {Login}: {Result}", LoginViewModel.Login, result.Succeeded);
    }
}