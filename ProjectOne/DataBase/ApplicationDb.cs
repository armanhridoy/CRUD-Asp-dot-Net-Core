using Microsoft.EntityFrameworkCore;
using ProjectOne.Models;

namespace ProjectOne.DataBase;

public class ApplicationDb : DbContext
{
    public ApplicationDb(DbContextOptions<ApplicationDb> dbContext) : base(dbContext)
    {
        
    }
    public DbSet<Teacher>teachers { get; set; }

    public DbSet<Student> students { get; set; }
}
