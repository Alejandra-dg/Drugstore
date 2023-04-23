using Drugstore.API.Date;
using Drugstore.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drugstore.API.Controllers
{
    [ApiController]
    [Route("/api/medicalorder")]
    public class MedicalOrderController : ControllerBase
    {
        private readonly DataContext _context;

        public MedicalOrderController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(MedicalOrder medicalorder)
        {
            _context.Add(medicalorder);
            await _context.SaveChangesAsync();
            return Ok(medicalorder);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.medicalorder.ToListAsync());
        }

    }

}
