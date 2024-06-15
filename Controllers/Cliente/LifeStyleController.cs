using IW7PP.Data;
using IW7PP.Models.Cliente;
using IW7PP.Models.ProsthesisM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace IW7PP.Controllers.Cliente
{
    [Authorize(Roles="Administrador")]
    public class LifeStyleController : Controller
    {

        private readonly ApplicationDbContext _context;

        public LifeStyleController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Lifestyleview()
        {
            var lifestyleT = _context.LifeStyles.ToList();
            return View(lifestyleT);
        }

        //Create 

        [HttpGet]
        public IActionResult CreateStyle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStyle(LifeStyle style)
        {
            if (ModelState.IsValid)
            {
                _context.LifeStyles.Add(style);
                await _context.SaveChangesAsync();
                return RedirectToAction("Lifestyleview", "Cliente");
            }
            return View(style);
        }

        //Edit

        [HttpGet]
        public IActionResult EditStyle(int id)
        {
            if (Guid.Equals == null)
            {
                return View();
            }
            else
            {
                //Actualizar el registro
                var style = _context.LifeStyles.FirstOrDefault(a => a.Id == id);
                return View(style);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditStyle(LifeStyle style)
        {
            if (ModelState.IsValid)
            {
                _context.Update(style);
                await _context.SaveChangesAsync();
                return RedirectToAction("Lifestyleview", "Cliente");
            }
            return View(style);
        }

        //Delete

        [HttpPost]
        public async Task<IActionResult> DeleteStyle(int id)
        {
            var style = _context.LifeStyles.FirstOrDefault(a => a.Id == id);
            if (style == null)
            {
                return RedirectToAction("Lifestyleview", "Cliente");
            }
            else
            {
                _context.LifeStyles.Remove(style);
                await _context.SaveChangesAsync();
                return RedirectToAction("Lifestyleview", "Cliente");
            }

        }
        //Asignar un lifestyle según preguntas

        // Assign Lifestyle based on questions
        [HttpGet]
        public IActionResult AssignLifestyle()
        {
            return View();
        }

        [HttpPost]
        public int AssignLifestyle(int score)
        {
            var finaLifeStyle = _context.LifeStyles;

            if(score >= 0 && score <= 50) 
            {

                return finaLifeStyle.FirstOrDefault(s => s.Name == "Sedentario").Id;

            }
            else if (score >= 50 && score <= 90) 
            {

                return finaLifeStyle.FirstOrDefault(s => s.Name == "Activo").Id;

            }
            else
            {

                return finaLifeStyle.FirstOrDefault(s => s.Name == "Deportista").Id;

            }   
        }

    }
}
