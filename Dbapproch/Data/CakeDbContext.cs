using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dbapproch.Models;

public partial class CakeDbContext : DbContext
{
    public CakeDbContext()
    {
    }

    public CakeDbContext(DbContextOptions<CakeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cakesdata> Cakesdatas { get; set; }

    public DbSet<Branchdata> Branchdatas { get; set; }

    public DbSet<Delivery> Deliveries { get; set; }

}