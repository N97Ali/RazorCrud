using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.DataBase;
using RazorCrud.Models;

namespace RazorCrud.Pages.Workers
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _db;
        public Worker worker { get; set; }
        public DeleteModel(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet(int id )
        {
            if (id == 0)
                return NotFound();
            else
                worker = _db.Worker.Find(id);
              return Page();

        }
        public IActionResult OnPost(Worker worker)
        {
            var workers  = _db.Worker.FirstOrDefault(u=>u.Id == worker.Id);
            if (workers == null)
                return NotFound();
            else
            {
                _db.Worker.Remove(workers);
                _db.SaveChanges();
                TempData["success"] = "Worder Delete successfully";
                return RedirectToPage("Index");
            }
           
        }

    }
}
