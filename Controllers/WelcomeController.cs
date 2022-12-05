using com.itransition.messenger.Models.Data;
using com.itransition.messenger.Models.ViewModels;
using com.itransition.messenger.Services;
using Microsoft.AspNetCore.Mvc;

namespace com.itransition.messenger.Controllers;

public class WelcomeController : Controller
{
    private readonly IUserService _userService;

    public WelcomeController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Entrance()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var sessionData = _userService.CreateIfNotExistByNickName(model).UserId;
        HttpContext.Session.SetString("session_id", sessionData.ToString());
        return RedirectToAction("Home", "Messenger");
    }
}