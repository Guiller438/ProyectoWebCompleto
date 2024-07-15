using IW7PP.Data;
using IW7PP.Models.Cliente;
using IW7PP.Models.Donations;
using IW7PP.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IW7PP.Controllers.Donations
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("clientsWithDonations")]
        public async Task<IActionResult> GetClientsWithDonations()
        {
            var clients = await _context.ClientesProtesicos.ToListAsync();
            var clientDonationInfo = clients.Select(client => new
            {
                client.Id,
                client.Name,
                client.LastName,
                client.DonationGoal,
                client.DonationStatus
            });

            return Ok(clientDonationInfo);
        }




        [HttpGet("clients")]
        public async Task<IActionResult> GetClients()
        {
            List<ClientesProtesicos> clients = await _context.ClientesProtesicos.ToListAsync();
            return Ok(clients);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DonationsVM donationRequestVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _context.ClientesProtesicos.FindAsync(donationRequestVM.ClientId);
            if (client == null)
            {
                return NotFound(new { message = "Cliente no encontrado" });
            }

            var donationRequest = new DonationRequests
            {
                Amount = donationRequestVM.Amount,
                Email = donationRequestVM.Email,
                Name = donationRequestVM.Name,
                Surname = donationRequestVM.Surname,
                Phone = donationRequestVM.Phone,
                ClientId = donationRequestVM.ClientId
            };

            _context.Donaciones.Add(donationRequest);
            client.DonationStatus += donationRequest.Amount;
            _context.ClientesProtesicos.Update(client);

            await _context.SaveChangesAsync();

            var simulatedResponse = new
            {
                Success = true,
                Message = "Donación procesada exitosamente (simulada)",
                DonationId = donationRequest.Id,
                UpdatedClient = client
            };

            return Ok(simulatedResponse);
        }

        [HttpPost("setDonationGoals")]
        public async Task<IActionResult> SetDonationGoals([FromBody] List<ClientesProtesicos> donationGoals)
        {
            foreach (var goal in donationGoals)
            {
                var client = await _context.ClientesProtesicos.FindAsync(goal.Id);
                if (client != null)
                {
                    client.DonationGoal = goal.DonationGoal;
                
                }
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Metas de donaciones actualizadas correctamente." });
        }
    }

    
}
