using Microsoft.EntityFrameworkCore;
using Todo.Domain;
namespace Todo.Infrastructure;

public class AppDbContext: DbContext
{
    

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurer l'entité Todo
        modelBuilder.Entity<TodoItem>(entity =>
        {
            // La clé primaire
            entity.HasKey(t => t.Id);

            // Le nom est requis et a une longueur max
            entity.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // IsDone est un booléen normal
            entity.Property(t => t.IsDone)
                .IsRequired();
        });
    }
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    //public DbSet<Student> Students { get; set; }
}

    
    