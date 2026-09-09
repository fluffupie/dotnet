using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExample.Controllers;

[Authorize]
public class CustomerController : Controller
{
  private readonly UserManager<IdentityUser> _userManager;

  public CustomerController(UserManager<IdentityUser> userManager)
  {
    _userManager = userManager;
  }

  public async Task<IActionResult> Index()
  {
    var user = await _userManager.GetUserAsync(User);

    return View(user);
  }
}
