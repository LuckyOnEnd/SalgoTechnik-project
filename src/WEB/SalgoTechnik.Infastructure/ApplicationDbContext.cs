using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalgoTechnik.Domain.Entities;

namespace SalgoTechnik.Infastructure
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        { 
        
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Reference> References { get; set; }
    }
}