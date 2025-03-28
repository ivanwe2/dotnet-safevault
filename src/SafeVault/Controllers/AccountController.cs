using Microsoft.AspNetCore.Mvc;
using SafeVault.Services;
using SafeVault.Models;

public class AccountController : Controller
{
    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = _userService.RegisterUser(model.Username, model.Email, model.Password, "user");
            if (result)
                return RedirectToAction("Login");
            ModelState.AddModelError("", "Registration failed");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = _userService.LoginUser(model.Username, model.Password);
            if (result)
                return RedirectToAction("Index", "Home");
            ModelState.AddModelError("", "Login failed");
        }
        return View(model);
    }
}