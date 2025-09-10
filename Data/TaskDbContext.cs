using Microsoft.EntityFrameworkCore;

namespace TaskCrud.Data;

public class TaskDbContext(DbContextOptions<TaskDbContext> options): DbContext(options)
{
    public DbSet<Task> Tasks => Set<Task>();
}