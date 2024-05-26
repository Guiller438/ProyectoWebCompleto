using IW7PP.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IW7PP.Controllers
{
    [Authorize (Roles ="Administrador")]

    public class RoleController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Crear()
        {           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(IdentityRole rol)
        {
            if (await _roleManager.RoleExistsAsync(rol.Name))
            {
                TempData["Error"] = "El rol ya existe";
                return RedirectToAction(nameof(Index));
            }

            //Se crea el rol
            await _roleManager.CreateAsync(new IdentityRole() { Name = rol.Name});
            TempData["Correcto"] = "Rol creado correctamente";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return View();
            }
            else
            {
                //Actualizar el rol
                var rolBD = _context.Roles.FirstOrDefault(r => r.Id == id);
                return View(rolBD);
            }
            
        }

        [HttpPost]

        public async Task<IActionResult> Editar(IdentityRole rol)
        {
            if (await _roleManager.RoleExistsAsync(rol.Name))
            {
                TempData["Error"] = "El rol ya existe";
                return RedirectToAction(nameof(Index));
            }

            //Se crea el rol
            var rolBD = _context.Roles.FirstOrDefault(r => r.Id == rol.Id);
            if (rolBD == null)
            {
                return RedirectToAction(nameof(Index));
            }

            rolBD.Name = rol.Name;
            rolBD.NormalizedName = rol.Name.ToUpper();
            var resultado = await _roleManager.UpdateAsync(rolBD);
            TempData["Correcto"] = "Rol editado correctamente";
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]

        public async Task<IActionResult> Borrar(string id)
        {
            var rolBD = _context.Roles.FirstOrDefault(r => r.Id == id);
            if (rolBD == null)
            {
                TempData["Error"] = "No existe el rol";
                return RedirectToAction(nameof(Index));
            }

            var usuariosParaEsteRol = _context.UserRoles.Where(u => u.RoleId == id).Count();
            if (usuariosParaEsteRol > 0)
            {
                TempData["Error"] = "El rol tiene usuarios, no se puede borrar";
                return RedirectToAction(nameof(Index));
            }            

            await _roleManager.DeleteAsync(rolBD);
            TempData["Correcto"] = "Rol borrado correctamente";
            return RedirectToAction(nameof(Index));
        }
    }
}
