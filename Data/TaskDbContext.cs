using Microsoft.EntityFrameworkCore;

namespace TaskCrud.Data;

public class TaskDbContext(DbContextOptions<TaskDbContext> options): DbContext(options)
{
    public DbSet<TaskModel> Tasks => Set<TaskModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //This seed data is for testing purposes only

        modelBuilder.Entity<TaskModel>().HasData(
            new TaskModel
            {
                Id = 1,
                Name = "Test",
             
            },
            new TaskModel
            {
                Id = 2,
                Name = "Test",
              
            });
    }
}