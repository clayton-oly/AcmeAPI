using AcmeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcmeAPI.Data
{
    public class AcmeDbContext : DbContext
    {
        public AcmeDbContext(DbContextOptions<AcmeDbContext> options):base(options) { }

        //Models
        public DbSet<Cliente> Clientes { get; set; }

    }
}
