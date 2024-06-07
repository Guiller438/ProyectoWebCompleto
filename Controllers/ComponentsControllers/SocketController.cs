using Microsoft.AspNetCore.Mvc;
using IW7PP.Data;
using IW7PP.Models.ProsthesisM;

namespace IW7PP.Controllers.ComponentsControllers
{
    public class SocketController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public SocketController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var sockets = _context.Sockets.ToList();
            return View(sockets);
        }

        //Create 

        [HttpGet]
        public IActionResult CreateSocket()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocket(Socket socket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socket);
                await _context.SaveChangesAsync();
                return RedirectToAction("SocketView", "Prosthesis");
            }
            return View(socket);
        }

        //Edit

        [HttpGet]
        public IActionResult EditSocket(int id)
        {
            if (Guid.Equals == null)
            {
                return View();
            }
            else
            {
                //Actualizar el registro
                var feet = _context.Sockets.FirstOrDefault(a => a.Id == id);
                return View(feet);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditSocket(Socket socket)
        {
            if (ModelState.IsValid)
            {
                _context.Update(socket);
                await _context.SaveChangesAsync();
                return RedirectToAction("SocketView", "Prosthesis");
            }
            return View(socket);
        }

        //Delete

        [HttpPost]
        public async Task<IActionResult> DeleteSocket(int id)
        {
            var socket = _context.Sockets.FirstOrDefault(a => a.Id == id);
            if (socket == null)
            {
                return RedirectToAction("Index", "Prosthesis");
            }
            else
            {
                _context.Sockets.Remove(socket);
                await _context.SaveChangesAsync();
                return RedirectToAction("SocketView", "Prosthesis");
            }

        }
    }
}
