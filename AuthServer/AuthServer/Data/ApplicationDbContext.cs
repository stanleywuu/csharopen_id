using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<UserData> UserDatas { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<UserData>()
            .Property(u => u.UserJSON)
            .HasColumnType("JSON");
        
        builder.Entity<Event>()
            .Property(e => e.EventJSON)
            .HasColumnType("JSON");
    }
}