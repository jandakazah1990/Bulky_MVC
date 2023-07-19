using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category? Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.FirstOrDefault(u => u.Id == id);
            }
        }
        
        public IActionResult OnPost()
        {
            if (Category == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(Category);
            _db.SaveChanges();
            TempData["success"] = "Category has been deleted successfully";
            return RedirectToPage("Index");
        }
    }
}
