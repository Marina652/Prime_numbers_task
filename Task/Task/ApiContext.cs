using Microsoft.EntityFrameworkCore;
using MyTask.Models;
using System.Collections.Generic;

namespace MyTask;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options)
        :base(options)
    {
  
    }

    public DbSet<NumberModel> Numbers { get; set; }
}
