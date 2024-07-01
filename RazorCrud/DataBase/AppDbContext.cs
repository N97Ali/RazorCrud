using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RazorCrud.Models;

namespace RazorCrud.DataBase
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Worker> Worker { get; set; }

    }
}
