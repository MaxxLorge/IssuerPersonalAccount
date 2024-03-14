using BlazorBootstrap;

using IssuerPersonalAccount.Data;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;

namespace IssuerPersonalAccount.Components;

public partial class ProfileDropdown
{
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

    private async Task HandleExitButtonClick(MouseEventArgs eventArgs)
    {
        NavigationManager.NavigateTo("account/logout");
    }
}