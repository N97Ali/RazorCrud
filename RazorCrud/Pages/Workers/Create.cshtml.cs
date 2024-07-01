using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.DataBase;
using RazorCrud.Models;

namespace RazorCrud.Pages.Workers
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;
        public Worker worker { get; set; }
        public CreateModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost(Worker worker)
        {
            _db.Worker.Add(worker);
            _db.SaveChanges();
            TempData["success"] = "Worder add successfully";
          return  RedirectToPage("Index");
        }

    }
}
