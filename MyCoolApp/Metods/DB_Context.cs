using Microsoft.EntityFrameworkCore;


namespace MyCoolApp.Metods
{
    public class DB_Context : DbContext
    {

        public DB_Context(DbContextOptions<DB_Context> options) : base(options) { }
        public DbSet<History> history { get; set; }
        public DbSet<sys_logs> sys_logs { get; set; }

    }
}
