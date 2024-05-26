using IW7PP.Data;
using IW7PP.Models;
using IW7PP.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IW7PP.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditAccount(string id)
        {
            if (id == null)
            {
                return NotFound("La cuenta no fue encontrada");
            }
            else
            {
                var userBD = _context.Users.Find(id);
                if (userBD == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(userBD);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditAccount(UserModel usermodel)
        {
            if (!ModelState.IsValid)
            {
                var user = await _context.Users.FindAsync(usermodel.Id);
                user.UserName = usermodel.UserName;
                user.Email = usermodel.Email;
                user.PhoneNumber = usermodel.PhoneNumber;

                await _userManager.UpdateAsync(user);

                return RedirectToAction("Index", "Home");
            }
            return View(usermodel);
        }
    }
}
