using Microsoft.AspNetCore.Mvc;
using Pratik_Survivor_Dependency_Injection.Context;
using Pratik_Survivor_Dependency_Injection.Entities;
using Pratik_Survivor_Dependency_Injection.Models;
using Pratik_Survivor_Dependency_Injection.Models.Category;
using Pratik_Survivor_Dependency_Injection.Models.Competitor;

namespace Pratik_Survivor_Dependency_Injection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompetitorsController : ControllerBase
    {

        private readonly SurvivorDbContext _db;
        public CompetitorsController(SurvivorDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var competitorsList = _db.Competitors.Where(x => x.IsDeleted == false).Select(x => new CompetitorGetModel
            {
                Id = x.Id,
                FullName = x.FirstName + " " + x.LastName,
                CategoryId = x.CategoryId
            }


            ).ToList();

            return Ok(competitorsList);

        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {
            var getById = _db.Competitors.FirstOrDefault(x => x.Id == id);
            if (getById == null || getById.IsDeleted == true)
            {
                return NotFound();
            }
            var response = new CompetitorDetails
            {
                Id = getById.Id,
                FullName = getById.FirstName + " " + getById.LastName,
                CategoryId = getById.CategoryId,
                ModifiedDate = getById.ModifiedDate,
                CreatedDate = getById.CreatedDate,


            };
            return Ok(response);
        }



        [HttpGet("categories/{categoryId}")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var getByCategoryId = _db.Competitors.Where(x => !x.IsDeleted && x.CategoryId == categoryId).Select(x => new CompetitorGetModel
            {
                Id = x.Id,
                FullName = x.FirstName + "" + x.LastName,
                CategoryId = x.CategoryId
            }).ToList();

            return Ok(getByCategoryId);
        }


        [HttpPost]
        public IActionResult Add(CompetitorAdd request)
        {
            var newCompetitor = new CompetitorsEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                CategoryId = request.CategoryId
            };
            _db.Competitors.Add(newCompetitor);
            _db.SaveChanges();
            return Created();
        }
        [HttpPut("{Id}")]
        public IActionResult Update(int id, CompetitorUpdate request)
        {
            var competitor = _db.Competitors.FirstOrDefault(x => x.Id == id);
            if (competitor == null || competitor.IsDeleted == true)
            {
                return NotFound();
            }
            competitor.FirstName = request.FirstName;
            competitor.LastName = request.LastName;
            competitor.CategoryId = request.CategoryId;
            competitor.ModifiedDate = DateTime.Now;
            _db.Competitors.Update(competitor);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            var competitor = _db.Competitors.FirstOrDefault(x => x.Id == id);
            if (competitor == null || competitor.IsDeleted == true)
            {
                return NotFound();
            }
            competitor.IsDeleted = true;
            _db.SaveChanges();
            return NoContent();
        }


    }
}


