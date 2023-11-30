using IncidentManagement.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Context;
public class MainDbContext : DbContext
{
    public DbSet<Incident> Incidents { get; set; }
    public DbSet<Event> Events { get; set; }

    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Incident>(entity =>
        {
            entity.ToTable("incidents");
        });
        modelBuilder.Entity<Event>(entity =>
        {
            entity.ToTable("events");
            entity
                .HasOne(x => x.DerivedIncident)
                .WithMany(x => x.BaseEvents)
                .HasForeignKey(x => x.DerivedIncidentId)
                .IsRequired(false);
        });
    }
}
