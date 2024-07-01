using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.DataBase;
using RazorCrud.Models;

namespace RazorCrud.Pages.Workers
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;
        public Worker worker { get; set; }
        public EditModel(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet(int id)
        {
            if(id == 0)
            {
                return NotFound();  
            }
            else
            {
                worker = _db.Worker.Find(id);
                return Page();
            }
            
          
        }
        public IActionResult OnPost(Worker worker) 
        {
             var workers = _db.Worker.FirstOrDefault(u=>u.Id == worker.Id);
            if (workers == null)
            {
                return NotFound();
            }
            else
            {
                workers.Name = worker.Name;
                workers.PhoneNo = worker.PhoneNo;
                workers.Gender = worker.Gender;
                workers.Address = worker.Address;
                _db.Worker.Update(workers);
                _db.SaveChanges();
                TempData["success"] = "Worder Edit successfully";
                return RedirectToPage("Index");
            }
           
        }
    }
}
