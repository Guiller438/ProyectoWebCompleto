using Microsoft.AspNetCore.Mvc;
using IW7PP.Data;
using IW7PP.Models.ProsthesisM;

namespace IW7PP.Controllers.ComponentsControllers
{
    public class UnionSocketsController : Controller
    {
        //Conexion con db context
        private readonly ApplicationDbContext _context;

        public UnionSocketsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var unionSockets = _context.UnionSockets.ToList();
            return View(unionSockets);
        }

        //Create 

        [HttpGet]
        public IActionResult CreateUnionSocket()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUnionSocket(UnionSocket us)
        {
            if (ModelState.IsValid)
            {
                _context.UnionSockets.Add(us);
                await _context.SaveChangesAsync();
                return RedirectToAction("UnionSocketsView", "Prosthesis");
            }
            return View(us);
        }

        //Edit

        [HttpGet]
        public IActionResult EditUnionSocket(int id)
        {
            if (Guid.Equals == null)
            {
                return View();
            }
            else
            {
                //Actualizar el registro
                var us = _context.UnionSockets.FirstOrDefault(a => a.Id == id);
                return View(us);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUnionSocket(UnionSocket us)
        {
            if (ModelState.IsValid)
            {
                _context.UnionSockets.Update(us);
                await _context.SaveChangesAsync();
                return RedirectToAction("UnionSocketsView", "Prosthesis");
            }
            return View(us);
        }

        //Delete

        [HttpPost]
        public async Task<IActionResult> DeleteUnionSocket(int id)
        {
            var us = _context.UnionSockets.FirstOrDefault(a => a.Id == id);
            if (us == null)
            {
                return RedirectToAction("Index", "Prosthesis");
            }
            else
            {
                _context.UnionSockets.Remove(us);
                await _context.SaveChangesAsync();
                return RedirectToAction("UnionSocketsView", "Prosthesis");
            }

        }
    }
}
