using Xunit;
using SafeVault.Services;
using SafeVault.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class TestAuthentication
{
    private readonly UserService _userService;
    private readonly ApplicationDbContext _context;

    public TestAuthentication()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _context = new ApplicationDbContext(options);
        _userService = new UserService(_context);
    }

    [Fact]
    public void TestRegisterAndLoginUser()
    {
        var username = "testuser";
        var email = "test@example.com";
        var password = "Password123!";
        var role = "user";

        var registerResult = _userService.RegisterUser(username, email, password, role);
        Assert.True(registerResult);

        var loginResult = _userService.LoginUser(username, password);
        Assert.True(loginResult);
    }

    [Fact]
    public void TestInvalidLogin()
    {
        var loginResult = _userService.LoginUser("nonexistentuser", "wrongpassword");
        Assert.False(loginResult);
    }
}