using Microsoft.EntityFrameworkCore;

public class UserContext : DbContext{

    public DbSet<User> Users { get; set; }
    public DbSet<Role>  Roles {get; set; }

    public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //configurar FK
        modelBuilder.Entity<User>()
        .HasOne<Role>()
        .WithMany()
        .HasForeignKey(u => u.roleId);

       
    }

}