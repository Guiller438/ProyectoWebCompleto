using IW7PP.Data;
using IW7PP.Models.Cliente;
using IW7PP.Models.ProsthesisM;
using IW7PP.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace IW7PP.Controllers.ComponentsControllers
{
    public class ProsthesisController : Controller
    {

        ApplicationDbContext _context;
        FeetController _feetController;

        KneeArticulateController _kneeArticulateController;

        LinerController _linerController;

        SocketController _socketController;

        TubesController _tubesController;

        UnionSocketsController _unionSocketsController;



        public ProsthesisController(ApplicationDbContext context, FeetController feetController, KneeArticulateController kneeArticulateController, LinerController linerController, SocketController socketController, TubesController tubesController, UnionSocketsController unionSocketsController)
        {
            _context = context;
            _feetController = feetController;
            _kneeArticulateController = kneeArticulateController;
            _linerController = linerController;
            _socketController = socketController;
            _tubesController = tubesController;
            _unionSocketsController = unionSocketsController;


        }

        public IActionResult Index()
        {
            var prosthesisList = _context.Prostheses
                                .Include(p => p.Socket)
                                .Include(p => p.Liner)
                                .Include(p => p.Tube)
                                .Include(p => p.Foot)
                                .Include(p => p.UnionSocket)
                                .Include(p => p.RodillaArticulada)
                                .Include(p => p.UpperLimbAmputations)
                                .Include(p => p.LowerLimbAmputations)
                                .ToList();

            return View(prosthesisList);
        }

        //Feet
        public IActionResult FeetView()
        {
            return _feetController.Index();
        }

        //KneeArticulate

        public IActionResult KneeArticulateView()
        {
            return _kneeArticulateController.Index();
        }

        //Liner

        public IActionResult LinerView()
        {
            return _linerController.Index();
        }

        //Socket

        public IActionResult SocketView()
        {
            return _socketController.Index();
        }

        //Tubes

        public IActionResult TubesView()
        {
            return _tubesController.Index();
        }

        //UnionSockets

        public IActionResult UnionSocketsView()
        {
            return _unionSocketsController.Index();
        }


        //Crear protesis

        [HttpGet]

        public IActionResult CreateProsthesis()
        {
            ViewData["SocketId"] = new SelectList(_context.Sockets, "Id", "Description");
            ViewData["LinerId"] = new SelectList(_context.Liners, "Id", "Name");
            ViewData["TubeId"] = new SelectList(_context.Tubes, "Id", "Name");
            ViewData["KneeArticulatedId"] = new SelectList(_context.KneeArticulates, "Id", "Name");
            ViewData["FootId"] = new SelectList(_context.Feet, "Id", "Name");
            ViewData["UnionSocketId"] = new SelectList(_context.UnionSockets, "Id", "Name");
            ViewData["KneeArticulateId"] = new SelectList(_context.KneeArticulates, "Id", "Name");
            ViewData["Upper"] = new SelectList(_context.KneeArticulates, "Id", "Name");
            ViewData["KneeArticulateId"] = new SelectList(_context.KneeArticulates, "Id", "Name");
            ViewData["UpperLimbAmputationsiD"] = new SelectList(_context.UpperLimbAmputations, "Id", "AmputationName");
            ViewData["LowerLimbAmputationsiD"] = new SelectList(_context.LowerLimbAmputations, "Id", "AmputationName");




            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateProsthesis([Bind("Id,SocketId,LinerId,TubeId,FootId,UnionSocketId,KneeArticulateId,UpperLimbAmputationsiD,LowerLimbAmputationsiD,Durability,AverageDurability")] ProsthesisVM prosthesis)
        {
            if (ModelState.IsValid)
            {
                var userProsthesis = new Prosthesis
                {
                    SocketId = prosthesis.SocketId,
                    LinerId = prosthesis.LinerId,
                    TubeId = prosthesis.TubeId,
                    FootId = prosthesis.FootId,
                    UnionSocketId = prosthesis.UnionSocketId,
                    KneeArticulateId = prosthesis.KneeArticulateId,
                    UpperLimbAmputationsiD = prosthesis.UpperLimbAmputationsiD,
                    LowerLimbAmputationsiD = prosthesis.LowerLimbAmputationsiD
                };

                userProsthesis.Durability = CalculateDurability(userProsthesis);
                userProsthesis.AverageDurability = CalculateAverageDurability(userProsthesis);

                _context.Prostheses.Add(userProsthesis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            else
            {
                ViewData["SocketId"] = new SelectList(_context.Sockets, "Id", "Description");
                ViewData["LinerId"] = new SelectList(_context.Liners, "Id", "Name");
                ViewData["TubeId"] = new SelectList(_context.Tubes, "Id", "Name");
                ViewData["KneeArticulatedId"] = new SelectList(_context.KneeArticulates, "Id", "Name");
                ViewData["FootId"] = new SelectList(_context.Feet, "Id", "Name");
                ViewData["UnionSocketId"] = new SelectList(_context.UnionSockets, "Id", "Name");
                ViewData["KneeArticulateId"] = new SelectList(_context.KneeArticulates, "Id", "Name");
                ViewData["Upper"] = new SelectList(_context.KneeArticulates, "Id", "Name");
                ViewData["KneeArticulateId"] = new SelectList(_context.KneeArticulates, "Id", "Name");
                ViewData["UpperLimbAmputationsiD"] = new SelectList(_context.UpperLimbAmputations, "Id", "AmputationName");
                ViewData["LowerLimbAmputationsiD"] = new SelectList(_context.LowerLimbAmputations, "Id", "AmputationName");

                return View(prosthesis);
            }

        }


        [HttpGet]
        public async Task<IActionResult> EditProsthesis(int id)
        {
            var prosthesis = await _context.Prostheses
                                .Include(p => p.Socket)
                                .Include(p => p.Liner)
                                .Include(p => p.Tube)
                                .Include(p => p.Foot)
                                .Include(p => p.UnionSocket)
                                .Include(p => p.RodillaArticulada)
                                .Include(p => p.UpperLimbAmputations)
                                .Include(p => p.LowerLimbAmputations)
                                .FirstOrDefaultAsync(p => p.Id == id);

            if (prosthesis == null)
            {
                return NotFound();
            }

            var viewModel = new ProsthesisVM
            {
                Id = prosthesis.Id,
                SocketId = prosthesis.SocketId,
                LinerId = prosthesis.LinerId,
                TubeId = prosthesis.TubeId,
                FootId = prosthesis.FootId,
                UnionSocketId = prosthesis.UnionSocketId,
                KneeArticulateId = prosthesis.KneeArticulateId,
                UpperLimbAmputationsiD = prosthesis.UpperLimbAmputationsiD,
                LowerLimbAmputationsiD = prosthesis.LowerLimbAmputationsiD,
                Durability = prosthesis.Durability,
                AverageDurability = prosthesis.AverageDurability
            };

            ViewData["SocketId"] = new SelectList(_context.Sockets, "Id", "Description", prosthesis.SocketId);
            ViewData["LinerId"] = new SelectList(_context.Liners, "Id", "Name", prosthesis.LinerId);
            ViewData["TubeId"] = new SelectList(_context.Tubes, "Id", "Name", prosthesis.TubeId);
            ViewData["FootId"] = new SelectList(_context.Feet, "Id", "Name", prosthesis.FootId);
            ViewData["UnionSocketId"] = new SelectList(_context.UnionSockets, "Id", "Name", prosthesis.UnionSocketId);
            ViewData["KneeArticulateId"] = new SelectList(_context.KneeArticulates, "Id", "Name", prosthesis.KneeArticulateId);
            ViewData["UpperLimbAmputationsiD"] = new SelectList(_context.UpperLimbAmputations, "Id", "AmputationName", prosthesis.UpperLimbAmputationsiD);
            ViewData["LowerLimbAmputationsiD"] = new SelectList(_context.LowerLimbAmputations, "Id", "AmputationName", prosthesis.LowerLimbAmputationsiD);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProsthesis(int id, [Bind("Id,SocketId,LinerId,TubeId,FootId,UnionSocketId,KneeArticulateId,UpperLimbAmputationsiD,LowerLimbAmputationsiD,Durability,AverageDurability")] ProsthesisVM prosthesis)
        {
            if (id != prosthesis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingProsthesis = await _context.Prostheses.FindAsync(prosthesis.Id);

                    if (existingProsthesis == null)
                    {
                        return NotFound();
                    }

                    existingProsthesis.SocketId = prosthesis.SocketId;
                    existingProsthesis.LinerId = prosthesis.LinerId;
                    existingProsthesis.TubeId = prosthesis.TubeId;
                    existingProsthesis.FootId = prosthesis.FootId;
                    existingProsthesis.UnionSocketId = prosthesis.UnionSocketId;
                    existingProsthesis.KneeArticulateId = prosthesis.KneeArticulateId;
                    existingProsthesis.UpperLimbAmputationsiD = prosthesis.UpperLimbAmputationsiD;
                    existingProsthesis.LowerLimbAmputationsiD = prosthesis.LowerLimbAmputationsiD;
                    existingProsthesis.Durability = CalculateDurability(existingProsthesis);
                    existingProsthesis.AverageDurability = CalculateAverageDurability(existingProsthesis);

                    _context.Prostheses.Update(existingProsthesis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProsthesisExists(prosthesis.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["SocketId"] = new SelectList(_context.Sockets, "Id", "Description", prosthesis.SocketId);
            ViewData["LinerId"] = new SelectList(_context.Liners, "Id", "Name", prosthesis.LinerId);
            ViewData["TubeId"] = new SelectList(_context.Tubes, "Id", "Name", prosthesis.TubeId);
            ViewData["FootId"] = new SelectList(_context.Feet, "Id", "Name", prosthesis.FootId);
            ViewData["UnionSocketId"] = new SelectList(_context.UnionSockets, "Id", "Name", prosthesis.UnionSocketId);
            ViewData["KneeArticulateId"] = new SelectList(_context.KneeArticulates, "Id", "Name", prosthesis.KneeArticulateId);
            ViewData["UpperLimbAmputationsiD"] = new SelectList(_context.UpperLimbAmputations, "Id", "AmputationName", prosthesis.UpperLimbAmputationsiD);
            ViewData["LowerLimbAmputationsiD"] = new SelectList(_context.LowerLimbAmputations, "Id", "AmputationName", prosthesis.LowerLimbAmputationsiD);

            return View(prosthesis);
        }

        private bool ProsthesisExists(int id)
        {
            return _context.Prostheses.Any(e => e.Id == id);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteProsthesis(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prosthesis = await _context.Prostheses
                .Include(p => p.Socket)
                .Include(p => p.Liner)
                .Include(p => p.Tube)
                .Include(p => p.Foot)
                .Include(p => p.UnionSocket)
                .Include(p => p.RodillaArticulada)
                .Include(p => p.UpperLimbAmputations)
                .Include(p => p.LowerLimbAmputations)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (prosthesis == null)
            {
                return NotFound();
            }

            return View(prosthesis);
        }

        // Método POST para confirmar la eliminación
        [HttpPost, ActionName("DeleteProsthesis")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prosthesis = await _context.Prostheses.FindAsync(id);
            if (prosthesis != null)
            {
                _context.Prostheses.Remove(prosthesis);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public JsonResult GetAllMaterials()
        {
            var sockets = _context.Sockets.ToList();
            var liners = _context.Liners.ToList();
            var tubes = _context.Tubes.ToList();
            var knees = _context.KneeArticulates.ToList();
            var feet = _context.Feet.ToList();
            var unionSockets = _context.UnionSockets.ToList();
            var upperLimbAmputations = _context.UpperLimbAmputations.ToList();
            var lowerLimbAmputations = _context.LowerLimbAmputations.ToList();

            return Json(new
            {
                sockets,
                liners,
                tubes,
                knees,
                feet,
                unionSockets,
                upperLimbAmputations,
                lowerLimbAmputations
            });
        }



        public double CalculateDurability(Prosthesis prosthesis)
        {
            double totalDurability = 0;

            // Verifica cada componente y añade su durabilidad si existe
            totalDurability += _context.Sockets
                .Where(s => s.Id == prosthesis.SocketId)
                .Select(s => (double?)s.Durability)
                .FirstOrDefault() ?? 0;

            totalDurability += _context.Liners
                .Where(l => l.Id == prosthesis.LinerId)
                .Select(l => (double?)l.Durability)
                .FirstOrDefault() ?? 0;

            totalDurability += _context.Tubes
                .Where(t => t.Id == prosthesis.TubeId)
                .Select(t => (double?)t.Durability)
                .FirstOrDefault() ?? 0;

            totalDurability += _context.Feet
                .Where(f => f.Id == prosthesis.FootId)
                .Select(f => (double?)f.Durability)
                .FirstOrDefault() ?? 0;

            totalDurability += _context.UnionSockets
                .Where(u => u.Id == prosthesis.UnionSocketId)
                .Select(u => (double?)u.Durability)
                .FirstOrDefault() ?? 0;

            totalDurability += _context.KneeArticulates
                .Where(k => k.Id == prosthesis.KneeArticulateId)
                .Select(k => (double?)k.Durability)
                .FirstOrDefault() ?? 0;

            return totalDurability;
        }

        public double CalculateAverageDurability(Prosthesis prosthesis)
        {
            var componentCount = 0;
            double totalDurability = 0;

            void AddDurability(double? durability)
            {
                if (durability.HasValue)
                {
                    totalDurability += durability.Value;
                    componentCount++;
                }
            }

            AddDurability(_context.Sockets
                .Where(s => s.Id == prosthesis.SocketId)
                .Select(s => (double?)s.Durability)
                .FirstOrDefault());

            AddDurability(_context.Liners
                .Where(l => l.Id == prosthesis.LinerId)
                .Select(l => (double?)l.Durability)
                .FirstOrDefault());

            AddDurability(_context.Tubes
                .Where(t => t.Id == prosthesis.TubeId)
                .Select(t => (double?)t.Durability)
                .FirstOrDefault());

            AddDurability(_context.Feet
                .Where(f => f.Id == prosthesis.FootId)
                .Select(f => (double?)f.Durability)
                .FirstOrDefault());

            AddDurability(_context.UnionSockets
                .Where(u => u.Id == prosthesis.UnionSocketId)
                .Select(u => (double?)u.Durability)
                .FirstOrDefault());

            AddDurability(_context.KneeArticulates
                .Where(k => k.Id == prosthesis.KneeArticulateId)
                .Select(k => (double?)k.Durability)
                .FirstOrDefault());

            return componentCount > 0 ? totalDurability / componentCount : 0;
        }



    }

 

}
