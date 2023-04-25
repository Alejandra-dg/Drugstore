using Drugstore.API.Date;
using Drugstore.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Drugstore.API.Controllers
{
    [ApiController]
    [Route("/api/medicalorder")]
    public class MedicalOrdersController : ControllerBase
    {
        private readonly DataContext _context;

        public MedicalOrdersController(DataContext context)
        {
            _context = context;
        }

        //Método GET LIST
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.MedicalOrders.ToListAsync());
        }

        //Método GET con parámetro

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var medicalOrder = await _context.MedicalOrders.FirstOrDefaultAsync(x => x.order_id == id);
            if (medicalOrder is null)
            {
                return NotFound(); //404
            }

            return Ok(medicalOrder);

        }


        //Método POST -- CREAR
        [HttpPost]
        public async Task<ActionResult> Post(MedicalOrder medicalorder)
        {
            _context.Add(medicalorder);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(medicalorder);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una orden médica igual.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

    }
}
