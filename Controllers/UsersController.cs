using IW7PP.Models;
using IW7PP.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace IW7PP.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Registro()
        {
            if(!await _roleManager.RoleExistsAsync("Administrador"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Administrador"));
            }

            if (!await _roleManager.RoleExistsAsync("Protesista"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Protesista"));
            }

            if (!await _roleManager.RoleExistsAsync("Cliente"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Cliente"));
            }


            RegistroVM registroVM = new RegistroVM();
            return View(registroVM);
        }


        [HttpPost]
        public async Task<IActionResult> Registro(RegistroVM usModel)
        {
            if (ModelState.IsValid)
            {
                if (usModel.Password.Equals(usModel.ConfirmPassword))
                {
                    var usuario = new UserModel
                    {
                        Name = usModel.Name,
                        LastName = usModel.LastName,
                        UserName = usModel.UserName,
                        Email = usModel.Email,
                        PhoneNumber = usModel.PhoneNumber
                    };

                    var resultado = await _userManager.CreateAsync(usuario, usModel.Password);


                    if (resultado.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(usuario, "Cliente");

                        await _signInManager.SignInAsync(usuario, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewData["Mensaje"] = "No se logró crear el usuario";
                    }
                }
                else
                {
                    ViewData["Mensaje"] = "Las contraseñas no coinciden";
                    return View();
                }

            }

            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM userModel)
        {
            if (ModelState.IsValid)
            {

                var resultado = await _signInManager.PasswordSignInAsync(userModel.UserName, userModel.Password, isPersistent:false, lockoutOnFailure: false);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Mensaje"] = "No se logró iniciar sesión";
                    return View(userModel);
                }

            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
