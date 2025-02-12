/*
Constructor: Passes database configuration options to the base class.
?? DbSet representing the Users table in the database.
*/

using Microsoft.EntityFrameworkCore;
using PocketBook.Models;

namespace PocketBook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}