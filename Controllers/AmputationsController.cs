using IW7PP.Data;
using IW7PP.Models.Amputations;
using IW7PP.Models.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IW7PP.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AmputationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AmputationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var amputations = _context.UpperLimbAmputations.ToList();
            return View(amputations);
        }

        public IActionResult LowerLimbAmputations()
        {
            var amputations = _context.LowerLimbAmputations.ToList();
            return View(amputations);
        }

        [HttpGet]
        public IActionResult CreateUap()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUap(UpperLimbAmputation aup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aup);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Amputación de miembro superior creada exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(aup);
        }

        [HttpGet]
        public IActionResult EditUap(Guid id)
        {
            if (id == Guid.Empty)
            {
                return View();
            }
            else
            {
                var amputation = _context.UpperLimbAmputations.FirstOrDefault(a => a.Id == id);
                return View(amputation);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUap(UpperLimbAmputation uap)
        {
            var amputation = _context.UpperLimbAmputations.FirstOrDefault(a => a.Id == uap.Id);
            if (amputation == null)
            {
                TempData["Error"] = "No existe la amputación.";
                return RedirectToAction(nameof(Index));
            }

            amputation.AmputationName = uap.AmputationName;

            await _context.SaveChangesAsync();
            TempData["Success"] = "Amputación de miembro superior actualizada exitosamente.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            var amputation = _context.UpperLimbAmputations.FirstOrDefault(a => a.Id == id);
            var amputationL = _context.LowerLimbAmputations.FirstOrDefault(a => a.Id == id);
            if (amputation == null && amputationL == null)
            {
                TempData["Error"] = "No existe la amputación.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                if (amputationL == null)
                {
                    _context.UpperLimbAmputations.Remove(amputation);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Amputación de miembro superior eliminada exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _context.LowerLimbAmputations.Remove(amputationL);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Amputación de miembro inferior eliminada exitosamente.";
                    return RedirectToAction(nameof(LowerLimbAmputations));
                }
            }
        }

        // Método para alp
        [HttpGet]
        public IActionResult CreateAlp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlp(LowerLimbAmputation alp)
        {
            if (ModelState.IsValid)
            {
                _context.LowerLimbAmputations.Add(alp);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Amputación de miembro inferior creada exitosamente.";
                return RedirectToAction(nameof(LowerLimbAmputations));
            }
            return View(alp);
        }

        [HttpGet]
        public IActionResult EditAlp(Guid id)
        {
            if (id == Guid.Empty)
            {
                return View();
            }
            else
            {
                var amputation = _context.LowerLimbAmputations.FirstOrDefault(a => a.Id == id);
                return View(amputation);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditAlp(LowerLimbAmputation alp)
        {
            var amputation = _context.LowerLimbAmputations.FirstOrDefault(a => a.Id == alp.Id);
            if (amputation == null)
            {
                TempData["Error"] = "No existe la amputación.";
                return RedirectToAction(nameof(LowerLimbAmputations));
            }

            amputation.AmputationName = alp.AmputationName;

            await _context.SaveChangesAsync();
            TempData["Success"] = "Amputación de miembro inferior actualizada exitosamente.";
            return RedirectToAction(nameof(LowerLimbAmputations));
        }
    }
}
