using IssuerPersonalAccount.Data;
using IssuerPersonalAccount.Models;

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
    public LoginModel LoginModel { get; set; } = new();

    private async Task OnValidSubmit(EditContext editContext)
    {
        var result = await SignInManager
            .PasswordSignInAsync(LoginModel.Login, LoginModel.Password, true, false);
        
        Logger.LogInformation("Аутентификация пользователя {LoginPage}: {Result}", LoginModel.Login, result.Succeeded);

        if (result.Succeeded)
            NavigationManager.NavigateTo("/", true);
        else
            _authSucceed = false;
    }
}