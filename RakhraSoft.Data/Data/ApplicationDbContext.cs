using System;
using Microsoft.EntityFrameworkCore;

namespace RakhraSoft.Data.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}

