using ApI2.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApI2.Data;
public class LibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Information> Informations { get; set; }
    public DbSet<User> Users { get; set; }
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Many-to-Many relationship configuration
        modelBuilder.Entity<OrderBook>()
            .HasKey(ob => new { ob.OrderId, ob.BookId });

        modelBuilder.Entity<OrderBook>()
            .HasOne(ob => ob.Order)
            .WithMany(o => o.OrderBooks)
            .HasForeignKey(ob => ob.OrderId);

        modelBuilder.Entity<OrderBook>()
            .HasOne(ob => ob.Book)
            .WithMany(b => b.OrderBooks)
            .HasForeignKey(ob => ob.BookId);
    }

}

