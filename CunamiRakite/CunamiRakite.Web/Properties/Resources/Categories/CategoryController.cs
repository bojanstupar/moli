using CunamiRakite.Core.Entities;
using CunamiRakite.Core.Repository;
using CunamiRakite.Core.Services;
using CunamiRakite.Web.Properties.Resources.Categories.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CunamiRakite.Web.Properties.Resources.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryRepository categoryRepository;
        private readonly CategoryService categoryService;
        private readonly CategoryFactory categoryFactory;


        public CategoryController(ICategoryRepository categoryRepository, CategoryService categoryService, CategoryFactory categoryFactory) {

            this.categoryRepository = categoryRepository;
            this.categoryService = categoryService;
            this.categoryFactory = categoryFactory;
        }

       


        [HttpGet("{id}")]
        public IActionResult GetOne(Guid id) {

            var maybeClient = categoryRepository.FindById(id);
            if (maybeClient.HasNoValue) return NotFound();

            return Ok(maybeClient.Value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) {

            var maybeCat = categoryRepository.FindById(id);
            if (maybeCat.HasNoValue) return NotFound();

            categoryRepository.Remove(id);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Save(CategoryDto dto) {

            var createCategory = CategoryFactory.Create(dto);
                if (createCategory.IsFailure) return BadRequest(createCategory.Error);

            categoryService.Save(createCategory.Value);

            return Created("api/category/{createCategory.Value.Id}", string.Empty);
        }
    }
}
