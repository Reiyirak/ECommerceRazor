using System;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Aqui van a agregarse los DbSets de los modelos(tablas) mas adelante
    public DbSet<Category> Categories { get; set; }
}
