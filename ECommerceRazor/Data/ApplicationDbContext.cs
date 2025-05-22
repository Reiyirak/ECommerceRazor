using System;
using ECommerceRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceRazor.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Aqui van a agregarse los DbSets de los modelos(tablas) mas adelante
    public DbSet<Category> Categories { get; set; }
}
