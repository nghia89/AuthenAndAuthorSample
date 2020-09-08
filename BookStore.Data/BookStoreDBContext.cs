using BookStore.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data
{
   public class BookStoreDBContext:DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Books> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
