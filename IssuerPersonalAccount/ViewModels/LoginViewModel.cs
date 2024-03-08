using System.ComponentModel.DataAnnotations;

namespace IssuerPersonalAccount.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Небходимо ввести логин", AllowEmptyStrings = false)]
    public string Login { get; set; }
    
    [Required(ErrorMessage = "Необходимо ввести пароль", AllowEmptyStrings = false)]
    public string Password { get; set; }
}