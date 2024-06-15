using IW7PP.Data;
using IW7PP.Models;

using IW7PP.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            await EnsureRolesExist();

            var roles = _roleManager.Roles.Select(role => new SelectListItem
            {
                Value = role.Id.ToString(),
                Text = role.Name
            }).ToList();

            RegistroVM registroVM = new RegistroVM
            {
                Roles = roles
            };

            return View(registroVM);
        }

        [HttpPost]
        public async Task<IActionResult> Registro(RegistroVM usModel)
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
                var role = await _roleManager.FindByIdAsync(usModel.SelectedRole.ToString());
                if (role != null)
                {
                    await _userManager.AddToRoleAsync(usuario, role.Name);
                }

                return RedirectToAction("Login", "Index");
            }
            else
            {
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }


            // Recargar los roles en caso de error para que se muestren correctamente en la vista
            usModel.Roles = _roleManager.Roles.Select(role => new SelectListItem
            {
                Value = role.Id.ToString(),
                Text = role.Name
            }).ToList();

            return View(usModel);
        }

        private async Task EnsureRolesExist()
        {
            if (!await _roleManager.RoleExistsAsync("Administrador"))
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
                var resultado = await _signInManager.PasswordSignInAsync(userModel.UserName, userModel.Password, isPersistent: false, lockoutOnFailure: false);

                if (resultado.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(userModel.UserName);
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles.Contains("Administrador"))
                    {
                        return RedirectToAction("Admin", "Panel");
                    }
                    else if (roles.Contains("Protesista"))
                    {
                        return RedirectToAction("Protesista", "Panel");
                    }
                    else
                    {
                        return RedirectToAction("Login", "Users");
                    }
                }
                else
                {
                    ViewData["Mensaje"] = "No se logró iniciar sesión";
                    return View(userModel);
                }
            }
            return View(userModel);
        }

        [HttpPost]

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Users");
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


        [HttpGet]

        public async Task<IActionResult> CreateUser()
        {
            await EnsureRolesExist();

            var roles = _roleManager.Roles.Select(role => new SelectListItem
            {
                Value = role.Id.ToString(),
                Text = role.Name
            }).ToList();

            RegistroVM registroVM = new RegistroVM
            {
                Roles = roles
            };

            return View(registroVM);
        }

        [HttpPost]

        public async Task<IActionResult> CreateUser(RegistroVM usModel)
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
                var role = await _roleManager.FindByIdAsync(usModel.SelectedRole.ToString());
                if (role != null)
                {
                    await _userManager.AddToRoleAsync(usuario, role.Name);
                }

                return RedirectToAction("Login", "Users");
            }
            else
            {
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }


            // Recargar los roles en caso de error para que se muestren correctamente en la vista
            usModel.Roles = _roleManager.Roles.Select(role => new SelectListItem
            {
                Value = role.Id.ToString(),
                Text = role.Name
            }).ToList();

            return View(usModel);
        }
    }
}