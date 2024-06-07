using IW7PP.Data;
using IW7PP.Models.ProsthesisM;
using Microsoft.AspNetCore.Mvc;

namespace IW7PP.Controllers.ComponentsControllers
{
    public class KneeArticulateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KneeArticulateController( ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var kneeArticulates = _context.KneeArticulates.ToList();
            return View(kneeArticulates);
        }

        //Create 

        [HttpGet]
        public IActionResult CreateKnee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateKnee(KneeArticulate Knee)
        {
            if (ModelState.IsValid)
            {
                _context.KneeArticulates.Add(Knee);
                await _context.SaveChangesAsync();
                return RedirectToAction("KneeArticulateView", "Prosthesis");
            }
            return View(Knee);
        }

        //Edit

        [HttpGet]
        public IActionResult EditKnee(int id)
        {
            if (Guid.Equals == null)
            {
                return View();
            }
            else
            {
                //Actualizar el registro
                var feet = _context.KneeArticulates.FirstOrDefault(a => a.Id == id);
                return View(feet);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditKnee(KneeArticulate Knee)
        {
            if (ModelState.IsValid)
            {
                _context.KneeArticulates.Update(Knee);
                await _context.SaveChangesAsync();
                return RedirectToAction("KneeArticulateView", "Prosthesis");
            }
            return View(Knee);
        }

        //Delete

        [HttpPost]
        public async Task<IActionResult> DeleteKnee(int id)
        {
            var knee = _context.KneeArticulates.FirstOrDefault(a => a.Id == id);
            if (knee == null)
            {
                return RedirectToAction("Index", "Prosthesis");
            }
            else
            {
                _context.KneeArticulates.Remove(knee);
                await _context.SaveChangesAsync();
                return RedirectToAction("KneeArticulateView", "Prosthesis");
            }

        }
    }
}
