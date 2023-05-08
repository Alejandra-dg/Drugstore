using Drugstore.API.Date;
using Drugstore.API.Helpers;
using Drugstore.Shared.DTOs;
using Drugstore.Shared.Entities.Medicamento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Drugstore.API.Controllers.Medicamento
{

    [ApiController]
    [Route("/api/medicines")]
    public class MedicinesController : ControllerBase
    {
        private readonly DataContext _context;


        public MedicinesController(DataContext context)
        {
            _context = context;
        }


        //Método GET LIST

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Medicines
                //.Include(x => x.MedicinesCategories)
                .AsQueryable();



            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }


            return Ok(await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync());
        }

        [HttpGet("full")]
        public async Task<ActionResult> GetFull()
        {
            return Ok(await _context.Categories
               // .Include(x => x.MedicinesCategories)
                .ToListAsync());
        }


        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Medicines.AsQueryable();



            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }





        //Método GET con parámetro

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var medicine = await _context.Medicines

            //.include(x => x.medicinescategories)
            .FirstOrDefaultAsync(x => x.Id == id);

            if (medicine is null)
            {
                return NotFound(); //404
            }

            return Ok(medicine);

        }




        // Método POST -- CREAR
        [HttpPost]
        public async Task<ActionResult> Post(Medicine medicine)
        {
            _context.Add(medicine);
            try
            {

                await _context.SaveChangesAsync();
                return Ok(medicine);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un medicamento con el mismo nombre.");
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





        //Método PUT --- UPDATE

        [HttpPut]
        public async Task<ActionResult> Put(Medicine medicine)
        {

            try
            {

                _context.Update(medicine);
                await _context.SaveChangesAsync();


                return Ok(medicine);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un medicamento con el mismo nombre.");
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



        // Método DELETE-- Eliminar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Medicines
                .Where(a => a.Id == id)

                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
