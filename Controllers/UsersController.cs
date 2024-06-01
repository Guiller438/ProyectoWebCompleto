using IW7PP.Data;
using IW7PP.Models;

using IW7PP.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.RegularExpressions;

namespace IW7PP.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public UsersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
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


        //Metodos para editar y eliminar usuarios

        [HttpGet]
        public IActionResult Editar(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Users", "Registro");
            }
            else
            {
                var userDB = _context.Users.FirstOrDefault(u => u.Id == id);
                return View(userDB);
            }

        }


        public async Task<IActionResult> Editar(IdentityUser user)
        {
            var userDb = _context.Users.FirstOrDefault(u => u.Id == u.Id);
            if (userDb == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                userDb.UserName = user.UserName;
                userDb.Email = user.Email;
                userDb.PhoneNumber = user.PhoneNumber;
                var resultado = await _userManager.UpdateAsync(userDb);
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpPost]

        public async Task<IActionResult> Borrar(string id)
        {
            var userDB = _context.Users.FirstOrDefault(u => u.Id == id);
            if (userDB == null)
            {
                TempData["Error"] = "No existe el rol";
                return RedirectToAction(nameof(Index));
            }


            await _userManager.DeleteAsync(userDB);
            TempData["Correcto"] = "Rol borrado correctamente";
            return RedirectToAction(nameof(Index));
        }


    }
}
