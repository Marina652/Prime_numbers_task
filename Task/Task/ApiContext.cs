using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MyTask;

public class ApiContext : DbContext
{
    protected override void OnConfiguring
   (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "NumberDb");
    }
    public DbSet<NumberModel> Numbers { get; set; }
}
