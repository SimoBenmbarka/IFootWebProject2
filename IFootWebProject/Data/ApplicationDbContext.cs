using IFootWebProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IFootWebProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<IFootWebProject.Models.utilisateur> utilisateur { get; set; } = default!;

        public DbSet<IFootWebProject.Models.Evenement> Evenement { get; set; } = default!;

        public DbSet<IFootWebProject.Models.Terrain> Terrain { get; set; } = default!;
    }
}