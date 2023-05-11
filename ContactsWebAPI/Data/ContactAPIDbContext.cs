using ContactsWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebAPI.Data
{
    public class ContactAPIDbContext: DbContext
    {

        public ContactAPIDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
