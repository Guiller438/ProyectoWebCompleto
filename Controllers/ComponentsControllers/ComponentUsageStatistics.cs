using IW7PP.Data;
using IW7PP.Models.ProsthesisM;
using IW7PP.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IW7PP.Controllers.ComponentsControllers
{
    public class ComponentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComponentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ComponentUsage()
        {
            var componentUsageStats = new List<ComponentUsageStatistics>();

            // Obtener todos los componentes necesarios de la base de datos
            var sockets = await _context.Sockets.ToListAsync();
            var liners = await _context.Liners.ToListAsync();
            var tubes = await _context.Tubes.ToListAsync();
            var unionSockets = await _context.UnionSockets.ToListAsync();
            var kneeArticulates = await _context.KneeArticulates.ToListAsync();
            var feet = await _context.Feet.ToListAsync();

            // Contar el uso de sockets
            var socketUsage = await _context.Prostheses
                .GroupBy(p => new { p.SocketId, AmputationType = p.UpperLimbAmputationsiD.HasValue ? "Upper Limb" : "Lower Limb" })
                .Select(g => new
                {
                    ComponentId = g.Key.SocketId,
                    ComponentType = "Socket",
                    AmputationType = g.Key.AmputationType,
                    UsageCount = g.Count(),
                    AverageDurability = g.Average(p => p.AverageDurability) / 12 // Convertir de meses a años
                })
                .ToListAsync();

            componentUsageStats.AddRange(socketUsage.Select(u => new ComponentUsageStatistics
            {
                ComponentType = u.ComponentType,
                ComponentName = sockets.FirstOrDefault(s => s.Id == u.ComponentId)?.Description ?? "Unknown",
                AmputationType = u.AmputationType,
                UsageCount = u.UsageCount,
                AverageDurability = u.AverageDurability
            }));

            // Contar el uso de liners
            var linerUsage = await _context.Prostheses
                .GroupBy(p => new { p.LinerId, AmputationType = p.UpperLimbAmputationsiD.HasValue ? "Upper Limb" : "Lower Limb" })
                .Select(g => new
                {
                    ComponentId = g.Key.LinerId,
                    ComponentType = "Liner",
                    AmputationType = g.Key.AmputationType,
                    UsageCount = g.Count(),
                    AverageDurability = g.Average(p => p.AverageDurability) / 12 // Convertir de meses a años
                })
                .ToListAsync();

            componentUsageStats.AddRange(linerUsage.Select(u => new ComponentUsageStatistics
            {
                ComponentType = u.ComponentType,
                ComponentName = liners.FirstOrDefault(l => l.Id == u.ComponentId)?.Name ?? "Unknown",
                AmputationType = u.AmputationType,
                UsageCount = u.UsageCount,
                AverageDurability = u.AverageDurability
            }));

            // Contar el uso de tubes
            var tubeUsage = await _context.Prostheses
                .GroupBy(p => new { p.TubeId, AmputationType = p.UpperLimbAmputationsiD.HasValue ? "Upper Limb" : "Lower Limb" })
                .Select(g => new
                {
                    ComponentId = g.Key.TubeId,
                    ComponentType = "Tube",
                    AmputationType = g.Key.AmputationType,
                    UsageCount = g.Count(),
                    AverageDurability = g.Average(p => p.AverageDurability) / 12 // Convertir de meses a años
                })
                .ToListAsync();

            componentUsageStats.AddRange(tubeUsage.Select(u => new ComponentUsageStatistics
            {
                ComponentType = u.ComponentType,
                ComponentName = tubes.FirstOrDefault(t => t.Id == u.ComponentId)?.Description ?? "Unknown",
                AmputationType = u.AmputationType,
                UsageCount = u.UsageCount,
                AverageDurability = u.AverageDurability
            }));

            // Contar el uso de union sockets
            var unionSocketUsage = await _context.Prostheses
                .GroupBy(p => new { p.UnionSocketId, AmputationType = p.UpperLimbAmputationsiD.HasValue ? "Upper Limb" : "Lower Limb" })
                .Select(g => new
                {
                    ComponentId = g.Key.UnionSocketId,
                    ComponentType = "Union Socket",
                    AmputationType = g.Key.AmputationType,
                    UsageCount = g.Count(),
                    AverageDurability = g.Average(p => p.AverageDurability) / 12 // Convertir de meses a años
                })
                .ToListAsync();

            componentUsageStats.AddRange(unionSocketUsage.Select(u => new ComponentUsageStatistics
            {
                ComponentType = u.ComponentType,
                ComponentName = unionSockets.FirstOrDefault(u => u.Id == u.Id)?.Description ?? "Unknown",
                AmputationType = u.AmputationType,
                UsageCount = u.UsageCount,
                AverageDurability = u.AverageDurability
            }));

            // Contar el uso de knee articulates
            var kneeArticulateUsage = await _context.Prostheses
                .GroupBy(p => new { p.KneeArticulateId, AmputationType = p.UpperLimbAmputationsiD.HasValue ? "Upper Limb" : "Lower Limb" })
                .Select(g => new
                {
                    ComponentId = g.Key.KneeArticulateId,
                    ComponentType = "Knee Articulate",
                    AmputationType = g.Key.AmputationType,
                    UsageCount = g.Count(),
                    AverageDurability = g.Average(p => p.AverageDurability) / 12 // Convertir de meses a años
                })
                .ToListAsync();

            componentUsageStats.AddRange(kneeArticulateUsage.Select(u => new ComponentUsageStatistics
            {
                ComponentType = u.ComponentType,
                ComponentName = kneeArticulates.FirstOrDefault(k => k.Id == u.ComponentId)?.Description ?? "Unknown",
                AmputationType = u.AmputationType,
                UsageCount = u.UsageCount,
                AverageDurability = u.AverageDurability
            }));

            // Contar el uso de feet
            var footUsage = await _context.Prostheses
                .GroupBy(p => new { p.FootId, AmputationType = p.UpperLimbAmputationsiD.HasValue ? "Upper Limb" : "Lower Limb" })
                .Select(g => new
                {
                    ComponentId = g.Key.FootId,
                    ComponentType = "Foot",
                    AmputationType = g.Key.AmputationType,
                    UsageCount = g.Count(),
                    AverageDurability = g.Average(p => p.AverageDurability) / 12 // Convertir de meses a años
                })
                .ToListAsync();

            componentUsageStats.AddRange(footUsage.Select(u => new ComponentUsageStatistics
            {
                ComponentType = u.ComponentType,
                ComponentName = feet.FirstOrDefault(f => f.Id == u.ComponentId)?.Description ?? "Unknown",
                AmputationType = u.AmputationType,
                UsageCount = u.UsageCount,
                AverageDurability = u.AverageDurability
            }));

            // Serializar los datos a JSON y pasarlos a la vista
            ViewBag.ComponentUsageStatsJson = JsonConvert.SerializeObject(componentUsageStats);

            return View(componentUsageStats);
        }
        [HttpGet]
        public IActionResult FilterProsthesis()
        {
            var model = new ProsthesisFilterVM
            {
                StartDate = DateTime.Now.AddMonths(-1), // Default to last month
                EndDate = DateTime.Now
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> FilterProsthesis(ProsthesisFilterVM model)
        {
            var prostheses = await _context.Prostheses
                .Where(p => p.FechaRegistro >= model.StartDate && p.FechaRegistro <= model.EndDate)
                .Include(p => p.Socket)
                .Include(p => p.Liner)
                .Include(p => p.Tube)
                .Include(p => p.Foot)
                .Include(p => p.UnionSocket)
                .Include(p => p.RodillaArticulada)
                .Include(p => p.UpperLimbAmputations)
                .Include(p => p.LowerLimbAmputations)
                .OrderByDescending(p => p.AverageDurability)
                .ToListAsync();

            var upperProstheses = prostheses.Where(p => p.UpperLimbAmputationsiD != null).Select(p => new ProsthesisVM
            {
                Id = p.Id,
                SocketId = p.SocketId,
                LinerId = p.LinerId,
                TubeId = p.TubeId,
                FootId = p.FootId,
                UnionSocketId = p.UnionSocketId,
                KneeArticulateId = p.KneeArticulateId,
                UpperLimbAmputationsiD = p.UpperLimbAmputationsiD,
                LowerLimbAmputationsiD = p.LowerLimbAmputationsiD,
                Durability = p.Durability,
                AverageDurability = p.AverageDurability,
                FechaRegistro = p.FechaRegistro
            }).ToList();

            var lowerProstheses = prostheses.Where(p => p.LowerLimbAmputationsiD != null).Select(p => new ProsthesisVM
            {
                Id = p.Id,
                SocketId = p.SocketId,
                LinerId = p.LinerId,
                TubeId = p.TubeId,
                FootId = p.FootId,
                UnionSocketId = p.UnionSocketId,
                KneeArticulateId = p.KneeArticulateId,
                UpperLimbAmputationsiD = p.UpperLimbAmputationsiD,
                LowerLimbAmputationsiD = p.LowerLimbAmputationsiD,
                Durability = p.Durability,
                AverageDurability = p.AverageDurability,
                FechaRegistro = p.FechaRegistro
            }).ToList();

            foreach (var prosthesis in upperProstheses.Concat(lowerProstheses))
            {
                ViewData["SocketName_" + prosthesis.SocketId] = _context.Sockets.FirstOrDefault(s => s.Id == prosthesis.SocketId)?.Description;
                ViewData["LinerName_" + prosthesis.LinerId] = _context.Liners.FirstOrDefault(l => l.Id == prosthesis.LinerId)?.Name;
                ViewData["TubeName_" + prosthesis.TubeId] = _context.Tubes.FirstOrDefault(t => t.Id == prosthesis.TubeId)?.Name;
                ViewData["FootName_" + prosthesis.FootId] = _context.Feet.FirstOrDefault(f => f.Id == prosthesis.FootId)?.Name;
                ViewData["UnionSocketName_" + prosthesis.UnionSocketId] = _context.UnionSockets.FirstOrDefault(u => u.Id == prosthesis.UnionSocketId)?.Name;
                ViewData["KneeArticulateName_" + prosthesis.KneeArticulateId] = _context.KneeArticulates.FirstOrDefault(k => k.Id == prosthesis.KneeArticulateId)?.Name;
            }

            model.UpperProstheses = upperProstheses;
            model.LowerProstheses = lowerProstheses;

            return View(model);
        }

    }
}
