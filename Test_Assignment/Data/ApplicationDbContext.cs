using Microsoft.EntityFrameworkCore;
using Test_Assignment.Model;

namespace Test_Assignment.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
        
        public DbSet<UserModel> UserInfo { get; set; }
    }
}
