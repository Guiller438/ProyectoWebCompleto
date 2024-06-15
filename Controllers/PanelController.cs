using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class PanelController : Controller
{
    [Authorize(Roles = "Administrador")]
    public IActionResult Admin()
    {
        return View();
    }

    [Authorize(Roles = "Protesista")]
    public IActionResult Protesista()
    {
        return RedirectToAction("Index", "Protesista");
    }
}
