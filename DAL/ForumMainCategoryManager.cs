using ForumAPI.Data;
using ForumAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace ForumAPI.DAL
{
    public class ForumMainCategoryManager: IForumMainCategoryManager
    {
        private readonly ApDbContext _context;
        public ForumMainCategoryManager(ApDbContext context)
        {
            _context = context;
        }

        public async Task CreateForumMainCategory(ForumMainCategory forumMainCategory)
        {
            var newForumMainCategory = new ForumMainCategory
            {
                Name = forumMainCategory.Name,
                Date = DateTime.Now,
            };
            await _context.ForumMainCategory.AddAsync(newForumMainCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteForumMainCategory(int id)
        {
            var deleteForumMainCategory = await _context.ForumMainCategory.Where(f => f.Id == id).FirstOrDefaultAsync();
            _context.ForumMainCategory.Remove(deleteForumMainCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ForumMainCategory>> GetAllForumMainCategories()
        {
            return await _context.ForumMainCategory.ToListAsync();
        }

        public async Task<ForumMainCategory> GetOneForumMainCategory(int id)
        {
            var existingForumMainCategory = _context.ForumMainCategory.Where(p => p.Id == id).SingleOrDefault();

            if (existingForumMainCategory != null)
            {
                return existingForumMainCategory;
            }
            else
            {
                return null;
            }
        }

        public async Task UpdateForumMainCategory(ForumMainCategory forumMainCategory, int id)
        {
            var existingForumMainCategory = await _context.ForumMainCategory.FirstOrDefaultAsync(p => p.Id == id);
            if (existingForumMainCategory != null)
            {
                existingForumMainCategory.Name = forumMainCategory.Name;

                var validationContext = new ValidationContext(existingForumMainCategory, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(existingForumMainCategory, validationContext, validationResults, validateAllProperties: true);

                if (!isValid)
                {
                    string validationErrors = string.Join(", ", validationResults.Select(v => v.ErrorMessage));
                    Console.WriteLine($"Validation errors: {validationErrors}");
                }
                else
                {
                    await _context.SaveChangesAsync();
                }
            }
        }

    }
}
