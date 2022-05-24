using Microsoft.EntityFrameworkCore;

namespace Playground.Infrastructure.Database.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }
    }
}
