using Microsoft.AspNetCore.Mvc;
using IW7PP.Data;
using IW7PP.Models.ProsthesisM;


namespace IW7PP.Controllers.ComponentsControllers
{
    public class FeetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeetController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var feet = _context.Feet.ToList();
            return View(feet);
        }

        //Create 
        
        [HttpGet]
        public IActionResult CreateFeet()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeet(Foot foot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foot);
                await _context.SaveChangesAsync();
                return RedirectToAction("FeetView", "Prosthesis");
            }
            return View(foot);
        }

        //Edit

        [HttpGet]
        public IActionResult EditFeet(int id)
        {
            if (Guid.Equals == null)
            {
                return View();
            }
            else
            {
                //Actualizar el registro
                var feet = _context.Feet.FirstOrDefault(a => a.Id == id);
                return View(feet);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditFeet(Foot foot)
        {
            if (ModelState.IsValid)
            {
                _context.Update(foot);
                await _context.SaveChangesAsync();
                return RedirectToAction("FeetView", "Prosthesis");
            }
            return View(foot);
        }

        //Delete

        [HttpPost]
        public async Task<IActionResult> DeleteFeet(int id)
        {
            var feet = _context.Feet.FirstOrDefault(a => a.Id == id);
            if(feet == null)
            {
                return RedirectToAction("Index", "Prosthesis");
            }else
            {
                _context.Feet.Remove(feet);
                await _context.SaveChangesAsync();
                return RedirectToAction("FeetView", "Prosthesis");
            }

        }
        //Metodo para obtener la durabnilidad

        [HttpGet]
        public double GetDurability(int id)
        {
            var foot = _context.Feet.FirstOrDefault(a => a.Id == id);

            if (foot == null)
            {
                return foot.Durability; // Return 404 if the foot is not found
            }

            return 0; // Return the durability value
        }
    }
}
