using Microsoft.EntityFrameworkCore;
using preresback.Domain.Models;

namespace preresback.Persistence.Context
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
