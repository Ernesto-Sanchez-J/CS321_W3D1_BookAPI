using System;
using CS321_W3D1_BookAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CS321_W3D1_BookAPI.Data
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books {get; set; }

        // This method runs once when the DbContext is first used.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.Use.Sqlite("Data Source=Books.db");
        }

        // This method runs once when the DbContext is first used.
        // It's a place where we can customize how EF Core maps our
        // model to the database. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Lord of The Rings", Author = "J.R.R Tolkein", Category = "Fantasy" },
                new Book { Id = 2, Title = "Harry Potter and The Sorceror's Stone", Author = "J.K Rowling", Category = "Fantasy" }
                );
        }

    }
}

