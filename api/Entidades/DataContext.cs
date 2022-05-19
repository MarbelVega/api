using Microsoft.EntityFrameworkCore;
namespace api.Entidades
{
    public class DataContext:DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Visita> visita { get; set; }
    }
}
