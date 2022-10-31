using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using salmin.Data;
using salmin.Models;

namespace salmin.Pages
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.categories.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            
                var categoryFromDb = _db.categories.Find(Category.Id);
                if (categoryFromDb != null)
                {
                    _db.categories.Remove(categoryFromDb);
                    await _db.SaveChangesAsync();
                TempData["success"] = "Category deleted successfully!";
                return RedirectToPage("Index2");

            }
            

            return Page();
        }
        
    
    }
}
