using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using salmin.Data;
using salmin.Models;

namespace salmin.Pages
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;       
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DispalyOrder.ToString())
            {

                ModelState.AddModelError(string.Empty, "The display order cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                await _db.categories.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created successfully!";
                return RedirectToPage("Index2");
            }
            return Page();
            
        }
    }
}
