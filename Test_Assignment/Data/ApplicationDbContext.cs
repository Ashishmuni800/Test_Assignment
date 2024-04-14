using Microsoft.EntityFrameworkCore;
using Test_Assignment.Model;

namespace Test_Assignment.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
        
        public DbSet<UserModel> UserInfo { get; set; }
        public DbSet<Country> City { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Disttrict> Disttrict { get; set; }
        public DbSet<UserInfoDetails> UserInfoDetails { get; set; }
    }
}
