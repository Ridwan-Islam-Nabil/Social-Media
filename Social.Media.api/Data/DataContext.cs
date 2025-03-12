using System;
using Microsoft.EntityFrameworkCore;
using Social.Media.api.Entities;

namespace Social.Media.api.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
}
