using Microsoft.AspNetCore.Mvc;
using IW7PP.Data;
using IW7PP.Models.ProsthesisM;

namespace IW7PP.Controllers.ComponentsControllers
{
    public class LinerController : Controller
    {
        private readonly ApplicationDbContext _context; 

        public LinerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var liners = _context.Liners.ToList();  
            return View(liners);
        }

        //Create 

        [HttpGet]
        public IActionResult CreateLiner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLiner(Liner liner)
        {
            if (ModelState.IsValid)
            {
                _context.Liners.Add(liner);
                await _context.SaveChangesAsync();
                return RedirectToAction("LinerView", "Prosthesis");
            }
            return View(liner);
        }

        //Edit

        [HttpGet]
        public IActionResult EditLiner(int id)
        {
            if (Guid.Equals == null)
            {
                return View();
            }
            else
            {
                //Actualizar el registro
                var liners = _context.Liners.FirstOrDefault(a => a.Id == id);
                return View(liners);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditLiner(Liner liner)
        {
            if (ModelState.IsValid)
            {
                _context.Liners.Update(liner);
                await _context.SaveChangesAsync();
                return RedirectToAction("LinerView", "Prosthesis");
            }
            return View(liner);
        }

        //Delete

        [HttpPost]
        public async Task<IActionResult> DeleteLiner(int id)
        {
            var liner = _context.Liners.FirstOrDefault(a => a.Id == id);
            if (liner == null)
            {
                return RedirectToAction("Index", "Prosthesis");
            }
            else
            {
                _context.Liners.Remove(liner);
                await _context.SaveChangesAsync();
                return RedirectToAction("LinerView", "Prosthesis");
            }

        }
    }
}
