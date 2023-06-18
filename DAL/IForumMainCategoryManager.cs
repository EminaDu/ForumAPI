using ForumAPI.Data;
using ForumAPI.Models;

namespace ForumAPI.DAL
{
    public interface IForumMainCategoryManager
    {
        public Task CreateForumMainCategory(ForumMainCategory forumMainCategory);

        public Task DeleteForumMainCategory(int id);
        public Task<List<ForumMainCategory>> GetAllForumMainCategories();

        public Task<ForumMainCategory> GetOneForumMainCategory(int id);
        public Task UpdateForumMainCategory(ForumMainCategory forumMainCategory, int id);
    }
}
