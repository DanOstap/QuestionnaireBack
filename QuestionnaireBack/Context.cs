using Microsoft.EntityFrameworkCore;
using QuestionnaireBack.Models;

namespace QuestionnaireBack
{
    public class Context : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>().HasKey("Name");
        }
    }
}
