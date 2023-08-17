using _3_Code_First_Console_Application;
using System.Data.Entity;

public class StudentDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
}