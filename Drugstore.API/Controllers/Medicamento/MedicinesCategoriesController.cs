//using Drugstore.API.Date;
//using Drugstore.API.Helpers;
//using Drugstore.Shared.DTOs;
//using Drugstore.Shared.Entities;
//using Drugstore.Shared.Entities.Medicamento;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace Drugstore.API.Controllers.Medicamento
//{
//    [ApiController]
//    [Route("/api/MedicinesCategories")]
//    public class MedicinesCategoriesController : ControllerBase
//    {
//        private readonly DataContext _context;

//        public MedicinesCategoriesController(DataContext context)
//        {
//            _context = context;
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
//        //{
//        //    var queryable = _context.MedicineCategories // RECORRIDO DE PAGINAS DE 1 A 10
//        //        .AsQueryable();


//        //    if (!string.IsNullOrWhiteSpace(pagination.Filter))
//        //    {
//        //        queryable = queryable.Where(x => x.Name.ToLower().Contains
//        //        (pagination.Filter.ToLower()));
//        //    }

//        //    if (!string.IsNullOrWhiteSpace(pagination.MedicineId))
//        //    {
//        //        queryable = queryable.Where(x => x.MedicineId == int.Parse(pagination.MedicineId));
//        //    }

//        //    return Ok(await queryable
//        //        .OrderBy(x => x.Name)
//        //        .Paginate(pagination)
//        //        .ToListAsync());
//        //}



//        //[HttpGet("totalPages")] // Contar numeros de paginas 
//        //public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
//        //{
//        //    var queryable = _context.MedicineCategories.AsQueryable();

//        //    if (!string.IsNullOrWhiteSpace(pagination.Filter))
//        //    {
//        //        queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
//        //    }

//        //    if (!string.IsNullOrWhiteSpace(pagination.MedicineId))
//        //    {
//        //        queryable = queryable.Where(x => x.MedicineId == int.Parse(pagination.MedicineId));
//        //    }

//        //    double count = await queryable.CountAsync();
//        //    double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
//        //    return Ok(totalPages);
//        //}



//        // Get FULL hace 
//        [HttpGet("full")]
//        public async Task<ActionResult> GetFull()
//        {
//            return Ok(await _context.MedicineCategories
//                .ToListAsync());
//        }



//        [HttpGet("{id:int}")]
//        public async Task<IActionResult> GetAsync(int id)
//        {
//            var city = await _context.MedicineCategories
//                .FirstOrDefaultAsync(x => x.Id == id);
//            if (city == null)
//            {
//                return NotFound();
//            }

//            return Ok(city);
//        }

//        [HttpPost]
//        public async Task<ActionResult> PostAsync(MedicineCategory medicineCategory)
//        {
//            try
//            {
//                _context.Add(medicineCategory);
//                await _context.SaveChangesAsync();
//                return Ok(medicineCategory);
//            }
//            catch (DbUpdateException dbUpdateException)
//            {
//                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
//                {
//                    return BadRequest("Ya existe una medicina con el mismo nombre.");
//                }

//                return BadRequest(dbUpdateException.Message);
//            }
//            catch (Exception exception)
//            {
//                return BadRequest(exception.Message);
//            }
//        }

//        [HttpPut]
//        public async Task<ActionResult> PutAsync(MedicineCategory medicineCategory)
//        {
//            try
//            {
//                _context.Update(medicineCategory);
//                await _context.SaveChangesAsync();
//                return Ok(medicineCategory);
//            }
//            catch (DbUpdateException dbUpdateException)
//            {
//                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
//                {
//                    return BadRequest("Ya existe una medicina  con el mismo nombre.");
//                }

//                return BadRequest(dbUpdateException.Message);
//            }
//            catch (Exception exception)
//            {
//                return BadRequest(exception.Message);
//            }
//        }

//        [HttpDelete("{id:int}")]
//        public async Task<IActionResult> DeleteAsync(int id)
//        {
//            var medicineCategory = await _context.MedicineCategories.FirstOrDefaultAsync(x => x.Id == id);
//            if (medicineCategory == null)
//            {
//                return NotFound();
//            }

//            _context.Remove(medicineCategory);
//            await _context.SaveChangesAsync();
//            return NoContent();
//        }
//    }
//}
