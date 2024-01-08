using IdentityLoginSignUp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityLoginSignUp.Models;

namespace IdentityLoginSignUp.Areas.Identity.Data;

public class ApplicationDBContext : IdentityDbContext<IdentityLoginSignUpUser>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {

    }

     

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<IdentityLoginSignUp.Areas.Identity.Data.Student> Student { get; set; } = default!;
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<IdentityLoginSignUpUser>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityLoginSignUpUser> builder)
    {
        builder.Property(x=>x.Name).HasMaxLength(128);
        builder.Property(x => x.MobileNo).HasMaxLength(10);
    }
}