using IssuerPersonalAccount.Data;

using Microsoft.AspNetCore.Identity;

namespace IssuerPersonalAccount.Services;

public class DataSeeder
{
    private readonly UserManager<User> _userManager;
    private readonly ILogger<DataSeeder> _logger;

    public DataSeeder(UserManager<User> userManager, ILogger<DataSeeder> logger)
    {
        _userManager = userManager;
        _logger = logger;
    }

    public void SeedUser()
    {
        var user = _userManager.FindByNameAsync("admin").Result;

        if (user is not null)
            return;
        
        user = new User()
        {
            Email = "admin@mail.ru",
            UserName = "admin",
            FirstName = "Админ",
            Patronymic = "Админович",
            Surname = "Админов"
        };

        const string userPassword = "1q2w3e4R!";
        
        var identityResult = _userManager.CreateAsync(user, userPassword).Result;

        if (identityResult.Succeeded) 
            _logger.LogDebug("Тестовый пользователь успешно создан");
        else
        {
            var errors = identityResult.Errors.Select(x => x.Description);
            _logger.LogDebug($"Не удалось создать тестового пользователя: {string.Concat(errors)}");
        }
    }
}