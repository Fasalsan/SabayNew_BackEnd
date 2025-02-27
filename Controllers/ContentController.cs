using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabayNew.Models;
using SabayNew.Repository.Content;

namespace SabayNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {

        private readonly IContentRepository _contentRepository;

        public ContentController(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var contentList = await _contentRepository.GetAll();
            return Ok(contentList);
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var contentList = await _contentRepository.GetByName(name);
            return Ok(contentList);
        }


        [HttpPost("Post")]
        public async Task<IActionResult>Save(ContentModel contentModel)
        {
            var contentList = await _contentRepository.Save(contentModel);
            return Ok(contentList);
        }

        [HttpPut("Update")]
        public async Task<IActionResult>Update(ContentModel content , int id)
        {
            var contentList = await _contentRepository.Update(content, id);
            return Ok(contentList);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var content = await _contentRepository.Delete(id);
            return Ok(content);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var catentList = await _contentRepository.GetById(id);
            return Ok(catentList);
        }
    }
}
