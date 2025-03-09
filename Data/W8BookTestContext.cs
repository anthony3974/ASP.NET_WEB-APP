using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using W8BookTest.Models;

namespace W8BookTest.Data
{
    public class W8BookTestContext : DbContext
    {
        public W8BookTestContext (DbContextOptions<W8BookTestContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
    }
}
