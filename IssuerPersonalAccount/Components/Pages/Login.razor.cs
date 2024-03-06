using IssuerPersonalAccount.Data;
using IssuerPersonalAccount.ViewModels;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace IssuerPersonalAccount.Components.Pages;

public partial class Login
{
    [Inject]
    public SignInManager<User> SignInManager { get; set; } = null!;

    [Inject] public NavigationManager NavigationManager { get; set; } = null!;

    [SupplyParameterFromForm]
    public SignInViewModel? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    private async Task OnSubmit()
    {
        Console.WriteLine(Model.Login);
        Console.WriteLine(Model.Password);

        var result = await SignInManager
            .PasswordSignInAsync(Model.Login, Model.Password, true, false);
        
        Console.WriteLine($"Аутентификация: {result.Succeeded}");
        
        if(result.Succeeded)
            NavigationManager.NavigateTo("home");
    }
}