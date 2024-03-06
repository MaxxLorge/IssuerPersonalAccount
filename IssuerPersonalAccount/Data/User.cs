using Microsoft.AspNetCore.Identity;

namespace IssuerPersonalAccount.Data;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;
}