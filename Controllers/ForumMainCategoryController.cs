using ForumAPI.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumMainCategoryController : ControllerBase
    {
        private readonly IForumMainCategoryManager _forumMainCategoryManager;
        public ForumMainCategoryController(IForumMainCategoryManager forumMainCategoryManager)
        {
            _forumMainCategoryManager = forumMainCategoryManager;
        }

        [HttpGet]
        public async Task<IEnumerable<Models.ForumMainCategory>> GetAllForumMainCategories()
        {
            var mainCategories = await _forumMainCategoryManager.GetAllForumMainCategories();
            return mainCategories;
        }

        [HttpGet("{id}")]
        public async Task<Models.ForumMainCategory> GetOneForumMainCategory(int id)
        {
            var mainCategory = await _forumMainCategoryManager.GetOneForumMainCategory(id);

            return mainCategory;
        }

        [HttpPost]
        public async Task Post([FromBody] Models.ForumMainCategory forumMainCategory)
        {
            await _forumMainCategoryManager.CreateForumMainCategory(forumMainCategory);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Models.ForumMainCategory forumMainCategory)
        {
            await _forumMainCategoryManager.UpdateForumMainCategory(forumMainCategory, id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _forumMainCategoryManager.DeleteForumMainCategory(id);
        }
    }
}
