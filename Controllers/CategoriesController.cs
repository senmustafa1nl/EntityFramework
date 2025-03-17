using Microsoft.AspNetCore.Mvc;
using Pratik_Survivor_Dependency_Injection.Context;
using Pratik_Survivor_Dependency_Injection.Entities;
using Pratik_Survivor_Dependency_Injection.Models.Category;

namespace Pratik_Survivor_Dependency_Injection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
       

    private readonly SurvivorDbContext _db;
    public CategoriesController(SurvivorDbContext db)
    {
        _db = db;
    }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categoryList = _db.Categories.Where(X => X.IsDeleted == false).Select(x => new CategoryList
            {
               
                Name = x.Name,
               
            }).ToList();
            return Ok(categoryList);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {
            var getById = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (getById == null)
            {
                return NotFound();
            }
            var response = new CategoryList
            {
                Id = id,
                Name = getById.Name,
            };
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Add(CategoryAdd request)
        {
            var newCategory = new CategoryEntity
            {
                Name = request.Name,
                
            };
            _db.Categories.Add(newCategory);
            _db.SaveChanges();
            return Created();
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int id, CategoryUpdate request)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            category.Name = request.Name;
            category.ModifiedDate = DateTime.Now;
            _db.Categories.Update(category);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            category.IsDeleted = true;
            category.ModifiedDate = DateTime.Now;
            _db.Categories.Update(category);
            _db.SaveChanges();
            return NoContent();
        }


    }

}
