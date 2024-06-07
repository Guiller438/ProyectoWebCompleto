using IW7PP.Data;
using IW7PP.Models.ProsthesisM;
using Microsoft.AspNetCore.Mvc;

namespace IW7PP.Controllers.ComponentsControllers
{
    public class TubesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TubesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tubes = _context.Tubes.ToList();
            return View(tubes);
        }

        //Create 

        [HttpGet]
        public IActionResult CreateTube()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTube(Tube tube)
        {
            if (ModelState.IsValid)
            {
                _context.Tubes.Add(tube);
                await _context.SaveChangesAsync();
                return RedirectToAction("TubesView", "Prosthesis");
            }
            return View(tube);
        }

        //Edit

        [HttpGet]
        public IActionResult EditTube(int id)
        {
            if (Guid.Equals == null)
            {
                return View();
            }
            else
            {
                //Actualizar el registro
                var tubes= _context.Tubes.FirstOrDefault(a => a.Id == id);
                return View(tubes);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditTube(Tube tube)
        {
            if (ModelState.IsValid)
            {
                _context.Tubes.Update(tube);
                await _context.SaveChangesAsync();
                return RedirectToAction("TubesView", "Prosthesis");
            }
            return View(tube);
        }

        //Delete

        [HttpPost]
        public async Task<IActionResult> DeleteTube(int id)
        {
            var tube = _context.Tubes.FirstOrDefault(a => a.Id == id);
            if (tube == null)
            {
                return RedirectToAction("Index", "Prosthesis");
            }
            else
            {
                _context.Tubes.Remove(tube);
                await _context.SaveChangesAsync();
                return RedirectToAction("TubesView  ", "Prosthesis");
            }

        }
    }
}
