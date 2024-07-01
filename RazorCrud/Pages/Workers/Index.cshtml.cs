using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.DataBase;
using RazorCrud.Models;

namespace RazorCrud.Workers
{
    public class IndexModel : PageModel
    {
        public  readonly AppDbContext _db;
        public List<Worker> Worker { get; set; }
        public IndexModel(AppDbContext db)
        {
                _db = db;
        }
        public void OnGet()
        {
            
           Worker =   _db.Worker.ToList();
              
        }
    }
}
