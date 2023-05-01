using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Drugstore.API.Helpers;
using Drugstore.Shared.DTOs;
using Drugstore.Shared.Entities;
using Drugstore.API.Date;
using Drugstore.Shared.Entities.Medicamento;

namespace Drugstore.API.Controllers
{

    [ApiController]
    [Route("/api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;


        public CategoriesController(DataContext context)
        {
            _context = context;
        }


        //Método GET LIST

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Categories
                .Include(x=> x.Medicines)
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
                .ToListAsync());
        }


        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Categories.AsQueryable();



            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }





        //´Método GET con parámetro

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var category = await _context.Categories
            .Include(x=> x.Medicines)
            .Include(x => x.MedicinesCategories)
            .FirstOrDefaultAsync(x => x.Id == id);
            if (category is null)
            {
                return NotFound(); //404
            }

            return Ok(category);

        }




        // Método POST -- CREAR
        [HttpPost]
        public async Task<ActionResult> Post(Category category)
        {
            _context.Add(category);
            try
            {

                await _context.SaveChangesAsync();
                return Ok(category);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una categoría con el mismo nombre.");
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
        public async Task<ActionResult> Put(Category category)
        {

            try
            {

                _context.Update(category);
                await _context.SaveChangesAsync();


                return Ok(category);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una categoría con el mismo nombre.");
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
            var afectedRows = await _context.Categories
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