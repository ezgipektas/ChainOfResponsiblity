using Microsoft.EntityFrameworkCore;

namespace ChainOfResponsiblity.DAL
{
    public class Context:DbContext
    {       
          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-FJT4L6QM;initial catalog=DbChainOfRes;integrated security=true");
        }
        public DbSet<ProcessDetail> ProcessDetails { get; set; }


    }
}
