using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using salmin.Data;
using salmin.Models;

namespace salmin.Pages
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;       
        }
        public void OnGet(int id)
        {
            Category = _db.categories.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.categories.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated successfully!";
                return RedirectToPage("Index2");
            }
            return Page();
            
        }
    }
}
