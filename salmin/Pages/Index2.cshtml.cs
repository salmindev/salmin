using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using salmin.Data;
using salmin.Models;

namespace salmin.Pages
{
    public class Index2Model : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Category> Categories { get; set; }
        public Index2Model(ApplicationDbContext db)
        {  
            _db = db;
        }
        public void OnGet()
        {
            Categories = _db.categories;
        }
    }
}
