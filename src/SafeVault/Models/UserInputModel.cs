using System.ComponentModel.DataAnnotations;

namespace SafeVault.Models;

public class UserInputModel
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}

public class RegisterViewModel
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginViewModel
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}