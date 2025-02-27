using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabayNew.Models;
using SabayNew.Repository;

namespace SabayNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Save(CategoryModel category)
        {
            var categoryList = await _categoryRepository.Save(category);
            return Ok(categoryList);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var categoryList = await _categoryRepository.GetAll();
            return Ok(categoryList);
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult>GetByName(string name)
        {
            var categoryList = await _categoryRepository.GetByName(name);
            return Ok(categoryList);
        }


        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoryList = await _categoryRepository.GetById(id);
            return Ok(categoryList);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Updatecategory(int id, CategoryModel category)
        {
            var categriesList = await _categoryRepository.Update(id, category);
            return Ok(categriesList);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categryList = await _categoryRepository.Delete(id);
            return Ok(categryList);
        }


    }
}
