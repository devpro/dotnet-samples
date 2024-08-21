using DotnetSamples.BlogInfraMongoDb.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace DotnetSamples.BlogInfraMongoDb;

public class BlogDbContext(DbContextOptions<BlogDbContext> options, DbConfiguration dbConfiguration) : DbContext(options)
{
    private readonly DbConfiguration _dbConfiguration = dbConfiguration;

    public DbSet<Category> Categories { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            _ = optionsBuilder.UseMongoDB(_dbConfiguration.ConnectionString, databaseName: _dbConfiguration.DatabaseName);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().ToCollection("categories");
    }
}
