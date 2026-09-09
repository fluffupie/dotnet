using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExample.Controllers;

[Route("/Mcba/SecureLogin")]
public class LoginController : Controller
{
  private readonly SignInManager<IdentityUser> _signInManager;

  public LoginController(SignInManager<IdentityUser> signInManager)
  {
    _signInManager = signInManager;
  }

  public IActionResult Login() => View();

  [HttpPost]
  public async Task<IActionResult> Login(string email, string password)
  {
    var result = await _signInManager.PasswordSignInAsync(email, password, true, false);
    if (!result.Succeeded)
    {
      ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
      return View(new IdentityUser { Email = email });
    }

    return RedirectToAction("Index", "Customer");
  }

  [Route("LogoutNow")]
  public async Task<IActionResult> Logout()
  {
    await _signInManager.SignOutAsync();

    return RedirectToAction("Index", "Home");
  }
}
