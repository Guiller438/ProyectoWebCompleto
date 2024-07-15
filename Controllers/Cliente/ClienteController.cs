using IW7PP.Data;
using IW7PP.Models.Amputations;
using IW7PP.Models.Cliente;
using IW7PP.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IW7PP.Controllers.Cliente
{
    [Authorize(Roles = "Administrador, Protesista")]
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LifeStyleController _LifeStyle; 

        public ClienteController(ApplicationDbContext context,LifeStyleController lifestyle )
        {
            _context = context;
            _LifeStyle = lifestyle;
        }
        public IActionResult Index()
        {
            var clienteList = _context.ClientesProtesicos
                    .Include(p => p.Prosthesis)
                    .Include(p => p.LifeStyle)
                    .ToList();

            return View(clienteList);
        }

        public IActionResult LifeStyleView()
        {
            return _LifeStyle.Lifestyleview();
        }

        [HttpGet]

        public IActionResult CreateCliente()
        {
            if (TempData["LifeStyleId"] == null)
            {
                return RedirectToAction("AssignLifestyle"); // Si el estilo de vida no se ha asignado, redirigir a AssignLifestyle
            }

            var model = new ClienteVM
            {
                LifeStyleId = TempData["LifeStyleId"] != null ? (int)TempData["LifeStyleId"] : 0
            };

            ViewBag.FromSelectAmputationType = TempData["FromSelectAmputationType"] != null;

            ViewData["ProsthesisId"] = new SelectList(_context.Prostheses, "Id", "Id");
            ViewData["LifeStyleId"] = new SelectList(_context.LifeStyles, "Id", "Description");

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> CreateCliente([Bind("Id, Name, LastName, PhoneNumber, ProtesisId, LifeStyleId ")] ClienteVM cliente) 
        {

            ViewBag.FromSelectAmputationType = TempData["FromSelectAmputationType"];
            if (ModelState.IsValid)
            {
                // Verificar si ya existe un cliente con el mismo ProtesisId
                bool exists = _context.ClientesProtesicos.Any(c => c.ProtesisId == cliente.ProtesisId);
                if (exists && TempData["FromSelectAmputationType"] != null)
                {
                    ModelState.AddModelError("ProtesisId", "Ya existe un cliente con esta prótesis.");
                    ViewData["ProsthesisId"] = new SelectList(_context.Prostheses, "Id", "Id");
                    ViewData["LifeStyleId"] = new SelectList(_context.LifeStyles, "Id", "Description");
                    return View(cliente);
                }

                if (TempData["FromSelectAmputationType"] != null)
                {
                    cliente.ProtesisId = null;
                }

                var clienteNuevo = new ClientesProtesicos
                {
                    Name = cliente.Name,
                    LastName = cliente.LastName,
                    PhoneNumber = cliente.PhoneNumber,
                    ProtesisId = cliente.ProtesisId,
                    LifeStyleId = cliente.LifeStyleId,
                };

                _context.ClientesProtesicos.Add(clienteNuevo);
                await _context.SaveChangesAsync();

                if (clienteNuevo.ProtesisId == null && TempData["FromSelectAmputationType"] == null)
                {
                    Guid? amputationId = null;

                    if (TempData.ContainsKey("UpperLimbAmputationId") && Guid.TryParse(TempData["UpperLimbAmputationId"].ToString(), out Guid upperLimbId))
                    {
                        amputationId = upperLimbId;
                    }
                    else if (TempData.ContainsKey("LowerLimbAmputationId") && Guid.TryParse(TempData["LowerLimbAmputationId"].ToString(), out Guid lowerLimbId))
                    {
                        amputationId = lowerLimbId;
                    }

                    if (amputationId.HasValue)
                    {
                        if (TempData.ContainsKey("UpperLimbAmputationId") && TempData["UpperLimbAmputationId"].ToString() == amputationId.Value.ToString())
                        {
                            return RedirectToAction("GenerateUpperProsthesis", "Protesista", new { amputationId = amputationId.Value, clienteId = clienteNuevo.Id });
                        }
                        else if (TempData.ContainsKey("LowerLimbAmputationId") && TempData["LowerLimbAmputationId"].ToString() == amputationId.Value.ToString())
                        {
                            return RedirectToAction("GenerateLowerProsthesis", "Protesista", new { amputationId = amputationId.Value, clienteId = clienteNuevo.Id });
                        }
                    }
                }


                return RedirectToAction("Index", "Cliente");


            }
            else
                {
                ViewData["ProsthesisId"] = new SelectList(_context.Prostheses, "Id", "Id");
                ViewData["LifeStyleId"] = new SelectList(_context.LifeStyles, "Id", "Description");
                return View(cliente);
            }
        }

        //Delete
        [HttpPost]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = _context.ClientesProtesicos.FirstOrDefault(a => a.Id == id);
            if (cliente == null)
            {
                return RedirectToAction("Index", "Cliente");
            }
            else
            {
                _context.ClientesProtesicos.Remove(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Cliente");
            }

        }

        // Assign Lifestyle based on questions
        [HttpGet]
        public IActionResult AssignLifestyle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AssignLifestyle(int score)
        {
            var lifeStyleId = _LifeStyle.AssignLifestyle(score);
            TempData["LifeStyleId"] = lifeStyleId;
            return RedirectToAction("CreateCliente");
        }


        [HttpGet]
        public IActionResult EditarCliente(int id)
        {
            var cliente = _context.ClientesProtesicos.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            var model = new ClienteVM
            {
                Id = cliente.Id,
                Name = cliente.Name,
                LastName = cliente.LastName,
                PhoneNumber = cliente.PhoneNumber,
                ProtesisId = cliente.ProtesisId,
                LifeStyleId = cliente.LifeStyleId
            };

            ViewBag.FromSelectAmputationType = TempData["FromSelectAmputationType"] != null;
            ViewData["ProsthesisId"] = new SelectList(_context.Prostheses, "Id", "Id", cliente.ProtesisId);
            ViewData["LifeStyleId"] = new SelectList(_context.LifeStyles, "Id", "Description", cliente.LifeStyleId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditarCliente(int id, [Bind("Id, Name, LastName, PhoneNumber, ProtesisId, LifeStyleId")] ClienteVM cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Verificar si ya existe un cliente con el mismo ProtesisId
                bool exists = _context.ClientesProtesicos.Any(c => c.ProtesisId == cliente.ProtesisId && c.Id != cliente.Id);
                if (exists && TempData["FromSelectAmputationType"] != null)
                {
                    ModelState.AddModelError("ProtesisId", "Ya existe un cliente con esta prótesis.");
                    ViewData["ProsthesisId"] = new SelectList(_context.Prostheses, "Id", "Id", cliente.ProtesisId);
                    ViewData["LifeStyleId"] = new SelectList(_context.LifeStyles, "Id", "Description", cliente.LifeStyleId);
                    return View(cliente);
                }

                if (TempData["FromSelectAmputationType"] != null)
                {
                    cliente.ProtesisId = null;
                }

                try
                {
                    var clienteExistente = await _context.ClientesProtesicos.FindAsync(cliente.Id);
                    if (clienteExistente == null)
                    {
                        return NotFound();
                    }

                    clienteExistente.Name = cliente.Name;
                    clienteExistente.LastName = cliente.LastName;
                    clienteExistente.PhoneNumber = cliente.PhoneNumber;
                    clienteExistente.ProtesisId = cliente.ProtesisId;
                    clienteExistente.LifeStyleId = cliente.LifeStyleId;

                    await _context.SaveChangesAsync();

                    // Redirigir si la prótesis es nula y no viene de SelectAmputationType
                    if (clienteExistente.ProtesisId == null && TempData["FromSelectAmputationType"] == null)
                    {
                        Guid? amputationId = null;

                        if (TempData.ContainsKey("UpperLimbAmputationId") && Guid.TryParse(TempData["UpperLimbAmputationId"].ToString(), out Guid upperLimbId))
                        {
                            amputationId = upperLimbId;
                        }
                        else if (TempData.ContainsKey("LowerLimbAmputationId") && Guid.TryParse(TempData["LowerLimbAmputationId"].ToString(), out Guid lowerLimbId))
                        {
                            amputationId = lowerLimbId;
                        }

                        if (amputationId.HasValue)
                        {
                            if (TempData.ContainsKey("UpperLimbAmputationId") && TempData["UpperLimbAmputationId"].ToString() == amputationId.Value.ToString())
                            {
                                return RedirectToAction("GenerateUpperProsthesis", "Protesista", new { amputationId = amputationId.Value, clienteId = clienteExistente.Id });
                            }
                            else if (TempData.ContainsKey("LowerLimbAmputationId") && TempData["LowerLimbAmputationId"].ToString() == amputationId.Value.ToString())
                            {
                                return RedirectToAction("GenerateLowerProsthesis", "Protesista", new { amputationId = amputationId.Value, clienteId = clienteExistente.Id });
                            }
                        }
                    }

                    return RedirectToAction("Index", "Cliente");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.ClientesProtesicos.Any(e => e.Id == cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewData["ProsthesisId"] = new SelectList(_context.Prostheses, "Id", "Id", cliente.ProtesisId);
            ViewData["LifeStyleId"] = new SelectList(_context.LifeStyles, "Id", "Description", cliente.LifeStyleId);
            return View(cliente);
        }


        [HttpPost]
        public async Task<IActionResult> SetDonationGoals()
        {
            var clientes = await _context.ClientesProtesicos.ToListAsync();
            Random rnd = new Random();

            foreach (var cliente in clientes)
            {
                double donationstatus = Math.Round((double)(rnd.Next(500, 5000) + rnd.NextDouble()));
                if (donationstatus < cliente.DonationGoal)
                {
                    cliente.DonationStatus = donationstatus;
                }
                else
                {
                    cliente.DonationStatus = Math.Round(cliente.DonationGoal * 0.9, 2);
                }
                _context.ClientesProtesicos.Update(cliente);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Metas de donaciones actualizadas correctamente." });
        }


    }
}
